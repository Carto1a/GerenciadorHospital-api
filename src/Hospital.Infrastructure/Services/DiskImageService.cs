using Hospital.Application.Services;
using Hospital.Infrastructure.Exceptions;

namespace Hospital.Infrastructure.Services;
public class DiskImageService : IImageService
{
    private readonly string _imagePath;
    private readonly string _laudoPath;
    private readonly string _medicoPath;
    private readonly string _pacientePath;
    private readonly string _pacienteConvenioPath;
    private readonly string _pacienteIdDocPath;
    public DiskImageService(string basePath, string laudoPath,
        string medicoPath, string pacientePath, string pacienteConvenioPath,
        string pacienteIdDocPath)
    {
        _imagePath = basePath;
        _laudoPath = Path.Combine(_imagePath, laudoPath);
        _medicoPath = Path.Combine(_imagePath, medicoPath);
        _pacientePath = Path.Combine(_imagePath, pacientePath);
        _pacienteConvenioPath = Path.Combine(_pacientePath, pacienteConvenioPath);
        _pacienteIdDocPath = Path.Combine(_pacientePath, pacienteIdDocPath);

        // NOTE: confiar em quem está chamando para passar os caminhos não vazios?
    }

    private string SaveImage(Stream file, string path)
    {
        try
        {
            var imageGuid = Guid.NewGuid();
            var loopCount = 0;
            while (File.Exists(Path.Combine(path, imageGuid.ToString())))
            {
                imageGuid = Guid.NewGuid();
                loopCount++;
                if (loopCount > 15)
                {
                    throw new ServiceException(
                        "Não foi possível gerar um nome único para a imagem");
                }
            }

            var imagePath = Path.Combine(path, imageGuid.ToString());

            Stream fileStream =
                new FileStream(imagePath, FileMode.Create);

            var task = file.CopyToAsync(fileStream)
                .ContinueWith(task => fileStream.Close());

            return imageGuid.ToString();
        }
        catch (Exception error)
        {
            throw new ServiceException(error.Message);
        }
    }

    public Stream GetLaudoImagePath(Guid id)
    {
        var path = _laudoPath;

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
        var path = _medicoPath;

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
        var path = _pacienteConvenioPath;

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
        var path = _pacienteIdDocPath;

        if (!Directory.Exists(path))
            throw new ArgumentException(
                "Diretório de imagens não existe");

        var fullImagePath = Path.Combine(path, id.ToString());
        if (!File.Exists(fullImagePath))
            throw new ArgumentException(
                "Documento de identificação não existe");

        return new FileStream(fullImagePath, FileMode.Open);
    }

    public Guid SaveLaudoImage(Stream file)
    {
        try
        {
            var path = _laudoPath;
            return Guid.Parse(SaveImage(file, path));
        }
        catch (Exception error)
        {
            throw new ServiceException(error.Message);
        }
    }

    public Guid SaveMedicoDocCRM(Stream file)
    {
        try
        {
            var path = _medicoPath;
            return Guid.Parse(SaveImage(file, path));
        }
        catch (Exception error)
        {
            throw new ServiceException(error.Message);
        }
    }

    public Guid SavePacienteDocConvenio(Stream file)
    {
        try
        {
            var path = _pacienteConvenioPath;
            return Guid.Parse(SaveImage(file, path));
        }
        catch (Exception error)
        {
            throw new ServiceException(error.Message);
        }
    }

    public Guid SavePacienteDocId(Stream file)
    {
        try
        {
            var path = _pacienteIdDocPath;
            return Guid.Parse(SaveImage(file, path));
        }
        catch (Exception error)
        {
            throw new ServiceException(error.Message);
        }
    }
}