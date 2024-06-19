using Hospital.Domain.Entities.Atendimentos;
using Hospital.Domain.Repositories;
using Hospital.Domain.Repositories.Atendimentos;

using Microsoft.EntityFrameworkCore;

namespace Hospital.Infrastructure.Database.Repositories.Atendimentos;
public abstract class AtendimentoRepository<T, TQuery, TOut> : Repository<T, TQuery, TOut>,
IAtendimentoRepository<T, TQuery, TOut>
    where T : Atendimento, new()
    where TQuery : class
    where TOut : class
{
    private readonly IUnitOfWork _uow;
    private readonly AppDbContext _ctx;
    private readonly DbSet<T> _dbSet;
    public AtendimentoRepository(
        AppDbContext context,
        IUnitOfWork uow) : base(context, uow)
    {
        _ctx = context;
        _uow = uow;
        _dbSet = _ctx.Set<T>();
    }

    public async Task<Guid> CreateAsync(T entity)
    {
        try
        {
            var result = await _dbSet.AddAsync(entity);
            return result.Entity.Id;
        }
        catch (Exception error)
        {
            _uow.Dispose();
            throw new Exception(error.Message);
        }
    }
}