using FluentResults;

using Hospital.Models.Cadastro;
using Hospital.Repository.Cadastros.Authentications.Interfaces;

using Microsoft.AspNetCore.Identity;

namespace Hospital.Repository.Cadastros.Authentications;
public class AuthMedicoRepository
: IAuthMedicoRepository
{
    private readonly UserManager<Medico> _manager;
    public AuthMedicoRepository(
        UserManager<Medico> userManager)
    {
        _manager = userManager;
    }

    public async Task<Result> Create(
        Medico medico, string senha)
    {
        try
        {
            var result = await _manager
                .CreateAsync(medico, senha);
            Result? roleResult = Result.Ok();
            Result? createResult = Result.Ok();
            if (result.Succeeded)
            {
                roleResult = await AddToRole(medico);
                if (roleResult.IsSuccess)
                    return Result.Ok();
            }

            // TODO: melhorar essa aberração
            createResult = Result.Fail(result.Errors.Select(e => e.Description));
            if (roleResult != null)
                createResult = Result.Merge(roleResult, createResult);
            return createResult;
        }
        catch (Exception e)
        {
            return Result.Fail(e.Message);
        }
    }

    public async Task<Result> AddToRole(Medico medico)
    {
        try
        {
            var result = await _manager
                .AddToRoleAsync(medico, Roles.Medico);
            if (result.Succeeded)
                return Result.Ok();

            return Result.Fail(result.Errors.Select(e => e.Description));
        }
        catch (Exception e)
        {
            return Result.Fail(e.Message);
        }
    }

    public Task<Medico?> FindByEmail(string email)
    {
        return _manager.FindByEmailAsync(email);
    }

    public Task<bool> CheckPassword(Medico admin, string senha)
    {
        return _manager.CheckPasswordAsync(admin, senha);
    }

    public Task<IList<string>> GetRoles(Medico admin)
    {
        return _manager.GetRolesAsync(admin);
    }
}