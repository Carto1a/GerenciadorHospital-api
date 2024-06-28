using Hospital.Application.Services;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Hospital.Infrastructure.Services;
public static class ServicesInjection
{
    public static IServiceCollection InjectServices(
        this IServiceCollection services)
    {
        return services
            .AddScoped<IImageService, DiskImageService>(sp =>
            {
                var configuration = sp.GetRequiredService<IConfiguration>();
                var basePath = configuration["Paths:BaseImagens"]!;
                var pacienteBase = configuration["Paths:PacienteBase"]!;
                var pacienteDocumentos = configuration["Paths:PacienteDocumentos"]!;
                var pacienteConvenios = configuration["Paths:PacienteConvenio"]!;
                var medicoDocumentos = configuration["Paths:MedicoDocumentos"]!;
                var laudos = configuration["Paths:Laudos"]!;

                return new DiskImageService(basePath, laudos, medicoDocumentos,
                    pacienteBase, pacienteConvenios, pacienteDocumentos);
            })
            .AddScoped<IJwtTokenService, JwtTokenService>();
    }
}