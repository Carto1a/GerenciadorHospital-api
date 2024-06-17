using Hospital.Domain.Entities.Agendamentos;

namespace Hospital.Domain.Repositories.Agendamentos;
public interface IAgendamentoRepository<TAgendamento, TAgendamentoQuery, TAgendamentoOutputDto>
: IRepository<TAgendamento, TAgendamentoQuery, TAgendamentoOutputDto>
    where TAgendamento : Agendamento
{
    Task<Guid> CreateAsync(TAgendamento agentamento);
    Task<List<TAgendamento>> GetByDataHoraMedicoAsync(DateTime dataHora, Guid medicoId);
}