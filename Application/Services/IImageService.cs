namespace Hospital.Application.Services;
public interface IImageService
{
    Guid SavePacienteDocId(IFormFile file);
    Guid SavePacienteDocConvenio(IFormFile file);
    Guid SaveLaudoImage(IFormFile file);
    Guid SaveMedicoDocCRM(IFormFile file);
}