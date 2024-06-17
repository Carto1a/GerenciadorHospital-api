using Hospital.Repository;
using Hospital.Repository.Cadastros.Authentications;
using Hospital.Repository.Cadastros.Authentications.Interfaces;
using Hospital.Repository.Convenios;
using Hospital.Repository.Convenios.Ineterfaces;
using Hospital.Services.Agendamentos;
using Hospital.Services.Atendimentos;
using Hospital.Services.Cadastros;
using Hospital.Services.Cadastros.Admins;
using Hospital.Services.Cadastros.Medicos;
using Hospital.Services.Cadastros.Pacientes;
using Hospital.Services.Convenios;
using Hospital.Services.Laudos;
using Hospital.Services.Medicamentos;

namespace Hospital;
public static class Injections
{
    public static IServiceCollection RegisterServices(
        this IServiceCollection services) => services
        .AddScoped<AgendamentoConsultaCreateService>()
        .AddScoped<AgendamentoConsultaEmEsperaService>()
        .AddScoped<AgendamentoExameCreateService>()
        .AddScoped<AgendamentoExameEmEsperaService>()
        .AddScoped<AgendamentoRetornoCreateService>()
        .AddScoped<AgendamentoRetornoEmEsperaService>()

        .AddScoped<RetornoCreateService>()
        .AddScoped<ConsultaCreateService>()
        .AddScoped<ExameCreateService>()
        .AddScoped<ExameCompletarService>()

        .AddScoped<AdminGetByQueryService>()
        .AddScoped<AuthAdminLoginService>()
        .AddScoped<AuthAdminRegisterService>()

        .AddScoped<MedicoGetByQueryService>()
        .AddScoped<MedicoLoginService>()
        .AddScoped<MedicoRegisterService>()

        .AddScoped<PacienteGetByIdService>()
        .AddScoped<PacienteGetByQueryService>()
        .AddScoped<PacienteLoginService>()
        .AddScoped<PacienteRegisterService>()

        .AddScoped<ConvenioCreateService>()
        .AddScoped<ConvenioGetByIdService>()
        .AddScoped<ConvenioGetByQueryService>()

        .AddScoped<LaudoAddImageService>()
        .AddScoped<LaudoCreateService>()

        .AddScoped<MedicamentoCreateService>()
        .AddScoped<MedicamentoGetByIdService>()
        .AddScoped<MedicamentoGetByQueryService>()
        .AddScoped<MedicamentoLoteCreateService>()
        .AddScoped<MedicamentoLoteGetByIdService>()
        .AddScoped<MedicamentoLoteGetByQueryService>()
        .AddScoped<MedicamentoWithdrawService>();
}