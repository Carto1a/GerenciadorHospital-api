using Hospital.Application.Dto.Output.Medicamentos;
using Hospital.Domain.Exceptions;
using Hospital.Domain.Repositories;

namespace Hospital.Application.UseCases.Medicamentos;
public class MedicamentoLoteGetByIdUseCase
{
    private readonly ILogger<MedicamentoLoteGetByIdUseCase> _logger;
    private readonly IMedicamentoLoteRepository _medicamentoLoteRepository;
    public MedicamentoLoteGetByIdUseCase(
        ILogger<MedicamentoLoteGetByIdUseCase> logger,
        IMedicamentoLoteRepository medicamentoLoteRepository)
    {
        _logger = logger;
        _medicamentoLoteRepository = medicamentoLoteRepository;
    }

    public async Task<MedicamentoLoteOutputDto> Handler(Guid id)
    {
        _logger.LogInformation($"Buscando medicamento lote: {id}");
        var medicamentoLote = await _medicamentoLoteRepository
            .GetByIdDtoAsync(id);
        if (medicamentoLote == null)
            throw new DomainException(
                $"Medicamento lote de id não existe, Não foi possivel buscar medicamento lote: {id}.",
                "Medicamento lote não encontrado.");

        _logger.LogInformation($"Medicamento lote encontrado: {id}");
        return medicamentoLote;
    }
}