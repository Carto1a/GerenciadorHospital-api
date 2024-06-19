using Hospital.Domain.Enums;
using Hospital.Domain.Exceptions;
using Hospital.Domain.Repositories;
using Hospital.Domain.Repositories.Agendamentos;

namespace Hospital.Application.UseCases.Agendamentos;
public class AgendamentoExameEmEsperaUseCase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IExameAgendamentoRepository _exameAgendamentoRepository;
    public AgendamentoExameEmEsperaUseCase(
        IUnitOfWork unitOfWork,
        IExameAgendamentoRepository exameAgendamentoRepository)
    {
        _unitOfWork = unitOfWork;
        _exameAgendamentoRepository = exameAgendamentoRepository;
    }

    public async Task Handler(Guid agendamentoId)
    {
        var agendamento = await _exameAgendamentoRepository
            .GetByIdAsync(agendamentoId);
        if (agendamento == null)
            throw new DomainException(
                $"Agendamento não encontrado: {agendamentoId}",
                "Agendamento não encontrado");

        if (agendamento.Status == AgendamentoStatus.Cancelado
            || agendamento.Status == AgendamentoStatus.Realizado)
            throw new DomainException(
                $"Agendamento já foi {agendamento.Status}",
                "Agendamento já foi cancelado ou realizado");

        if (agendamento.Status == AgendamentoStatus.EmEspera)
            throw new DomainException(
                $"Agendamento já está em espera: {agendamento.Status}",
                "Agendamento já está em espera");

        if (agendamento.Atrasado(DateTime.Now))
            agendamento.CalcularMulta(null);

        if (agendamento.Ausente(DateTime.Now))
        {
            agendamento.Ausencia();
            _exameAgendamentoRepository.UpdateAsync(agendamento);
            await _unitOfWork.SaveAsync();
            throw new DomainException(
                $"Agendamento cancelado por atraso: {agendamento.DataHora}",
                "Agendamento cancelado por atraso");
        }

        agendamento.EmEspera();
        _exameAgendamentoRepository.UpdateAsync(agendamento);
        await _unitOfWork.SaveAsync();
    }
}