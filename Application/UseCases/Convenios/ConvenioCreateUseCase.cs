using Hospital.Dtos.Input.Convenios;
using Hospital.Exceptions;
using Hospital.Models.Cadastro;
using Hospital.Repository;
using Hospital.Repository.Convenios.Ineterfaces;

namespace Hospital.Services.Convenios;
public class ConvenioCreateService
{
    private readonly ILogger<ConvenioCreateService> _logger;
    private readonly UnitOfWork _uow;
    private readonly IConvenioRepository _convenioRepository;
    public ConvenioCreateService(
        ILogger<ConvenioCreateService> logger,
        UnitOfWork uow,
        IConvenioRepository convenioRepository)
    {
        _logger = logger;
        _uow = uow;
        _convenioRepository = convenioRepository;
    }

    public async Task<string> Handler(
        ConvenioCreateDto request)
    {
        _logger.LogInformation($"Criando convenio: {request.CNPJ}");
        var findConvenio = _convenioRepository
            .GetConvenioByCnpj(request.CNPJ);
        if (findConvenio != null)
            throw new RequestError(
                $"Convenio já existe: {request.CNPJ}",
                "Convenio já existe");

        var convenio = new Convenio(request);

        var entity = await _convenioRepository
            .CreateConvenioAsync(convenio);

        _logger.LogInformation($"Convenio criado: {request.CNPJ}");
        return $"/api/convenios/{entity}";
    }
}