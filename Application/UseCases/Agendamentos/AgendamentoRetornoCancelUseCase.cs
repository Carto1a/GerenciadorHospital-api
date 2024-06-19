using Hospital.Domain.Enums;
using Hospital.Domain.Exceptions;
using Hospital.Domain.Repositories;
using Hospital.Domain.Repositories.Agendamentos;

namespace Hospital.Application.UseCases.Agendamentos;
public class AgendamentoRetornoCancelUseCase
{
    private readonly IRetornoAgendamentoRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    public AgendamentoRetornoCancelUseCase(
        IRetornoAgendamentoRepository repository,
        IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handler(Guid id)
    {
        var agendamento = await _repository.GetByIdAsync(id);
        if (agendamento == null)
            throw new DomainException(
                $"Agendamento não encontrado: {id}",
                "Agendamento não encontrado");

        var cantCancel = AgendamentoStatus.Cancelado
            | AgendamentoStatus.Realizado
            | AgendamentoStatus.EmEspera
            | AgendamentoStatus.Ausencia
            | AgendamentoStatus.EmAndamento;

        if (agendamento.Status.HasFlag(cantCancel))
            throw new DomainException(
                $"Agendamento já foi {agendamento.Status}",
                "Agendamento já foi cancelado ou realizado");

        agendamento.Cancelar();
        _repository.UpdateAsync(agendamento);
        await _unitOfWork.SaveAsync();
    }
}