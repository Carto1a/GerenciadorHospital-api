using Hospital.Application.Dto.Input.Authentications;
using Hospital.Domain.Entities;
using Hospital.Domain.Entities.Cadastros;
using Hospital.Domain.Repositories.Cadastros.Authentications;

using Microsoft.AspNetCore.Identity;

namespace Hospital.Infrastructure.Database.Repositories.Cadastros.Authentications;

public class AuthAdminRepository : AuthRepository<Admin, RegisterRequestAdminDto>,
IAuthAdminRepository
{
    private readonly UserManager<Admin> _manager;
    public AuthAdminRepository(
        UserManager<Admin> userManager) : base(userManager, Roles.Admin)
    {
        _manager = userManager;
    }
}