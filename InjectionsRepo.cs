using Hospital.Repository;
using Hospital.Repository.Agendamentos;
using Hospital.Repository.Atendimentos;
using Hospital.Repository.Atendimentos.Interfaces;
using Hospital.Repository.Cadastros;
using Hospital.Repository.Cadastros.Authentications;
using Hospital.Repository.Cadastros.Authentications.Interfaces;
using Hospital.Repository.Cadastros.Interfaces;
using Hospital.Repository.Convenios;
using Hospital.Repository.Convenios.Ineterfaces;
using Hospital.Repository.Images;
using Hospital.Repository.Images.Interfaces;
using Hospital.Repository.MedicamentoLotes;
using Hospital.Repository.MedicamentoLotes.Interfaces;
using Hospital.Repository.Medicamentos;
using Hospital.Repository.Medicamentos.Interfaces;

namespace Hospital;
public static class InjectionsRepo
{
    public static IServiceCollection RegisterRepositories(
        this IServiceCollection services) => services
            .AddScoped<UnitOfWork>()

            .AddScoped<IConsultaAgendamentoRepository, ConsultaAgendamentoRepository>()
            .AddScoped<IExameAgendamentoRepository, ExameAgendamentoRepository>()
            .AddScoped<IRetornoAgendamentoRepository, RetornoAgendamentoRepository>()

            .AddScoped<IConsultaRepository, ConsultaRepository>()
            .AddScoped<IExameRepository, ExameRepository>()
            .AddScoped<IRetornoRepository, RetornoRepository>()

            .AddScoped<IAuthAdminRepository, AuthAdminRepository>()
            .AddScoped<IAuthMedicoRepository, AuthMedicoRepository>()
            .AddScoped<IAuthPacienteRepository, AuthPacienteRepository>()

            .AddScoped<IAdminRepository, AdminRepository>()
            .AddScoped<IMedicoRepository, MedicoRepository>()
            .AddScoped<IPacienteRepository, PacienteRepository>()

            .AddScoped<IConvenioRepository, ConvenioRepository>()

            .AddScoped<IImageRepository, ImageRepository>()

            .AddScoped<IMedicamentoLoteRepository, MedicamentoLoteRepository>()
            .AddScoped<IMedicamentoRepository, MedicamentoRepository>()

            .AddScoped<ILaudoRepository, LaudoRepository>();
}