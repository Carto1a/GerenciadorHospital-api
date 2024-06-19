using Hospital.Application.Dto.Input.Authentications;
using Hospital.Domain.Entities;
using Hospital.Domain.Entities.Cadastros;
using Hospital.Domain.Repositories.Cadastros.Authentications;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

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

    public override async Task<bool> CheckIfCadastroExistsAsync(RegisterRequestAdminDto request)
    {
        var result = await _manager.Users.FirstOrDefaultAsync(
            user => user.Email == request.Email
                || user.CPF == request.CPF);
        return result != null;
    }
}