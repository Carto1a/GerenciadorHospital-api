using Hospital.Domain.Entities;

namespace Hospital.Domain.Repositories;
public interface IRepository<T>
where T : Entity
{
    Task<Guid> CreateAsync(T entity);
    Task<T?> GetByIdAsync(Guid id);
    Task<T?> GetByIdAtivoAsync(Guid id);
    Task<List<T>> GetAllAsync(int limit = 10, int page = 0);
    Task UpdateAsync(T entity);
}