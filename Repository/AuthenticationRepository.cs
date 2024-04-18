using Hospital.Database;
using Hospital.Models;
using Hospital.Repository.Interfaces;

namespace Hospital.Repository;
public class AuthenticationRepository : IAuthenticationRepository
{
    private readonly AppDbContext _ctx;
    public AuthenticationRepository(AppDbContext ctx)
    {
        _ctx = ctx;
    }

    public async Task CreatePaciente(Paciente user)
    {
        await _ctx.Pacientes.AddAsync(user);
        await _ctx.SaveChangesAsync();
    }
    public async Task CreateMedico(Medico user)
    {
        await _ctx.Medicos.AddAsync(user);
        await _ctx.SaveChangesAsync();
    }
    public async Task CreateAdmin(Admin user)
    {
        await _ctx.Admins.AddAsync(user);
        await _ctx.SaveChangesAsync();
    }
}
