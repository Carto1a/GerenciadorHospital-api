using Hospital.Repository;
using Hospital.Repository.Cadastros.Authentications;
using Hospital.Repository.Cadastros.Authentications.Interfaces;
using Hospital.Services.Cadastros;
using Hospital.Services.Cadastros.Admins;
using Hospital.Services.Cadastros.Medicos;

namespace Hospital;
public static class Injections
{
    public static IServiceCollection RegisterServices(
        this IServiceCollection services) => services
        // Unit of Work
        .AddScoped<UnitOfWork>()
        // Auth Repository
        .AddScoped<IAuthAdminRepository, AuthAdminRepository>()
        .AddScoped<IAuthMedicoRepository, AuthMedicoRepository>()
        .AddScoped<IAuthPacienteRepository, AuthPacienteRepository>()

        // Admin Service
        .AddScoped<AuthAdminRegisterService>()
        .AddScoped<AuthAdminLoginService>()
        // Medico Service
        .AddScoped<MedicoLoginService>()
        .AddScoped<MedicoRegisterService>();
}