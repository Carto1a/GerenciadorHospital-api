using FluentResults;

using Hospital.Models.Cadastro;
using Hospital.Repository.Cadastros.Authentications.Interfaces;

using Microsoft.AspNetCore.Identity;

namespace Hospital.Repository.Cadastros.Authentications;
public class AuthPacienteRepository
: IAuthPacienteRepository
{
    private readonly UserManager<Paciente> _manager;
    public AuthPacienteRepository(
        UserManager<Paciente> userManager)
    {
        _manager = userManager;
    }

    public async Task<Result> Create(
        Paciente paciente, string senha)
    {
        try
        {
            var result = await _manager
                .CreateAsync(paciente, senha);
            Result? roleResult = Result.Ok();
            Result? createResult = Result.Ok();
            if (result.Succeeded)
            {
                roleResult = await AddToRole(paciente);
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

    public async Task<Result> AddToRole(Paciente paciente)
    {
        try
        {
            var result = await _manager
                .AddToRoleAsync(paciente, Roles.Paciente);
            if (result.Succeeded)
                return Result.Ok();

            return Result.Fail(result.Errors.Select(e => e.Description));
        }
        catch (Exception e)
        {
            return Result.Fail(e.Message);
        }
    }

    public Task<Paciente?> FindByEmail(string email)
    {
        return _manager.FindByEmailAsync(email);
    }

    public Task<bool> CheckPassword(Paciente admin, string senha)
    {
        return _manager.CheckPasswordAsync(admin, senha);
    }

    public Task<IList<string>> GetRoles(Paciente admin)
    {
        return _manager.GetRolesAsync(admin);
    }
}