/* using Hospital.Application.Dto.Output.Cadastros; */
/* using Hospital.Domain.Entities.Cadastros; */
/* using Hospital.Domain.Repositories; */

/* using Microsoft.EntityFrameworkCore; */

/* namespace Hospital.Infrastructure.Database.Repositories.Cadastros; */
/* public abstract class CadastroRepository<T, TQuery, TOut> */
/* : IRepository<T, TQuery, TOut> */
/* where T : Cadastro */
/* where TQuery : class */
/* where TOut : CadastroOutputDto, new() */
/* { */
/*     private readonly AppDbContext _ctx; */
/*     private readonly IUnitOfWork _uow; */
/*     private readonly DbSet<T> _dbSet; */
/*     public CadastroRepository( */
/*         AppDbContext context, */
/*         IUnitOfWork uow) */
/*     { */
/*         _ctx = context; */
/*         _uow = uow; */
/*         _dbSet = _ctx.Set<T>(); */
/*     } */

/*     public Task<List<T>> GetAllAsync(int limit = 10, int page = 0) */
/*     { */
/*         try */
/*         { */
/*             var result = _dbSet */
/*                 .Skip(page) */
/*                 .Take(limit) */
/*                 .ToListAsync(); */

/*             return result; */
/*         } */
/*         catch (Exception error) */
/*         { */
/*             _uow.Dispose(); */
/*             throw new Exception(error.Message); */
/*         } */
/*     } */

/*     public Task<T?> GetByIdAsync(Guid id) */
/*     { */
/*         try */
/*         { */
/*             var result = _dbSet */
/*                 .FirstOrDefaultAsync(e => e.Id == id); */

/*             return result; */
/*         } */
/*         catch (Exception error) */
/*         { */
/*             _uow.Dispose(); */
/*             throw new Exception(error.Message); */
/*         } */
/*     } */

/*     public Task<T?> GetByIdAtivoAsync(Guid id) */
/*     { */
/*         try */
/*         { */
/*             var result = _dbSet */
/*                 .FirstOrDefaultAsync(e => e.Id == id && e.Ativo); */

/*             return result; */
/*         } */
/*         catch (Exception error) */
/*         { */
/*             _uow.Dispose(); */
/*             throw new Exception(error.Message); */
/*         } */
/*     } */

/*     public Task<TOut?> GetByIdDtoAsync(Guid id) */
/*     { */
/*         try */
/*         { */
/*             var result = _dbSet */
/*                 .Where(e => e.Id == id) */
/*                 .Select(e => (TOut)new TOut().Create(e)); */

/*             return result.FirstOrDefaultAsync(); */
/*         } */
/*         catch (Exception error) */
/*         { */
/*             _uow.Dispose(); */
/*             throw new Exception(error.Message); */
/*         } */
/*     } */

/*     public void UpdateAsync(T entity) */
/*     { */
/*         try */
/*         { */
/*             _dbSet.Update(entity); */
/*         } */
/*         catch (Exception error) */
/*         { */
/*             _uow.Dispose(); */
/*             throw new Exception(error.Message); */
/*         } */
/*     } */

/*     public abstract Task<List<TOut>> GetByQueryDtoAsync(TQuery query); */
/* } */