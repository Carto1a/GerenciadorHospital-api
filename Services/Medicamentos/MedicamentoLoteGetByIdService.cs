using Hospital.Dtos.Output.Medicamentos;
using Hospital.Exceptions;
using Hospital.Repository;

namespace Hospital.Services.Medicamentos;
public class MedicamentoLoteGetByIdService
{
    private readonly ILogger<MedicamentoLoteGetByIdService> _logger;
    private readonly UnitOfWork _uow;
    public MedicamentoLoteGetByIdService(
        ILogger<MedicamentoLoteGetByIdService> logger,
        UnitOfWork uow)
    {
        _logger = logger;
        _uow = uow;
    }

    public MedicamentoLoteOutputDto Handler(
        Guid id)
    {
        _logger.LogInformation($"Buscando medicamento lote: {id}");
        var medicamentoLote = _uow.MedicamentoLoteRepository
            .GetMedicamentoLoteByIdDto(id);
        if (medicamentoLote == null)
            throw new RequestError(
                $"Medicamento lote de id não existe, Não foi possivel buscar medicamento lote: {id}.",
                "Medicamento lote não encontrado.",
                StatusCodes.Status404NotFound);

        _logger.LogInformation($"Medicamento lote encontrado: {id}");
        return medicamentoLote;
    }
}