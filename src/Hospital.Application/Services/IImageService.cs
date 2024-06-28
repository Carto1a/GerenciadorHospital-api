namespace Hospital.Application.Services;
public interface IImageService
{
    Guid SavePacienteDocId(Stream file);
    Guid SavePacienteDocConvenio(Stream file);
    Guid SaveLaudoImage(Stream file);
    Guid SaveMedicoDocCRM(Stream file);

    Stream GetPacienteDocIdPath(Guid id);
    Stream GetPacienteDocConvenioPath(Guid id);
    Stream GetLaudoImagePath(Guid id);
    Stream GetMedicoDocCRMPath(Guid id);
}