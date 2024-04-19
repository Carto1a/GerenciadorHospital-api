using FluentResults;

using Hospital.Models.Cadastro;
using Hospital.Repository.Cadastros.Authentications.Interfaces;

using Microsoft.AspNetCore.Identity;

namespace Hospital.Repository.Cadastros.Authentications;
// TODO: generico? (⊙_⊙;)
public class AuthAdminRepository
: IAuthAdminRepository
{
    private readonly UserManager<Admin> _manager;
    public AuthAdminRepository(
        UserManager<Admin> userManager)
    {
        _manager = userManager;
    }
    public async Task<Result> Create(
        Admin admin, string senha)
    {
        try
        {
            var result = await _manager
                .CreateAsync(admin, senha);
            Result? roleResult = Result.Ok();
            Result? createResult = Result.Ok();
            if (result.Succeeded)
            {
                roleResult = await AddToRole(admin);
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

    public async Task<Result> AddToRole(Admin admin)
    {
        try
        {
            var result = await _manager
                .AddToRoleAsync(admin, Roles.Admin);
            if (result.Succeeded)
                return Result.Ok();

            return Result.Fail(result.Errors.Select(e => e.Description));
        }
        catch (Exception e)
        {
            return Result.Fail(e.Message);
        }
    }

    public Task<Admin?> FindByEmail(string email)
    {
        return _manager.FindByEmailAsync(email);
    }

    public Task<bool> CheckPassword(Admin admin, string senha)
    {
        return _manager.CheckPasswordAsync(admin, senha);
    }

    public Task<IList<string>> GetRoles(Admin admin)
    {
        return _manager.GetRolesAsync(admin);
    }
}