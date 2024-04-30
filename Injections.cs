using Hospital.Repository;
using Hospital.Repository.Cadastros.Authentications;
using Hospital.Repository.Cadastros.Authentications.Interfaces;
using Hospital.Repository.Convenios;
using Hospital.Repository.Convenios.Ineterfaces;
using Hospital.Repository.Images;
using Hospital.Repository.Images.Interfaces;
using Hospital.Services.Cadastros;
using Hospital.Services.Cadastros.Admins;
using Hospital.Services.Cadastros.Medicos;
using Hospital.Services.Cadastros.Pacientes;
using Hospital.Services.Pacientes;

namespace Hospital;
public static class Injections
{
    public static IServiceCollection RegisterServices(
        this IServiceCollection services) => services
        // Unit of Work
        .AddScoped<UnitOfWork>()
        // Image Repository
        .AddScoped<IImageRepository, ImageRepository>()
        // Auth Repository
        .AddScoped<IAuthAdminRepository, AuthAdminRepository>()
        .AddScoped<IAuthMedicoRepository, AuthMedicoRepository>()
        .AddScoped<IAuthPacienteRepository, AuthPacienteRepository>()
        .AddScoped<IConvenioRepository, ConvenioRepository>()
        // Admin Service
        .AddScoped<AuthAdminRegisterService>()
        .AddScoped<AuthAdminLoginService>()
        // Medico Service
        .AddScoped<MedicoLoginService>()
        .AddScoped<MedicoRegisterService>()
        // Paciente Service
        .AddScoped<PacienteLoginService>()
        .AddScoped<PacienteRegisterService>()
        .AddScoped<PacienteGetByIdService>();
}