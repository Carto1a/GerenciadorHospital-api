using Hospital.Dtos.Input.Laudos;
using Hospital.Models;

namespace Hospital.Repository;
public interface ILaudoRepository
{
    Task<Guid> Create(Laudo laudo);
    Task<Laudo?> GetByIdAsync(Guid id);
    Task Update(Laudo laudo);
    List<Laudo> GetByQueryDtoAsync(LaudoGetByQueryDto query);
}