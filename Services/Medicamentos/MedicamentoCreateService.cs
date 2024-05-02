using Hospital.Dtos.Input.Medicamentos;
using Hospital.Models.Medicamentos;
using Hospital.Repository;

namespace Hospital.Services.Medicamentos;
public class MedicamentoCreateService
{
    private readonly ILogger<MedicamentoCreateService> _logger;
    private readonly UnitOfWork _uow;
    public MedicamentoCreateService(
        ILogger<MedicamentoCreateService> logger,
        UnitOfWork uow)
    {
        _logger = logger;
        _uow = uow;
    }

    public async Task<string> Handler(
        MedicamentoCreateDto request)
    {
        _logger.LogInformation($"Criando medicamento: {request.Nome}");
        var medicamento = new Medicamento(request);
        medicamento.UpdateStatus();

        var entity = await _uow.MedicamentoRepository
            .CreateMedicamentoAsync(medicamento);

        _logger.LogInformation($"Medicamento criado: {request.Nome}");
        return $"/api/medicamentos/{entity}";
    }
}