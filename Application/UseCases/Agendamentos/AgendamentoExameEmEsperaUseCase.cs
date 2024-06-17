using Hospital.Enums;
using Hospital.Exceptions;
using Hospital.Repository;
using Hospital.Repository.Atendimentos.Interfaces;

namespace Hospital.Services.Agendamentos;
public class AgendamentoExameEmEsperaService
{
    private readonly UnitOfWork _unitOfWork;
    private readonly IExameAgendamentoRepository _exameAgendamentoRepository;
    public AgendamentoExameEmEsperaService(
        UnitOfWork unitOfWork,
        IExameAgendamentoRepository exameAgendamentoRepository)
    {
        _unitOfWork = unitOfWork;
        _exameAgendamentoRepository = exameAgendamentoRepository;
    }

    public async Task Handler(
        Guid agendamentoId)
    {
        var agendamento = await _exameAgendamentoRepository
            .GetByIdAsync(agendamentoId);
        if (agendamento == null)
            throw new RequestError(
                $"Agendamento não encontrado: {agendamentoId}",
                "Agendamento não encontrado");

        if (agendamento.Status == AgendamentoStatus.Cancelado
            || agendamento.Status == AgendamentoStatus.Realizado)
            throw new RequestError(
                $"Agendamento já foi {agendamento.Status}",
                "Agendamento já foi cancelado ou realizado");

        if (agendamento.Status == AgendamentoStatus.EmEspera)
            throw new RequestError(
                $"Agendamento já está em espera: {agendamento.Status}",
                "Agendamento já está em espera");

        if (agendamento.DataHora.AddMinutes(30) < DateTime.Now)
            agendamento.CustoFinal = agendamento.CustoFinal * 1.1m;

        if (agendamento.DataHora.AddHours(3) < DateTime.Now) {
            agendamento.Status = AgendamentoStatus.Ausencia;
            await _exameAgendamentoRepository.UpdateAsync(agendamento);
            throw new RequestError(
                $"Agendamento cancelado por atraso: {agendamento.DataHora}",
                "Agendamento cancelado por atraso");
        }

        agendamento.Status = AgendamentoStatus.EmEspera;
        await _exameAgendamentoRepository.UpdateAsync(agendamento);
    }
}
