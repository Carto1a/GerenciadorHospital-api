using Hospital.Application.Dto.Output.Cadastros;
using Hospital.Application.Repositories.Cadastros;
using Hospital.Domain.Entities.Cadastros;
using Hospital.Domain.Repositories;
using Hospital.Domain.Repositories.Cadastros;
using Hospital.Infrastructure.Database.Models;
using Hospital.Infrastructure.Exceptions;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Infrastructure.Database.Repositories.Cadastros;
public abstract class CadastroRepository<T, TQuery, TOut>
: IAuthRepositoryRead<T, TOut, TQuery>,
  IAuthRepositoryWrite<T>
where T : CadastroModel
where TQuery : class
where TOut : CadastroOutputDto, new()
{
    private readonly AppDbContext _ctx;
    private readonly UserManager<T> _manager;
    private readonly IUnitOfWork _uow;
    private readonly DbSet<T> _dbSet;
    private readonly string _defaultRole;
    public CadastroRepository(
        AppDbContext context,
        IUnitOfWork uow,
        UserManager<T> manager,
        string defaultRole)
    {
        _ctx = context;
        _uow = uow;
        _dbSet = _ctx.Set<T>();
        _manager = manager;
        _defaultRole = defaultRole;
    }

    public async Task AddToRoleAsync(T entity, string role)
    {
        try
        {
            var result = await _manager.AddToRoleAsync(entity, role);
            if (result.Succeeded)
                return;

            var requestError = new RepositoryException(
                $"Erro ao adicionar usuário admin a role: {entity.Email}");

            // TODO: mudar esse tipo de loop
            /* foreach (var error in result.Errors) */
            /*     requestError.Add(error.Description); */

            throw requestError;

        }
        catch (Exception error)
        {
            throw new RepositoryInternalException(error.Message);
        }
    }

    public Task<bool> CheckPasswordAsync(T entity, string password)
    {
        return _manager.CheckPasswordAsync(entity, password);
    }

    public async Task CreateAsync(T entity, string password)
    {
        try
        {
            var result = await _manager.CreateAsync(entity, password);
            if (result.Succeeded)
            {
                await AddToRoleAsync(entity, _defaultRole);
                return;
            }

            var requestError = new RepositoryException(
                $"Erro ao criar usuário admin: {entity.Email}");

            /* foreach (var error in result.Errors) */
            /*     requestError.Add(error.Description); */

            throw requestError;
        }
        catch (Exception error)
        {
            throw new RepositoryInternalException(error.Message);
        }
    }

    public Task<TOut> GetByCpfDtoAsync(string cpf)
    {
        throw new NotImplementedException();
    }

    public async Task<TOut> GetByEmailDtoAsync(string email)
    {
        throw new NotImplementedException();
        /* try */
        /* { */
        /*     var result = _dbSet.FirstOrDefaultAsync( */
        /*         e => e.Email == email); */

        /*     return result; */
        /* } */
        /* catch (Exception error) */
        /* { */
        /*     _uow.Dispose(); */
        /*     throw new RepositoryInternalException(error.Message); */
        /* } */
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
        throw new NotImplementedException();
        /* try */
        /* { */
        /*     var result = _dbSet.FirstOrDefaultAsync( */
        /*         e => e.Id == id && e.Ativo); */

        /*     return result; */
        /* } */
        /* catch (Exception error) */
        /* { */
        /*     _uow.Dispose(); */
        /*     throw new RepositoryInternalException(error.Message); */
        /* } */
    }

    public Task<TOut?> GetByIdDtoAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public void Update(T entity)
    {
        try
        {
            _dbSet.Update(entity);
        }
        catch (Exception error)
        {
            _uow.Dispose();
            throw new RepositoryInternalException(error.Message);
        }
    }

    public Task<bool> CheckIfCadastroExistsAsync(Cadastro cadastro)
    {
        throw new NotImplementedException();
    }

    public abstract Task<List<TOut>> GetByQueryDtoAsync(TQuery query);
}