namespace Hospital.Application.Repositories;
public interface IRepositoryRead<T, TOut, TQuery>
{
    Task<T?> GetByIdAsync(Guid id);
    Task<TOut?> GetByIdDtoAsync(Guid id);
    Task<T?> GetByIdAtivoAsync(Guid id);
    Task<List<TOut>> GetByQueryDtoAsync(TQuery query);
}