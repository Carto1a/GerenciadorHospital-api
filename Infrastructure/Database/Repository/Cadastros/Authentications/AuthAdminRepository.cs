using Hospital.Dtos.Input.Authentications;
using Hospital.Exceptions;
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
    public async Task CreateAsync(
        Admin admin, string senha)
    {
        try
        {
            var result = await _manager.CreateAsync(admin, senha);
            if (result.Succeeded)
            {
                await AddToRoleAsync(admin);
                return;
            }

            var requestError = new RequestError(
                $"Erro ao criar usuário admin: {admin.Email}");

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

    public async Task AddToRoleAsync(Admin admin)
    {
        try
        {
            var result = await _manager
                .AddToRoleAsync(admin, Roles.Admin);
            if (result.Succeeded)
                return;

            var requestError = new RequestError(
                $"Erro ao adicionar usuário admin a role: {admin.Email}");
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

    public Task<Admin?> FindByEmailAsync(string email)
    {
        return _manager.FindByEmailAsync(email);
    }

    public Task<bool> CheckPasswordAsync(Admin admin, string senha)
    {
        return _manager.CheckPasswordAsync(admin, senha);
    }

    public Task<IList<string>> GetRolesAsync(Admin admin)
    {
        return _manager.GetRolesAsync(admin);
    }

    public bool CheckIfCadastroExists(RegisterRequestAdminDto request)
    {
        return _manager.Users.FirstOrDefault(user =>
            user.Email == request.Email
            || user.CPF == request.CPF) != null;
    }
}