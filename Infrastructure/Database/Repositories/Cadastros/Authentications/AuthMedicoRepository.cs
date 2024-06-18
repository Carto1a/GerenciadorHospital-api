using Hospital.Dtos.Input.Authentications;
using Hospital.Exceptions;
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

    public async Task CreateAsync(
        Medico medico, string senha)
    {
        try
        {
            var result = await _manager.CreateAsync(medico, senha);
            if (result.Succeeded)
            {
                await AddToRoleAsync(medico);
                return;
            }

            var requestError = new RequestError(
                $"Erro ao criar usuário medico: {medico.Email}");
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

    public async Task AddToRoleAsync(Medico medico)
    {
        try
        {
            var result = await _manager
                .AddToRoleAsync(medico, Roles.Medico);
            if (result.Succeeded)
                return;

            var requestError = new RequestError(
                "Erro ao adicionar usuário medico a role: {medico.Email}");
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

    public Task<Medico?> FindByEmailAsync(string email)
    {
        return _manager.FindByEmailAsync(email);
    }

    public Task<bool> CheckPasswordAsync(Medico admin, string senha)
    {
        return _manager.CheckPasswordAsync(admin, senha);
    }

    public Task<IList<string>> GetRolesAsync(Medico admin)
    {
        return _manager.GetRolesAsync(admin);
    }

    public bool CheckIfCadastroExists(RegisterRequestMedicoDto request)
    {
        return _manager.Users.FirstOrDefault(user =>
            user.Email == request.Email
            || user.CPF == request.CPF
            || user.CRM == request.CRM) != null;
    }
}