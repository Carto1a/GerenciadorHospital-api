using Hospital.Dtos.Input.Atendimentos;
using Hospital.Enums;
using Hospital.Exceptions;
using Hospital.Infrastructure.Database.Repositories;
using Hospital.Models.Atendimento;
using Hospital.Repository.Atendimentos.Interfaces;

namespace Hospital.Application.UseCases.Atendimentos;
public class ExameCreateUseCase
{
    private readonly UnitOfWork _unitOfWork;
    private readonly IExameRepository _exameRepository;
    private readonly IExameAgendamentoRepository _exameAgendamentoRepository;
    private readonly IConsultaAgendamentoRepository _consultaAgendamentoRepository;
    private readonly IConsultaRepository _consultaRepository;

    public ExameCreateUseCase(
        UnitOfWork unitOfWork,
        IExameRepository exameRepository,
        IExameAgendamentoRepository exameAgendamentoRepository,
        IConsultaAgendamentoRepository consultaAgendamentoRepository,
        IConsultaRepository consultaRepository)
    {
        _unitOfWork = unitOfWork;
        _exameRepository = exameRepository;
        _exameAgendamentoRepository = exameAgendamentoRepository;
        _consultaAgendamentoRepository = consultaAgendamentoRepository;
        _consultaRepository = consultaRepository;
    }

    public async Task<string> Handler(
        ExameCreateDto request)
    {
        var exame = new Exame(request);
        var findAgendamento = await _exameAgendamentoRepository
            .GetByIdAsync(request.AgendamentoId);
        if (findAgendamento == null)
            throw new RequestError(
                $"Agendamento não encontrado: {request.AgendamentoId}",
                "Agendamento não encontrado");

        if (findAgendamento.Status == AgendamentoStatus.Cancelado
            || findAgendamento.Status == AgendamentoStatus.Realizado)
            throw new RequestError(
                $"Agendamento já foi {findAgendamento.Status}",
                "Agendamento já foi cancelado ou realizado");

        if (findAgendamento.Status != AgendamentoStatus.EmEspera)
            throw new RequestError(
                $"Agendamento não está em espera: {findAgendamento.Status}",
                "Agendamento não está em espera");

        var findConsulta = await _consultaRepository
            .GetByIdAsync(request.ConsultaId);
        if (findConsulta == null)
            throw new RequestError(
                $"Agendamento não é uma consulta: {findAgendamento.Id}",
                "Agendamento não é uma consulta");

        exame.PacienteId = findAgendamento.PacienteId;
        exame.MedicoId = findAgendamento.MedicoId;
        exame.ConvenioId = findAgendamento.ConvenioId;
        exame.Custo = findAgendamento.CustoFinal;
        exame.CustoFinal = findAgendamento.CustoFinal;

        await _exameRepository.Create(exame);

        findAgendamento.Status = AgendamentoStatus.Realizado;
        await _exameAgendamentoRepository.UpdateAsync(findAgendamento);

        if (request.Status == ExameStatus.Processando)
        {
            findConsulta.Status = ConsultaStatus.Processando;
            await _consultaRepository.Update(findConsulta);
        }

        return $"/api/Exame/{exame.Id}";
    }
}