/* using Hospital.Domain.Repositories; */
/* using Hospital.Domain.Repositories.Agendamentos; */
/* using Hospital.Domain.Repositories.Atendimentos; */
/* using Hospital.Domain.Repositories.Cadastros; */
/* using Hospital.Domain.Repositories.Cadastros.Authentications; */
/* using Hospital.Infrastructure.Database.Repositories; */
/* using Hospital.Infrastructure.Database.Repositories.Agendamentos; */
/* using Hospital.Infrastructure.Database.Repositories.Atendimentos; */
/* using Hospital.Infrastructure.Database.Repositories.Cadastros; */
/* using Hospital.Infrastructure.Database.Repositories.Cadastros.Authentications; */
/* using Hospital.Infrastructure.Database.Repositories.Convenios; */
/* using Hospital.Infrastructure.Database.Repositories.Medicamentos; */
/* using Hospital.Repository.MedicamentoLotes; */

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Hospital.Infrastructure.Database;
public static class EntityFrameworkInjection
{
    public static IServiceCollection InjectEntityFramework(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        return services;
        /* return services.AddDbContext<AppDbContext>(options => */
        /*     options.UseSqlServer(configuration.GetConnectionString("DbSqlServer")!) */
        /* options.UseSqlite(configuration.GetConnectionString("DbSqlite")!) */
        /* ); */
        /* .AddScoped<IUnitOfWork, UnitOfWork>() */

        /* .AddScoped<IConsultaAgendamentoRepository, ConsultaAgendamentoRepository>() */
        /* .AddScoped<IExameAgendamentoRepository, ExameAgendamentoRepository>() */
        /* .AddScoped<IRetornoAgendamentoRepository, RetornoAgendamentoRepository>() */

        /* .AddScoped<IConsultaRepository, ConsultaRepository>() */
        /* .AddScoped<IExameRepository, ExameRepository>() */
        /* .AddScoped<IRetornoRepository, RetornoRepository>() */

        /* .AddScoped<IAdminRepository, AdminRepository>() */
        /* .AddScoped<IMedicoRepository, MedicoRepository>() */
        /* .AddScoped<IPacienteRepository, PacienteRepository>() */

        /* .AddScoped<IAuthAdminRepository, AuthAdminRepository>() */
        /* .AddScoped<IAuthMedicoRepository, AuthMedicoRepository>() */
        /* .AddScoped<IAuthPacienteRepository, AuthPacienteRepository>() */

        /* .AddScoped<IConvenioRepository, ConvenioRepository>() */

        /* .AddScoped<IMedicamentoLoteRepository, MedicamentoLoteRepository>() */

        /* .AddScoped<IMedicamentoRepository, MedicamentoRepository>() */

        /* .AddScoped<ILaudoRepository, LaudoRepository>(); */
    }
}