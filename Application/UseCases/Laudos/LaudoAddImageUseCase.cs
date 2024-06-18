using Hospital.Exceptions;
using Hospital.Infrastructure.Database.Repositories;
using Hospital.Repository.Images.Interfaces;

namespace Hospital.Application.UseCases.Laudos;
public class LaudoAddImageUseCase
{
    private readonly IImageRepository _imageRepository;
    private readonly ILaudoRepository _laudoRepository;
    private readonly UnitOfWork _uow;

    public LaudoAddImageUseCase(
        IImageRepository imageRepository,
        ILaudoRepository laudoRepository,
        UnitOfWork uow)
    {
        _imageRepository = imageRepository;
        _laudoRepository = laudoRepository;
        _uow = uow;
    }

    public async Task Handler(Guid id, IFormFile image)
    {
        var laudo = await _laudoRepository.GetByIdAsync(id);
        if (laudo == null)
            throw new RequestError(
                $"Laudo não encontrado: {id}",
                "Laudo não encontrado");

        var imageId = _imageRepository.SaveLaudoImage(image);
        laudo.DocPath = imageId;

        await _laudoRepository.Update(laudo);
    }
}