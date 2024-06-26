using Hospital.Application.Dto.Input.Authentications;
using Hospital.Application.Services;
using Hospital.Domain.Entities.Cadastros;
using Hospital.Domain.Exceptions;
using Hospital.Domain.Repositories.Cadastros.Authentications;

namespace Hospital.Application.UseCases.Cadastros.Medicos;
public class MedicoRegisterUseCase
{
    private readonly ILogger<MedicoRegisterUseCase> _logger;
    private readonly IAuthMedicoRepository _manager;
    private readonly IImageService _imageService;

    public MedicoRegisterUseCase(
        ILogger<MedicoRegisterUseCase> logger,
        IAuthMedicoRepository manager,
        IImageService imageService)
    {
        _logger = logger;
        _manager = manager;
        _imageService = imageService;
    }

    public async Task<Guid> Handler(
        RegisterRequestMedicoDto request)
    {
        _logger.LogInformation($"Registrando medico: {request.Email}");

        var findMedico = await _manager
            .CheckIfCadastroExistsAsync(request);
        if (findMedico)
            throw new DomainException(
                $"Cadastro de medico já existe: {request.Email}",
                "Senha ou Email Inválidos");

        var medico = new Medico(request);
        if (request.DocCRMImg != null)
            medico.DocCRMPath = _imageService
                .SaveMedicoDocCRM(request.DocCRMImg);

        await _manager.CreateAsync(medico, request.Password);

        _logger.LogInformation($"Medico registrado: {medico.Id}");

        return medico.Id;
    }
}