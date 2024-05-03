using Hospital.Dtos.Input.Authentications;
using Hospital.Dtos.Output.Cadastros;
using Hospital.Enums;
using Hospital.Repository;

namespace Hospital.Services.Cadastros.Medicos;
public class MedicoGetByQueryService
{
    private readonly ILogger<MedicoGetByQueryService> _logger;
    private readonly UnitOfWork _uow;
    public MedicoGetByQueryService(
        ILogger<MedicoGetByQueryService> logger,
        UnitOfWork uow)
    {
        _logger = logger;
        _uow = uow;
    }

    public List<MedicoOutputDto> Handler(
        MedicoGetByQueryDto query)
    {
        _logger.LogInformation($"Buscando medicos: {query.Limit} - {query.Page}");

        var validator = new Validators("Não foi possível buscar medicos");
        validator.Query((int)query.Limit!, (int)query.Page!);

        if (query.Genero != null)
            validator.isInEnum(
                query.Genero,
                typeof(GeneroEnum),
                "Genero inválido");

        // NOTE: break code execution if validation fails
        validator.Check();

        var medicos = _uow.MedicoRepository
            .GetMedicoByQueryDto(query);

        _logger.LogInformation($"Medicos encontrados: {medicos.Count}");
        return medicos;
    }
}