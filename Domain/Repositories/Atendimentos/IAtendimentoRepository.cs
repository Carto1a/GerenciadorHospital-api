namespace Hospital.Domain.Repositories.Atendimentos;
public interface IAtendimentoRepository<T, TQuery, TOutput>
: IRepository<T, TQuery, TOutput>
{
    Task<Guid> CreateAsync(T exame);
}