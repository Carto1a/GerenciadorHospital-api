using Hospital.Application.Dto.Input.Authentications;
using Hospital.Application.Services;
using Hospital.Domain.Entities.Cadastros;
using Hospital.Domain.Exceptions;
using Hospital.Domain.Repositories;
using Hospital.Domain.Repositories.Cadastros.Authentications;

namespace Hospital.Application.UseCases.Cadastros.Pacientes;
public class PacienteRegisterUseCase
{
    private readonly ILogger<PacienteLoginUseCase> _logger;
    private readonly IAuthPacienteRepository _manager;
    private readonly IImageService _imageService;
    private readonly IUnitOfWork _uow;
    private readonly IConvenioRepository _convenioRepository;

    public PacienteRegisterUseCase(
        ILogger<PacienteLoginUseCase> logger,
        IAuthPacienteRepository manager,
        IImageService imageRepository,
        IUnitOfWork uow,
        IConvenioRepository convenioRepository)
    {
        _manager = manager;
        _logger = logger;
        _imageService = imageRepository;
        _uow = uow;
        _convenioRepository = convenioRepository;
    }

    public async Task<Guid> Handler(
        RegisterRequestPacienteDto request)
    {
        _logger.LogInformation($"Registrando Paciente: {request.Email}");

        var findPaciente = await _manager
            .CheckIfCadastroExistsAsync(request);
        if (findPaciente)
            throw new DomainException(
                $"Cadastro de Paciente já existe: {request.Email}",
                "Senha ou Email Inválidos");

        if (request.ConvenioId != null)
        {
            var convenio = await _convenioRepository
                .GetByIdAsync((Guid)request.ConvenioId);
            if (convenio == null)
                throw new DomainException(
                    $"Convenio não existe: {request.ConvenioId}",
                    "Convenio não existe");
        }

        var paciente = new Paciente(request);
        if (request.DocIDImg != null)
            paciente.DocIDPath = _imageService
                .SavePacienteDocId(request.DocIDImg);
        else
            throw new DomainException(
                "Documento de Identificação é obrigatório",
                "Documento de Identificação é obrigatório");

        if (request.ConvenioId != null && request.DocConvenioImg == null)
            throw new DomainException(
                "Documento do Convênio não informado",
                "Documento do Convênio não informado");

        if (request.ConvenioId != null && request.DocConvenioImg != null)
            paciente.DocConvenioPath = _imageService
                .SavePacienteDocConvenio(request.DocConvenioImg);

        await _manager.CreateAsync(paciente, request.Password);

        _logger.LogInformation($"Paciente registrado: {paciente.Id}");
        await _uow.SaveAsync();

        return paciente.Id;
    }
}