using Hospital.Dtos.Output.Medicamentos;
using Hospital.Exceptions;
using Hospital.Repository;
using Hospital.Repository.Medicamentos.Interfaces;

namespace Hospital.Application.UseCases.Medicamentos;
public class MedicamentoGetByIdUseCase
{
    private readonly ILogger<MedicamentoGetByIdUseCase> _logger;
    private readonly UnitOfWork _uow;
    private readonly IMedicamentoRepository _medicamentoRepository;
    public MedicamentoGetByIdUseCase(
        ILogger<MedicamentoGetByIdUseCase> logger,
        UnitOfWork uow,
        IMedicamentoRepository medicamentoRepository)
    {
        _logger = logger;
        _uow = uow;
        _medicamentoRepository = medicamentoRepository;
    }

    public MedicamentoOutputDto Handler(
        Guid id)
    {
        _logger.LogInformation($"Buscando medicamento: {id}");
        var medicamento = _medicamentoRepository
            .GetMedicamentoByIdDto(id);
        if (medicamento == null)
            throw new RequestError(
                $"Medicamento de id não existe, Não foi possivel buscar medicamento: {id}.",
                "Medicamento não encontrado.",
                StatusCodes.Status404NotFound);

        _logger.LogInformation($"Medicamento encontrado: {id}");
        return medicamento;
    }
}