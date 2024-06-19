using Hospital.Application.Services;
using Hospital.Domain.Exceptions;
using Hospital.Domain.Repositories.Cadastros;

namespace Hospital.Application.UseCases.Cadastros.Pacientes;
public class PacienteGetDocConvenioUseCase
{
    private readonly IPacienteRepository _pacienteRepository;
    private readonly IImageService _imageService;
    public PacienteGetDocConvenioUseCase(
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

        var docConvenioName = paciente.DocConvenioPath;
        if (docConvenioName == null)
            throw new DomainException("Documento do Convenio não encontrado");


        var stream = _imageService.GetPacienteDocConvenioPath((Guid)docConvenioName);
        return stream;
    }
}