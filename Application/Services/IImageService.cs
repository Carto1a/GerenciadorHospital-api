namespace Hospital.Application.Services;
public interface IImageService
{
    Guid SaveDocId(IFormFile file);
    Guid SaveDocConvenio(IFormFile file);
    Guid SaveLaudoImage(IFormFile file);
    Guid SaveMedicoDocCRM(IFormFile file);
}