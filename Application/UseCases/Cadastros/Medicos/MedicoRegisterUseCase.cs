using Hospital.Dtos.Input.Authentications;
using Hospital.Exceptions;
using Hospital.Models.Cadastro;
using Hospital.Repository.Cadastros.Authentications.Interfaces;
using Hospital.Repository.Images.Interfaces;

namespace Hospital.Services.Cadastros.Medicos;
public class MedicoRegisterService
{
    private readonly ILogger<MedicoRegisterService> _logger;
    private readonly IAuthMedicoRepository _manager;
    private readonly IImageRepository _imageRepository;

    public MedicoRegisterService(
        ILogger<MedicoRegisterService> logger,
        IImageRepository imageRepository,
        IAuthMedicoRepository manager)
    {
        _manager = manager;
        _logger = logger;
        _imageRepository = imageRepository;
        _logger.LogDebug(1, $"NLog injected into MedicoRegisterService");
    }

    public async Task<string> Handler(
        RegisterRequestMedicoDto request)
    {
        _logger.LogInformation($"Registrando medico: {request.Email}");

        var findMedico = _manager
            .CheckIfCadastroExists(request);
        if (findMedico)
            throw new RequestError(
                $"Cadastro de medico já existe: {request.Email}",
                "Senha ou Email Inválidos");

        var medico = new Medico(request);
        if (request.DocCRMImg != null)
            medico.DocCRMPath = _imageRepository
                .SaveMedicoDocCRM(request.DocCRMImg);

        await _manager.CreateAsync(medico, request.Password);

        _logger.LogInformation($"Medico registrado: {medico.Id}");
        return $"/api/Medico/{medico.Id}";
    }
}