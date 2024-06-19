using Hospital.Application.Services;
using Hospital.Domain.Exceptions;
using Hospital.Domain.Repositories;
using Hospital.Domain.Repositories.Cadastros;

namespace Hospital.Application.UseCases.Cadastros.Medicos;
public class MedicoAddCrmDocUseCase
{
    private readonly IMedicoRepository _medicoRepository;
    private readonly IImageService _imageService;
    private readonly IUnitOfWork _uow;
    public MedicoAddCrmDocUseCase(
        IMedicoRepository medicoRepository,
        IImageService imageService,
        IUnitOfWork uow)
    {
        _medicoRepository = medicoRepository;
        _imageService = imageService;
        _uow = uow;
    }

    public async Task<Guid> Handler(Guid id, IFormFile image)
    {
        var medico = await _medicoRepository.GetByIdAsync(id);
        if (medico == null)
            throw new DomainException(
                $"Médico não encontrado: {id}",
                "Médico não encontrado");

        var imageId = _imageService.SaveMedicoDocCRM(image);
        medico.DocCRMPath = imageId;

        _medicoRepository.UpdateAsync(medico);
        await _uow.SaveAsync();

        return imageId;
    }
}