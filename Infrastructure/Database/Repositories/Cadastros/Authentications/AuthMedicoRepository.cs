using Hospital.Application.Dto.Input.Authentications;
using Hospital.Domain.Entities;
using Hospital.Domain.Entities.Cadastros;
using Hospital.Domain.Repositories.Cadastros.Authentications;

using Microsoft.AspNetCore.Identity;

namespace Hospital.Infrastructure.Database.Repositories.Cadastros.Authentications;
public class AuthMedicoRepository : AuthRepository<Medico, RegisterRequestMedicoDto>,
IAuthMedicoRepository
{
    private readonly UserManager<Medico> _manager;
    public AuthMedicoRepository(
        UserManager<Medico> userManager) : base(userManager, Roles.Medico)
    {
        _manager = userManager;
    }
}