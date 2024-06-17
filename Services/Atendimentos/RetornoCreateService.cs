using Hospital.Dtos.Input.Atendimentos;
using Hospital.Enums;
using Hospital.Exceptions;
using Hospital.Models.Atendimento;
using Hospital.Repository.Atendimentos.Interfaces;
using Hospital.Repository.Cadastros.Interfaces;

namespace Hospital.Services.Atendimentos;
public class RetornoCreateService
{
    private readonly IConsultaRepository _consultaRepository;
    private readonly IRetornoAgendamentoRepository _retornoAgendamentoRepository;
    private readonly IMedicoRepository _medicoRepository;
    private readonly IPacienteRepository _pacienteRepository;
    private readonly IRetornoRepository _retornoRepository;

    public RetornoCreateService(
        IConsultaRepository consultaRepository,
        IRetornoAgendamentoRepository retornoAgendamentoRepository,
        IMedicoRepository medicoRepository,
        IPacienteRepository pacienteRepository,
        IRetornoRepository retornoRepository)
    {
        _consultaRepository = consultaRepository;
        _retornoAgendamentoRepository = retornoAgendamentoRepository;
        _medicoRepository = medicoRepository;
        _pacienteRepository = pacienteRepository;
        _retornoRepository = retornoRepository;
    }

    public async Task<string> Handler(RetornoCreateDto request)
    {
        var retorno = new Retorno(request);
        var findConsulta = await _consultaRepository
            .GetByIdAsync(request.ConsultaId);
        if (findConsulta == null)
            throw new RequestError(
                $"Consulta não encontrada: {request.ConsultaId}",
                "Consulta não encontrada");

        var findAgendamento = await _retornoAgendamentoRepository
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

        retorno.PacienteId = findAgendamento.PacienteId;
        retorno.MedicoId = findAgendamento.MedicoId;
        retorno.ConvenioId = findAgendamento.ConvenioId;
        retorno.Custo = findAgendamento.Custo;
        retorno.CustoFinal = findAgendamento.CustoFinal;

        var id = await _retornoRepository.Create(retorno);
        findAgendamento.Status = AgendamentoStatus.Realizado;
        await _retornoAgendamentoRepository.UpdateAsync(findAgendamento);

        return $"/api/retorno/{id}";
    }
}