using Hospital.Domain.Entities.Agendamentos;

namespace Hospital.Domain.Repositories.Agendamentos;
public interface IAgendamentoRepository<T>
: IRepository<T>
where T : Agendamento
{
    Task<List<T>> GetByDataHoraMedicoAsync(DateTime dataHora, Guid medicoId);
}