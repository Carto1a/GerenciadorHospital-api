using Hospital.Application.Dto.Input.Authentications;
using Hospital.Domain.Entities;
using Hospital.Domain.Entities.Cadastros;
using Hospital.Domain.Repositories.Cadastros.Authentications;

using Microsoft.AspNetCore.Identity;

namespace Hospital.Infrastructure.Database.Repositories.Cadastros.Authentications;
public class AuthPacienteRepository : AuthRepository<Paciente, RegisterRequestPacienteDto>,
IAuthPacienteRepository
{
    private readonly UserManager<Paciente> _manager;
    public AuthPacienteRepository(
        UserManager<Paciente> userManager) : base(userManager, Roles.Paciente)
    {
        _manager = userManager;
    }
}