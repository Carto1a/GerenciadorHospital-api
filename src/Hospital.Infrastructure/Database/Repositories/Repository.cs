using Hospital.Application.Repositories;
using Hospital.Domain.Entities;
using Hospital.Domain.Repositories;
using Hospital.Infrastructure.Exceptions;

using Microsoft.EntityFrameworkCore;

namespace Hospital.Infrastructure.Database.Repositories;
public abstract class Repository<T, TQuery, TOut>
: IRepositoryRead<T, TOut, TQuery>, IRepositoryWrite<T>
where T : Entity
where TQuery : class
where TOut : class
{
    private readonly AppDbContext _ctx;
    private readonly IUnitOfWork _uow;
    private readonly DbSet<T> _dbSet;
    public Repository(
        AppDbContext context,
        IUnitOfWork uow)
    {
        _ctx = context;
        _uow = uow;
        _dbSet = _ctx.Set<T>();
    }

    public Task<T?> GetByIdAsync(Guid id)
    {
        try
        {
            var result = _dbSet.FirstOrDefaultAsync(e => e.Id == id);

            return result;
        }
        catch (Exception error)
        {
            _uow.Dispose();
            throw new RepositoryInternalException(error.Message);
        }
    }

    public Task<T?> GetByIdAtivoAsync(Guid id)
    {
        try
        {
            var result = _dbSet
                .FirstOrDefaultAsync(e => e.Id == id && e.Ativo);

            return result;
        }
        catch (Exception error)
        {
            _uow.Dispose();
            throw new RepositoryInternalException(error.Message);
        }
    }

    public Task<TOut?> GetByIdDtoAsync(Guid id)
    {
        try
        {
            var result = _dbSet
                .Where(e => e.Id == id)
                .Select(e => (TOut)Activator.CreateInstance(typeof(TOut), e));

            return result.FirstOrDefaultAsync();
        }
        catch (Exception error)
        {
            _uow.Dispose();
            throw new RepositoryInternalException(error.Message);
        }
    }

    public void Update(T entity)
    {
        try
        {
            _ = _dbSet.Update(entity);
        }
        catch (Exception error)
        {
            _uow.Dispose();
            throw new RepositoryInternalException(error.Message);
        }
    }

    public abstract Task<List<TOut>> GetByQueryDtoAsync(TQuery query);

    public Task<Guid> CreateAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(Guid id)
    {
        throw new NotImplementedException();
    }
}