using Hospital.Application.Services;
using Hospital.Domain.Exceptions;
using Hospital.Domain.Repositories.Cadastros;

namespace Hospital.Application.UseCases.Cadastros.Pacientes;
public class PacienteGetDocIdUseCase
{
    private readonly IPacienteRepository _pacienteRepository;
    private readonly IImageService _imageService;
    public PacienteGetDocIdUseCase(
        IPacienteRepository pacienteRepository,
        IImageService imageService)
    {
        _pacienteRepository = pacienteRepository;
        _imageService = imageService;
    }

    public async Task<Stream> Handler(Guid pacienteId)
    {
        var paciente = await _pacienteRepository
            .GetByIdAsync(pacienteId);
        if (paciente == null)
            throw new DomainException("Paciente não encontrado");

        var docIdName = paciente.DocIDPath;
        if (docIdName == null)
            throw new DomainException("Documento de identificação não encontrado");


        var stream = _imageService.GetPacienteDocIdPath((Guid)docIdName);
        return stream;
    }
}