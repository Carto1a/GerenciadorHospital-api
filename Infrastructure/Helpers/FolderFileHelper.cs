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

    public static IConfiguration CheckAndCreateFolders(
        this IConfiguration configuration)
    {
        CheckAndCreateFolder(configuration["Paths:BaseImagens"]!);

        var baseDir = configuration["Paths:BaseImagens"]!;

        CheckAndCreateFolder(baseDir + configuration["Paths:PacienteBase"]!);
        CheckAndCreateFolder(baseDir + configuration["Paths:PacienteDocumentos"]!);
        CheckAndCreateFolder(baseDir + configuration["Paths:PacienteConvenio"]!);
        CheckAndCreateFolder(baseDir + configuration["Paths:MedicoDocumentos"]!);
        CheckAndCreateFolder(baseDir + configuration["Paths:Laudos"]!);

        return configuration;
    }
}