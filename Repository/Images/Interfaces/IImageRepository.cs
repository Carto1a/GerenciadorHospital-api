namespace Hospital.Repository.Images.Interfaces;
public interface IImageRepository
{
    Guid SaveDocID(IFormFile file);
    Guid SaveDocConvenio(IFormFile file);
    Guid SaveLaudoImage(IFormFile file);
}