using Hospital.Domain.Entities;

namespace Hospital.Domain.Repositories;
public interface IRepositoryWrite<T>
where T : Entity
{
    Task<Guid> CreateAsync(T entity);
    void Update(T entity);
    void Delete(Guid id);
}