namespace Hospital.Application.UseCases.Cadastros.Pacientes;
public class PacienteRegisterUseCase
{
    private readonly ILogger<PacienteLoginService> _logger;
    private readonly IAuthPacienteRepository _manager;
    private readonly IImageRepository _imageRepository;
    private readonly UnitOfWork _uow;
    private readonly IConvenioRepository _convenioRepository;

    public PacienteRegisterUseCase(
        ILogger<PacienteLoginService> logger,
        IAuthPacienteRepository manager,
        IImageRepository imageRepository,
        UnitOfWork uow,
        IConvenioRepository convenioRepository)
    {
        _manager = manager;
        _logger = logger;
        _imageRepository = imageRepository;
        _uow = uow;
        _convenioRepository = convenioRepository;
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
            var convenio = _convenioRepository
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
        else
            throw new RequestError(
                "Documento de Identificação é obrigatório",
                "Documento de Identificação é obrigatório");

        if (request.ConvenioId != null && request.DocConvenioImg == null)
            throw new RequestError(
                "Documento do Convênio não informado",
                "Documento do Convênio não informado");

        if (request.ConvenioId != null && request.DocConvenioImg != null)
            paciente.DocConvenioPath = _imageRepository
                .SaveDocConvenio(request.DocConvenioImg);

        await _manager.CreateAsync(paciente, request.Password);

        _logger.LogInformation($"Paciente registrado: {paciente.Id}");
        return $"/api/Paciente/{paciente.Id}";
    }
}