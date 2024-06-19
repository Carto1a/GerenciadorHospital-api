using Hospital.Application.Services;
using Hospital.Domain.Exceptions;
using Hospital.Domain.Repositories;
using Hospital.Domain.Repositories.Cadastros;

namespace Hospital.Application.UseCases.Cadastros.Pacientes;
public class PacienteAddDocIdUseCase
{
    private readonly IPacienteRepository _pacienteRepository;
    private readonly IImageService _imageService;
    private readonly IUnitOfWork _uow;
    public PacienteAddDocIdUseCase(
        IPacienteRepository pacienteRepository,
        IImageService imageService,
        IUnitOfWork uow)
    {
        _pacienteRepository = pacienteRepository;
        _imageService = imageService;
        _uow = uow;
    }

    public async Task<Guid> Handler(Guid id, IFormFile image)
    {
        var paciente = await _pacienteRepository.GetByIdAsync(id);
        if (paciente == null)
            throw new DomainException(
                $"Paciente não encontrado: {id}",
                "Paciente não encontrado");

        var imageId = _imageService.SavePacienteDocId(image);
        paciente.DocIDPath = imageId;

        _pacienteRepository.UpdateAsync(paciente);
        await _uow.SaveAsync();

        return imageId;
    }
}