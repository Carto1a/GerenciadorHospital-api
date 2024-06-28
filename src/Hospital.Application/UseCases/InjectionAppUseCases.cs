/* using Hospital.Application.UseCases.Agendamentos; */
/* using Hospital.Application.UseCases.Atendimentos; */
/* using Hospital.Application.UseCases.Cadastros.Admins; */
/* using Hospital.Application.UseCases.Cadastros.Medicos; */
/* using Hospital.Application.UseCases.Cadastros.Pacientes; */
/* using Hospital.Application.UseCases.Convenios; */
/* using Hospital.Application.UseCases.Laudos; */
/* using Hospital.Application.UseCases.Medicamentos; */

using Microsoft.Extensions.DependencyInjection;

namespace Hospital.Application.UseCases;
public static class InjectionAppUseCases
{
    public static IServiceCollection RegisterUseCase(
        this IServiceCollection services)
    {
        return services

        /* .AddScoped<MedicamentoCreateUseCase>() */
        /* .AddScoped<MedicamentoGetByIdUseCase>() */
        /* .AddScoped<MedicamentoGetByQueryUseCase>() */
        /* .AddScoped<MedicamentoUpdateUseCase>() */
        /* .AddScoped<MedicamentoWithdrawUseCase>() */
        /* .AddScoped<MedicamentoDeleteUseCase>() */

        /* .AddScoped<MedicamentoLoteCreateUseCase>() */
        /* .AddScoped<MedicamentoLoteGetByIdUseCase>() */
        /* .AddScoped<MedicamentoLoteGetByQueryUseCase>() */
        /* .AddScoped<MedicamentoLoteUpdateUseCase>() */
        /* .AddScoped<MedicamentoLoteDeleteUseCase>() */


        /* .AddScoped<LaudoAddImageUseCase>() */
        /* .AddScoped<LaudoCreateUseCase>() */
        /* .AddScoped<LaudoGetByIdUseCase>() */
        /* .AddScoped<LaudoGetByQueryUseCase>() */
        /* .AddScoped<LaudoGetDocImageUseCase>() */
        /* .AddScoped<LaudoUpdateUseCase>() */


        /* .AddScoped<ConvenioCreateUseCase>() */
        /* .AddScoped<ConvenioDeleteUseCase>() */
        /* .AddScoped<ConvenioGetByCnpjUseCase>() */
        /* .AddScoped<ConvenioGetByIdUseCase>() */
        /* .AddScoped<ConvenioGetByQueryUseCase>() */
        /* .AddScoped<ConvenioUpdateUseCase>() */


        /* .AddScoped<PacienteDeleteUseCase>() */
        /* .AddScoped<PacienteGetAgendamentosUseCase>() */
        /* .AddScoped<PacienteGetAtendimentosUseCase>() */
        /* .AddScoped<PacienteGetByIdUseCase>() */
        /* .AddScoped<PacienteGetByQueryUseCase>() */
        /* .AddScoped<PacienteGetConvenioUseCase>() */
        /* .AddScoped<PacienteGetDocConvenioUseCase>() */
        /* .AddScoped<PacienteGetDocIdUseCase>() */
        /* .AddScoped<PacienteGetLaudosUseCase>() */
        /* .AddScoped<PacienteGetMedicamentosUseCase>() */
        /* .AddScoped<PacienteLoginUseCase>() */
        /* .AddScoped<PacienteRegisterUseCase>() */
        /* .AddScoped<PacienteUpdateUseCase>() */


        /* .AddScoped<MedicoGetByIdUseCase>() */
        /* .AddScoped<MedicoGetByQueryUseCase>() */
        /* .AddScoped<MedicoGetDocCrmUseCase>() */
        /* .AddScoped<MedicoLoginUseCase>() */
        /* .AddScoped<MedicoRegisterUseCase>() */


        /* .AddScoped<AdminGetByIdUseCase>() */
        /* .AddScoped<AdminGetByQueryUseCase>() */
        /* .AddScoped<AdminLoginUseCase>() */
        /* .AddScoped<AdminRegisterUseCase>() */


        /* .AddScoped<ConsultaCreateUseCase>() */
        /* .AddScoped<ConsultaGetByQueryUseCase>() */
        /* .AddScoped<ConsultaGetByIdUseCase>() */

        /* .AddScoped<ExameCompletarUseCase>() */
        /* .AddScoped<ExameCreateUseCase>() */
        /* .AddScoped<ExameGetByQueryUseCase>() */
        /* .AddScoped<ExameGetByIdUseCase>() */

        /* .AddScoped<RetornoCreateUseCase>() */
        /* .AddScoped<RetornoGetByQueryUseCase>() */
        /* .AddScoped<RetornoGetByIdUseCase>() */


        /* .AddScoped<AgendamentoConsultaCancelUseCase>() */
        /* .AddScoped<AgendamentoConsultaCreateUseCase>() */
        /* .AddScoped<AgendamentoConsultaEmEsperaUseCase>() */
        /* .AddScoped<AgendamentoConsultaGetByQueryUseCase>() */
        /* .AddScoped<AgendamentoConsultaGetByIdUseCase>() */

        /* .AddScoped<AgendamentoExameCreateUseCase>() */
        /* .AddScoped<AgendamentoExameEmEsperaUseCase>() */
        /* .AddScoped<AgendamentoExameGetByQueryUseCase>() */
        /* .AddScoped<AgendamentoExameGetByIdUseCase>() */

        /* .AddScoped<AgendamentoRetornoCreateUseCase>() */
        /* .AddScoped<AgendamentoRetornoEmEsperaUseCase>() */
        /* .AddScoped<AgendamentoRetornoGetByQueryUseCase>() */
        /* .AddScoped<AgendamentoRetornoGetByIdUseCase>() */
        ;
    }
}