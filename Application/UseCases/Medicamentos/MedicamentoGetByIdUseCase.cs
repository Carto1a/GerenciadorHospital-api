using Hospital.Application.Dto.Output.Medicamentos;
using Hospital.Domain.Exceptions;
using Hospital.Domain.Repositories;

namespace Hospital.Application.UseCases.Medicamentos;
public class MedicamentoGetByIdUseCase
{
    private readonly ILogger<MedicamentoGetByIdUseCase> _logger;
    private readonly IMedicamentoRepository _medicamentoRepository;
    public MedicamentoGetByIdUseCase(
        ILogger<MedicamentoGetByIdUseCase> logger,
        IMedicamentoRepository medicamentoRepository)
    {
        _logger = logger;
        _medicamentoRepository = medicamentoRepository;
    }

    public async Task<MedicamentoOutputDto> Handler(
        Guid id)
    {
        _logger.LogInformation($"Buscando medicamento: {id}");
        var medicamento = await _medicamentoRepository
            .GetByIdDtoAsync(id);
        if (medicamento == null)
            throw new DomainException(
                $"Medicamento de id não existe, Não foi possivel buscar medicamento: {id}.",
                "Medicamento não encontrado.");

        _logger.LogInformation($"Medicamento encontrado: {id}");
        return medicamento;
    }
}