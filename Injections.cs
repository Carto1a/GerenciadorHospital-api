using Hospital.Dtos.Input.Authentications;
using Hospital.Repository;
using Hospital.Repository.Cadastros;
using Hospital.Repository.Cadastros.Authentications;
using Hospital.Repository.Cadastros.Authentications.Interfaces;
using Hospital.Repository.Cadastros.Interfaces;
using Hospital.Repository.Convenios;
using Hospital.Repository.Convenios.Ineterfaces;
using Hospital.Repository.Images;
using Hospital.Repository.Images.Interfaces;
using Hospital.Services.Cadastros;
using Hospital.Services.Cadastros.Admins;
using Hospital.Services.Cadastros.Medicos;
using Hospital.Services.Cadastros.Pacientes;
using Hospital.Services.Convenios;
using Hospital.Services.Medicamentos;

namespace Hospital;
public static class Injections
{
    public static IServiceCollection RegisterServices(
        this IServiceCollection services) => services
        // Unit of Work
        .AddScoped<UnitOfWork>()
        // Image Repository
        .AddScoped<IImageRepository, ImageRepository>()
        // Medico Repository
        .AddScoped<IMedicoRepository, MedicoRepository>()
        // Auth Repository
        .AddScoped<IAuthAdminRepository, AuthAdminRepository>()
        .AddScoped<IAuthMedicoRepository, AuthMedicoRepository>()
        .AddScoped<IAuthPacienteRepository, AuthPacienteRepository>()
        .AddScoped<IConvenioRepository, ConvenioRepository>()
        // Admin Service
        .AddScoped<AuthAdminRegisterService>()
        .AddScoped<AuthAdminLoginService>()
        .AddScoped<AdminGetByQueryService>()
        // Medico Service
        .AddScoped<MedicoLoginService>()
        .AddScoped<MedicoRegisterService>()
        .AddScoped<MedicoGetByQueryService>()
        // Paciente Service
        .AddScoped<PacienteLoginService>()
        .AddScoped<PacienteRegisterService>()
        .AddScoped<PacienteGetByIdService>()
        .AddScoped<PacienteGetByQueryService>()
        // Convenio Service
        .AddScoped<ConvenioCreateService>()
        .AddScoped<ConvenioGetByIdService>()
        .AddScoped<ConvenioGetByQueryService>()
        // Medicamento Service
        .AddScoped<MedicamentoCreateService>()
        .AddScoped<MedicamentoLoteCreateService>()
        .AddScoped<MedicamentoGetByIdService>()
        .AddScoped<MedicamentoLoteGetByIdService>()
        .AddScoped<MedicamentoWithdrawService>()
        .AddScoped<MedicamentoGetByQueryService>()
        .AddScoped<MedicamentoLoteGetByQueryService>();
}