namespace Hospital.Repository.Images.Interfaces;
public interface IImageRepository
{
    string SaveImage(IFormFile file, string path);
    Guid SaveDocID(IFormFile file);
    Guid SaveDocConvenio(IFormFile file);
}