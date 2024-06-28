using Hospital.Domain.Entities.Atendimentos;

namespace Hospital.Domain.Repositories.Atendimentos;
public interface IExameRepositoryWrite
: IRepositoryWrite<Exame>
{
    Task<List<Exame>> GetExamesByIdsAsync(IEnumerable<Guid> ids);
}