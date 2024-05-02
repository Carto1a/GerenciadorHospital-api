using Hospital.Dtos.Output.Medicamentos;
using Hospital.Exceptions;
using Hospital.Repository;

namespace Hospital.Services.Medicamentos;
public class MedicamentoGetByIdService
{
    private readonly ILogger<MedicamentoGetByIdService> _logger;
    private readonly UnitOfWork _uow;
    public MedicamentoGetByIdService(
        ILogger<MedicamentoGetByIdService> logger,
        UnitOfWork uow)
    {
        _logger = logger;
        _uow = uow;
    }

    public MedicamentoOutputDto Handler(
        Guid id)
    {
        _logger.LogInformation($"Buscando medicamento: {id}");
        var medicamento = _uow.MedicamentoRepository
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