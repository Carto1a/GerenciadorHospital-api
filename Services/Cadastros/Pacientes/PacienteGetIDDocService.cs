using Hospital.Repository.Cadastros.Interfaces;
using Hospital.Repository.Images.Interfaces;

namespace Hospital.Services.Cadastros.Pacientes;
public class PacienteGetIDDocService
{
    private readonly IPacienteRepository _pacienteRepository;
    private readonly IImageRepository _imageRepository;
    private readonly IConfiguration _configuration;
    public PacienteGetIDDocService(
        IPacienteRepository pacienteRepository,
        IImageRepository imageRepository,
        IConfiguration configuration)
    {
        _pacienteRepository = pacienteRepository;
        _imageRepository = imageRepository;
        _configuration = configuration;
    }

    public async Task<string> Handler(
        Guid pacienteId)
    {
        var rootPath = _configuration["Path:BaseImagens"];
        var pacienteBasePath = _configuration["Path:PacienteBase"];
        var pacienteIdDocPath = _configuration["Path:PacienteDocumentos"];

        var basePath = Path.Combine(rootPath, pacienteBasePath, pacienteIdDocPath);
        if (!Directory.Exists(basePath))
            throw new ArgumentException(
                "Diretório de imagens não existe");

        var pacienteDocName = _pacienteRepository
            .GetPacienteById(pacienteId).DocIDPath;

        var docIdPath = Path.Combine(basePath, pacienteDocName.ToString());
        if (!File.Exists(docIdPath))
            throw new ArgumentException(
                "Documento de identificação não existe");

        return docIdPath;
    }
}