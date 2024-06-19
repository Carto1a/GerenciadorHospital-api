using Hospital.Application.Services;
using Hospital.Domain.Exceptions;
using Hospital.Domain.Repositories;

namespace Hospital.Application.UseCases.Laudos;
public class LaudoAddImageUseCase
{
    private readonly IImageService _imageService;
    private readonly ILaudoRepository _laudoRepository;
    private readonly IUnitOfWork _uow;

    public LaudoAddImageUseCase(
        IImageService imageService,
        ILaudoRepository laudoRepository,
        IUnitOfWork uow)
    {
        _imageService = imageService;
        _laudoRepository = laudoRepository;
        _uow = uow;
    }

    public async Task Handler(Guid id, IFormFile image)
    {
        var laudo = await _laudoRepository.GetByIdAsync(id);
        if (laudo == null)
            throw new DomainException(
                $"Laudo não encontrado: {id}",
                "Laudo não encontrado");

        var imageId = _imageService.SaveLaudoImage(image);
        laudo.DocPath = imageId;

        _laudoRepository.UpdateAsync(laudo);
        await _uow.SaveAsync();
    }
}