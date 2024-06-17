using Hospital.Dtos.Output.Medicamentos;
using Hospital.Exceptions;
using Hospital.Repository;
using Hospital.Repository.MedicamentoLotes.Interfaces;

namespace Hospital.Services.Medicamentos;
public class MedicamentoLoteGetByIdService
{
    private readonly ILogger<MedicamentoLoteGetByIdService> _logger;
    private readonly UnitOfWork _uow;
    private readonly IMedicamentoLoteRepository _medicamentoLoteRepository;
    public MedicamentoLoteGetByIdService(
        ILogger<MedicamentoLoteGetByIdService> logger,
        UnitOfWork uow,
        IMedicamentoLoteRepository medicamentoLoteRepository)
    {
        _logger = logger;
        _uow = uow;
        _medicamentoLoteRepository = medicamentoLoteRepository;
    }

    public MedicamentoLoteOutputDto Handler(
        Guid id)
    {
        _logger.LogInformation($"Buscando medicamento lote: {id}");
        var medicamentoLote = _medicamentoLoteRepository
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