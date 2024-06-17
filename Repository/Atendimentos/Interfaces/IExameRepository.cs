using Hospital.Models.Atendimento;

namespace Hospital.Repository.Atendimentos.Interfaces;
public interface IExameRepository : IAtendimentoRepository<Exame>
{
    Task<List<Exame>> GetExamesByIdsAsync(IEnumerable<Guid> ids);
}