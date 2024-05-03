namespace Hospital.Repository.Atendimentos.Interfaces;
public interface IAtendimentoRepository<T, TOut, TQuery>
{
    Task<Guid> CreateAsync(T exame);
    Task<T?> GetByIdAsync(Guid id);
    Task<TOut?> GetByIdDtoAsync(Guid id);
    Task UpdateAsync(T entity);
    List<TOut> GetByQueryDto(TQuery query);
}