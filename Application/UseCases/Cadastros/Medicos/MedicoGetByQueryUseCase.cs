using Hospital.Dtos.Input.Authentications;
using Hospital.Dtos.Output.Cadastros;
using Hospital.Enums;
using Hospital.Repository;
using Hospital.Repository.Cadastros.Interfaces;
using Hospital.Services.Cadastros.Medicos;

namespace Hospital.Application.UseCases.Cadastros.Medicos;
public class MedicoGetByQueryUseCase
{
    private readonly ILogger<MedicoGetByQueryService> _logger;
    private readonly UnitOfWork _uow;
    private readonly IMedicoRepository _medicoRepository;
    public MedicoGetByQueryUseCase(
        ILogger<MedicoGetByQueryService> logger,
        UnitOfWork uow,
        IMedicoRepository medicoRepository)
    {
        _logger = logger;
        _uow = uow;
        _medicoRepository = medicoRepository;
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

        var medicos = _medicoRepository
            .GetMedicoByQueryDto(query);

        _logger.LogInformation($"Medicos encontrados: {medicos.Count}");
        return medicos;
    }
}