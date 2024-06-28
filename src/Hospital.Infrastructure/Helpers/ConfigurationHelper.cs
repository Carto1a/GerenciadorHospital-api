using Microsoft.Extensions.Configuration;

namespace Hospital.Infrastructure.Helpers;
public static class ConfigurationHelper
{
    public static IConfiguration CheckConfigurations(
        this IConfiguration configuration)
    {
        if (configuration["JWT:Secret"] == null)
            throw new InvalidOperationException(
                "JWT:Secret not found in appsettings.Local.json");

        if (configuration["JWT:Secret"]!.Length < 32)
            throw new InvalidOperationException(
                "JWT:Secret must be at least 16 characters long");

        if (configuration["JWT:ValidAudience"] == null)
            throw new InvalidOperationException(
                "JWT:ValidAudience not found in appsettings.Local.json");

        if (configuration["JWT:ValidIssuer"] == null)
            throw new InvalidOperationException(
                "JWT:ValidIssuer not found in appsettings.Local.json");

        if (configuration["Paths:BaseImagens"] == null)
            throw new InvalidOperationException(
                "Paths:BaseImagens not found in appsettings.Local.json");

        if (configuration["Paths:PacienteBase"] == null)
            throw new InvalidOperationException(
                "Paths:PacienteBase not found in appsettings.Local.json");

        if (configuration["Paths:PacienteDocumentos"] == null)
            throw new InvalidOperationException(
                "Paths:PacienteDocumentos not found in appsettings.Local.json");

        if (configuration["Paths:MedicoDocumentos"] == null)
            throw new InvalidOperationException(
                "Paths:MedicoDocumentos not found in appsettings.Local.json");

        if (configuration["Paths:Laudos"] == null)
            throw new InvalidOperationException(
                "Paths:Laudos not found in appsettings.Local.json");

        return configuration;
    }
}