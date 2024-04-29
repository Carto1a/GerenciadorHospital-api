using FluentResults;

using Hospital.Dtos.Input.Agendamentos;
using Hospital.Models.Agendamentos;
using Hospital.Models.Atendimento;

using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Hospital.Repository.Agendamentos.Interfaces;
public interface IAgendamentoRepository<T, TAgendamento>
    where T : Atendimento
    where TAgendamento : Agendamento
{
    Result<EntityEntry<TAgendamento>>
        Create(TAgendamento agentamento);

    Result
        Update(TAgendamento NovoAgendamento);

    Result<TAgendamento?>
        GetById(Guid id);

    Result<List<TAgendamento>>
        GetByQuery(AgendamentoGetByQueryDto query);
}