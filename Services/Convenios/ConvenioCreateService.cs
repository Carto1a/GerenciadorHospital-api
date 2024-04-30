using Hospital.Dtos.Input.Convenios;
using Hospital.Exceptions;
using Hospital.Models.Cadastro;
using Hospital.Repository;

namespace Hospital.Services.Convenios;
public class ConvenioCreateService
{
    private readonly ILogger<ConvenioCreateService> _logger;
    private readonly UnitOfWork _uow;
    public ConvenioCreateService(
        ILogger<ConvenioCreateService> logger,
        UnitOfWork uow)
    {
        _logger = logger;
        _uow = uow;
    }

    public async Task<string> Handler(
        ConvenioCreateDto request)
    {
        _logger.LogInformation($"Criando convenio: {request.CNPJ}");
        var findConvenio = _uow.ConvenioRepository
            .GetConvenioByCnpj(request.CNPJ);
        if (findConvenio != null)
            throw new RequestError(
                $"Convenio já existe: {request.CNPJ}",
                "Convenio já existe");

        var convenio = new Convenio(request);

        var entity = await _uow.ConvenioRepository
            .CreateConvenioAsync(convenio);

        _logger.LogInformation($"Convenio criado: {request.CNPJ}");
        return $"/api/convenios/{entity}";
    }
}