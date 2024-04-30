using Hospital.Dtos.Input.Authentications;
using Hospital.Exceptions;
using Hospital.Models.Cadastro;
using Hospital.Repository;
using Hospital.Repository.Cadastros.Authentications.Interfaces;
using Hospital.Repository.Images.Interfaces;

namespace Hospital.Services.Cadastros.Pacientes;
public class PacienteRegisterService
{
    private readonly ILogger<PacienteLoginService> _logger;
    private readonly IAuthPacienteRepository _manager;
    private readonly IImageRepository _imageRepository;
    private readonly UnitOfWork _uow;

    public PacienteRegisterService(
        ILogger<PacienteLoginService> logger,
        IAuthPacienteRepository manager,
        IImageRepository imageRepository,
        UnitOfWork uow)
    {
        _manager = manager;
        _logger = logger;
        _imageRepository = imageRepository;
        _uow = uow;
        _logger.LogDebug(1, $"NLog injected into PacienteLoginService");
    }

    public async Task<string> Handler(
        RegisterRequestPacienteDto request)
    {
        _logger.LogInformation($"Registrando Paciente: {request.Email}");

        var findPaciente = _manager
            .CheckIfCadastroExists(request);
        if (findPaciente)
            throw new RequestError(
                $"Cadastro de Paciente já existe: {request.Email}",
                "Senha ou Email Inválidos");

        if (request.ConvenioId != null)
        {
            var convenio = _uow.ConvenioRepository
                .GetConvenioById((Guid)request.ConvenioId);
            if (convenio == null)
                throw new RequestError(
                    $"Convenio não existe: {request.ConvenioId}",
                    "Convenio não existe");
        }

        var paciente = new Paciente(request);
        if (request.DocIDImg != null)
            paciente.DocIDPath = _imageRepository
                .SaveDocID(request.DocIDImg);

        if (request.ConvenioId != null && request.DocConvenioImg != null)
            paciente.DocConvenioPath = _imageRepository
                .SaveDocConvenio(request.DocConvenioImg);

        await _manager.CreateAsync(paciente, request.Password);

        _logger.LogInformation($"Paciente registrado: {paciente.Id}");
        return $"/api/Paciente/{paciente.Id}";
    }
}