using Hospital.Application.Services;
using Hospital.Domain.Exceptions;
using Hospital.Domain.Repositories.Cadastros;

namespace Hospital.Application.UseCases.Cadastros.Medicos;
public class MedicoGetDocCrmUseCase
{
    private readonly IMedicoRepository _medicoRepository;
    private readonly IImageService _imageService;
    public MedicoGetDocCrmUseCase(
        IMedicoRepository medicoRepository,
        IImageService imageService)
    {
        _medicoRepository = medicoRepository;
        _imageService = imageService;
    }

    public async Task<Stream> Handler(Guid id)
    {
        var medico = await _medicoRepository.GetByIdAsync(id);
        if (medico == null)
            throw new DomainException("Médico não encontrado");

        var docCrmName = medico.DocCRMPath;
        if (docCrmName == null)
            throw new DomainException("Documento CRM não encontrado");

        var stream = _imageService.GetMedicoDocCRMPath((Guid)docCrmName);
        return stream;
    }
}