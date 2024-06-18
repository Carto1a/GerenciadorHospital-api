using Hospital.Application.Dto.Input.Authentications;
using Hospital.Domain.Entities.Cadastros;
using Hospital.Domain.Exceptions;
using Hospital.Domain.Repositories.Cadastros.Authentications;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Infrastructure.Database.Repositories.Cadastros.Authentications;
public abstract class AuthRepository<T, TRegister> : IAuthRepository<T, TRegister>
where T : Cadastro
where TRegister : RegisterRequestDto
{
    private readonly UserManager<T> _manager;
    private readonly string _defaultRole;
    public AuthRepository(
        UserManager<T> userManager,
        string defaultRole)
    {
        _manager = userManager;
        _defaultRole = defaultRole;
    }

    public async Task AddToRoleAsync(T entity, string role)
    {
        try
        {
            var result = await _manager
                .AddToRoleAsync(entity, role);
            if (result.Succeeded)
                return;

            var requestError = new DomainException(
                $"Erro ao adicionar usuário admin a role: {entity.Email}");
            // TODO: mudar esse tipo de loop
            foreach (var error in result.Errors)
                requestError.Add(error.Description);

            throw requestError;

        }
        catch (Exception error)
        {
            throw new Exception(error.Message);
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

            var requestError = new DomainException(
                $"Erro ao criar usuário admin: {entity.Email}");

            foreach (var error in result.Errors)
                requestError.Add(error.Description);

            throw requestError;
        }
        catch (Exception error)
        {
            throw new Exception(error.Message);
        }
    }

    public Task<T?> FindByEmailAsync(string email)
    {
        return _manager.FindByEmailAsync(email);
    }

    public Task<IList<string>> GetRolesAsync(T entity)
    {
        return _manager.GetRolesAsync(entity);
    }

    public Task<bool> IsInRoleAsync(T entity, string role)
    {
        return _manager.IsInRoleAsync(entity, role);
    }

    /* public async Task<bool> CheckIfCadastroExistsAsync(TRegister request) */
    /* { */
    /*     var result = await _manager.Users.FirstOrDefaultAsync(user => */
    /*         user.Equals(request)); */
    /*     return result != null; */
    /* } */

    public abstract Task<bool> CheckIfCadastroExistsAsync(TRegister request);
}