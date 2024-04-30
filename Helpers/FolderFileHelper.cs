namespace Hospital.Helpers;
public static class FolderFileHelper
{
    private static void CheckAndCreateFolder(string path)
    {
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
    }

    private static void CheckIfFileExists(string path)
    {
        if (!File.Exists(path))
            throw new FileNotFoundException($"File not found: {path}");
    }

    public static void CheckAndCreateFolders(
        IConfiguration configuration)
    {
        CheckAndCreateFolder(configuration["Paths:BaseImagens"]!);
        CheckAndCreateFolder(configuration["Paths:PacienteBase"]!);
        CheckAndCreateFolder(configuration["Paths:PacienteDocumentos"]!);
        CheckAndCreateFolder(configuration["Paths:PacienteConvenio"]!);
        CheckAndCreateFolder(configuration["Paths:MedicoDocumentos"]!);
        CheckAndCreateFolder(configuration["Paths:Laudos"]!);
    }

    public static void CheckConfigurations(
        IConfiguration configuration)
    {
        if (configuration["JWT:Secret"] == null)
            throw new InvalidOperationException(
                "JWT:Secret not found in appsettings.Local.json");

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
    }

    public static void CheckIfConfigurationsExists(
        IConfiguration configuration)
    {
    }
}