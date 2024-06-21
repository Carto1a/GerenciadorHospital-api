using Hospital.Domain.Entities.Atendimentos;

namespace Hospital.Domain.Repositories.Atendimentos;
public interface IExameRepository
: IRepository<Exame>
{
    Task<List<Exame>> GetExamesByIdsAsync(IEnumerable<Guid> ids);
}