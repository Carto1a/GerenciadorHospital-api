using Hospital.Dtos.Input.Medicamentos;
using Hospital.Models.Medicamentos;
using Hospital.Repository;
using Hospital.Repository.Medicamentos.Interfaces;

namespace Hospital.Application.UseCases.Medicamentos;
public class MedicamentoCreateUseCase
{
    private readonly ILogger<MedicamentoCreateUseCase> _logger;
    private readonly UnitOfWork _uow;
    private readonly IMedicamentoRepository _medicamentoRepository;
    public MedicamentoCreateUseCase(
        ILogger<MedicamentoCreateUseCase> logger,
        UnitOfWork uow,
        IMedicamentoRepository medicamentoRepository)
    {
        _logger = logger;
        _uow = uow;
        _medicamentoRepository = medicamentoRepository;
    }

    public async Task<string> Handler(
        MedicamentoCreateDto request)
    {
        _logger.LogInformation($"Criando medicamento: {request.Nome}");
        var medicamento = new Medicamento(request);
        medicamento.UpdateStatus();

        var entity = await _medicamentoRepository
            .CreateMedicamentoAsync(medicamento);

        _logger.LogInformation($"Medicamento criado: {request.Nome}");
        return $"/api/medicamentos/{entity}";
    }
}