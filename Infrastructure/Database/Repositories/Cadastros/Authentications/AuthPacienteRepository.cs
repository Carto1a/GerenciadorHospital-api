using Hospital.Dtos.Input.Authentications;
using Hospital.Exceptions;
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

    public async Task CreateAsync(
        Paciente paciente, string senha)
    {
        try
        {
            var result = await _manager
                .CreateAsync(paciente, senha);
            if (result.Succeeded)
            {
                await AddToRoleAsync(paciente);
                return;
            }

            var requestError = new RequestError(
                $"Erro ao criar usuário paciente: {paciente.Email}");
            foreach (var error in result.Errors)
                requestError.Add(error.Description);

            throw requestError;
        }
        catch (Exception error)
        {
            throw new Exception(error.Message);
        }
    }

    public async Task AddToRoleAsync(Paciente paciente)
    {
        try
        {
            var result = await _manager
                .AddToRoleAsync(paciente, Roles.Paciente);
            if (result.Succeeded)
                return;

            var requestError = new RequestError(
                $"Erro ao adicionar usuário paciente a role: {paciente.Email}");
            foreach (var error in result.Errors)
                requestError.Add(error.Description);

            throw requestError;
        }
        catch (Exception error)
        {
            throw new Exception(error.Message);
        }
    }

    public Task<Paciente?> FindByEmailAsync(string email)
    {
        return _manager.FindByEmailAsync(email);
    }

    public Task<bool> CheckPasswordAsync(Paciente admin, string senha)
    {
        return _manager.CheckPasswordAsync(admin, senha);
    }

    public Task<IList<string>> GetRolesAsync(Paciente admin)
    {
        return _manager.GetRolesAsync(admin);
    }

    public bool CheckIfCadastroExists(RegisterRequestPacienteDto request)
    {
        return _manager.Users.FirstOrDefault(user =>
            user.Email == request.Email
            || user.CPF == request.CPF) != null;
    }
}