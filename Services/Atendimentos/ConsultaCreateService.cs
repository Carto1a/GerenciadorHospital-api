using Hospital.Dtos.Input.Atendimentos;
using Hospital.Enums;
using Hospital.Exceptions;
using Hospital.Models.Atendimento;
using Hospital.Repository;
using Hospital.Repository.Atendimentos.Interfaces;
using Hospital.Repository.Cadastros.Interfaces;
using Hospital.Repository.Convenios.Ineterfaces;

namespace Hospital.Services.Atendimentos;
public class ConsultaCreateService
{
    private readonly UnitOfWork _unitOfWork;
    private readonly IConsultaRepository _consultaRepository;
    private readonly IMedicoRepository _medicoRepository;
    private readonly IPacienteRepository _pacienteRepository;
    private readonly IConvenioRepository _convenioRepository;
    private readonly IConsultaAgendamentoRepository _consultaAgendamentoRepository;
    public ConsultaCreateService(
        UnitOfWork unitOfWork,
        IConsultaRepository consultaRepository,
        IMedicoRepository medicoRepository,
        IPacienteRepository pacienteRepository,
        IConvenioRepository convenioRepository,
        IConsultaAgendamentoRepository consultaAgendamentoRepository)
    {
        _unitOfWork = unitOfWork;
        _consultaRepository = consultaRepository;
        _medicoRepository = medicoRepository;
        _pacienteRepository = pacienteRepository;
        _convenioRepository = convenioRepository;
        _consultaAgendamentoRepository = consultaAgendamentoRepository;
    }

    public async Task<string> Handler(
        ConsultaCreateDto request)
    {
        var consulta = new Consulta(request);

        var findAgendamento = await _consultaAgendamentoRepository
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

        consulta.PacienteId = findAgendamento.PacienteId;
        consulta.MedicoId = findAgendamento.MedicoId;
        consulta.ConvenioId = findAgendamento.ConvenioId;
        consulta.Custo = findAgendamento.Custo;
        consulta.CustoFinal = findAgendamento.CustoFinal;

        await _consultaRepository.Create(consulta);
        findAgendamento.Status = AgendamentoStatus.Realizado;
        await _consultaAgendamentoRepository.UpdateAsync(findAgendamento);

        return $"/api/Consulta/{consulta.Id}";
    }
}