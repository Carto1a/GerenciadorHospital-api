using Hospital.Repository.Images.Interfaces;

namespace Hospital.Repository.Images;
public class ImageRepository
: IImageRepository
{
    private readonly IConfiguration _configuration;

    public ImageRepository(
        IConfiguration configuration)
    {
        _configuration = configuration;
    }

    // NOTE: não sei se é possível dar problema con o CopyToAsync
    // do IFormFile.
    public string SaveImage(
        IFormFile file, string path)
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

    public Guid SaveDocConvenio(IFormFile file)
    {
        try
        {
            var path = _configuration["Paths:PacienteConvenio"]!;
            return Guid.Parse(SaveImage(file, path));
        }
        catch (Exception error)
        {
            throw new Exception(error.Message);
        }
    }

    public Guid SaveDocID(IFormFile file)
    {
        try
        {
            var path = _configuration["Paths:PacienteDocumentos"]!;
            return Guid.Parse(SaveImage(file, path));
        }
        catch (Exception error)
        {
            throw new Exception(error.Message);
        }
    }

    public void DeleteImage(string path)
    {
        try
        {
            File.Delete(path);
        }
        catch (Exception error)
        {
            throw new Exception(error.Message);
        }
    }

    public Guid SaveLaudoImage(
        IFormFile file)
    {
        try
        {
            var path = _configuration["Paths:Laudos"]!;
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
            var path = _configuration["Paths:MedicoDocumentos"]!;
            return Guid.Parse(SaveImage(file, path));
        }
        catch (Exception error)
        {
            throw new Exception(error.Message);
        }
    }
}