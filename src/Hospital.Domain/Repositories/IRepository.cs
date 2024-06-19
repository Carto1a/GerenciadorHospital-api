namespace Hospital.Domain.Repositories;
public interface IRepository<T, TQuery, TOutDto>
{
    Task<T?> GetByIdAsync(Guid id);
    Task<T?> GetByIdAtivoAsync(Guid id);
    Task<TOutDto?> GetByIdDtoAsync(Guid id);
    Task<List<T>> GetAllAsync(int limit = 10, int page = 0);
    Task<List<TOutDto>> GetByQueryDtoAsync(TQuery query);
    void UpdateAsync(T entity);
}