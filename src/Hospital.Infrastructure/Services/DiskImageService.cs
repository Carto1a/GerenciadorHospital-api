using Hospital.Application.Services;

namespace Hospital.Infrastructure.Services;
public class DiskImageService : IImageService
{
    private readonly IConfiguration _configuration;
    private readonly string _imagePath;
    public DiskImageService(IConfiguration configuration)
    {
        _configuration = configuration;
        _imagePath = _configuration["Paths:BaseImagens"];
        if (!Directory.Exists(_imagePath))
            throw new ArgumentException("Diretório de imagens não existe");
    }

    public string SaveImage(IFormFile file, string path)
    {
        try
        {
            var ImageGuid = Guid.NewGuid();
            var LoopCount = 0;
            while(File.Exists(Path.Combine(path, ImageGuid.ToString())))
            {
                ImageGuid = Guid.NewGuid();
                LoopCount++;
                if (LoopCount > 15)
                {
                    throw new Exception(
                        "Não foi possível gerar um nome único para a imagem");
                }
            }

            var ImagePath = Path.Combine(path, ImageGuid.ToString());

            Stream fileStream =
                new FileStream(ImagePath, FileMode.Create);

            Task task = file.CopyToAsync(fileStream)
                .ContinueWith(task => fileStream.Close());

            return ImageGuid.ToString();
        }
        catch (Exception error)
        {
            throw new Exception(error.Message);
        }
    }

    public Stream GetLaudoImagePath(Guid id)
    {
        var laudoPath = _configuration["Paths:Laudos"]!;
        var path = Path.Combine(_imagePath, laudoPath);

        if (!Directory.Exists(path))
            throw new ArgumentException(
                "Diretório de imagens não existe");

        var fullImagePath = Path.Combine(path, id.ToString());
        if (!File.Exists(fullImagePath))
            throw new ArgumentException(
                "Documento de identificação não existe");

        return new FileStream(fullImagePath, FileMode.Open);
    }

    public Stream GetMedicoDocCRMPath(Guid id)
    {
        var medicoBase = _configuration["Paths:MedicoDocumentos"]!;
        var path = Path.Combine(_imagePath, medicoBase);

        if (!Directory.Exists(path))
            throw new ArgumentException(
                "Diretório de imagens não existe");

        var fullImagePath = Path.Combine(path, id.ToString());
        if (!File.Exists(fullImagePath))
            throw new ArgumentException(
                "Documento de identificação não existe");

        return new FileStream(fullImagePath, FileMode.Open);
    }

    public Stream GetPacienteDocConvenioPath(Guid id)
    {
        var pacienteBase = _configuration["Paths:PacienteBase"]!;
        var pacientePath = _configuration["Paths:PacienteConvenio"]!;
        var path = Path.Combine(_imagePath, pacienteBase, pacientePath);

        if (!Directory.Exists(path))
            throw new ArgumentException(
                "Diretório de imagens não existe");

        var fullImagePath = Path.Combine(path, id.ToString());
        if (!File.Exists(fullImagePath))
            throw new ArgumentException(
                "Documento do Convenio não existe");

        return new FileStream(fullImagePath, FileMode.Open);
    }

    public Stream GetPacienteDocIdPath(Guid id)
    {
        var pacienteBase = _configuration["Paths:PacienteBase"]!;
        var pacientePath = _configuration["Paths:PacienteDocumentos"]!;
        var path = Path.Combine(_imagePath, pacienteBase, pacientePath);

        if (!Directory.Exists(path))
            throw new ArgumentException(
                "Diretório de imagens não existe");

        var fullImagePath = Path.Combine(path, id.ToString());
        if (!File.Exists(fullImagePath))
            throw new ArgumentException(
                "Documento de identificação não existe");

        return new FileStream(fullImagePath, FileMode.Open);
    }

    public Guid SaveLaudoImage(IFormFile file)
    {
        try
        {
            var lautoPath = _configuration["Paths:Laudos"]!;
            var path = Path.Combine(_imagePath, lautoPath);
            return Guid.Parse(SaveImage(file, path));
        }
        catch (Exception error)
        {
            throw new Exception(error.Message);
        }
    }

    public Guid SaveMedicoDocCRM(IFormFile file)
    {
        try
        {
            var MedicoPath = _configuration["Paths:MedicoDocumentos"]!;
            var path = Path.Combine(_imagePath, MedicoPath);
            return Guid.Parse(SaveImage(file, path));
        }
        catch (Exception error)
        {
            throw new Exception(error.Message);
        }
    }

    public Guid SavePacienteDocConvenio(IFormFile file)
    {
        try
        {
            var pacienteBase = _configuration["Paths:PacienteBase"]!;
            var pacientePath = _configuration["Paths:PacienteConvenio"]!;
            var path = Path.Combine(_imagePath, pacienteBase, pacientePath);
            return Guid.Parse(SaveImage(file, path));
        }
        catch (Exception error)
        {
            throw new Exception(error.Message);
        }
    }

    public Guid SavePacienteDocId(IFormFile file)
    {
        try
        {
            var pacienteBase = _configuration["Paths:PacienteBase"]!;
            var pacientePath = _configuration["Paths:PacienteDocumentos"]!;
            var path = Path.Combine(_imagePath, pacienteBase, pacientePath);
            return Guid.Parse(SaveImage(file, path));
        }
        catch (Exception error)
        {
            throw new Exception(error.Message);
        }
    }
}