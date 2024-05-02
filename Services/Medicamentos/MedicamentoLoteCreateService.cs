using Hospital.Database;
using Hospital.Dtos.Input.Medicamentos;
using Hospital.Enums;
using Hospital.Exceptions;
using Hospital.Models.Medicamentos;
using Hospital.Repository;

namespace Hospital.Services.Medicamentos;
public class MedicamentoLoteCreateService
{
    private readonly ILogger<MedicamentoLoteCreateService> _logger;
    private readonly AppDbContext _context;
    private readonly UnitOfWork _uow;
    public MedicamentoLoteCreateService(
        ILogger<MedicamentoLoteCreateService> logger,
        AppDbContext context,
        UnitOfWork uow)
    {
        _logger = logger;
        _context = context;
        _uow = uow;
    }

    public string Handler(
        MedicamentoLoteCreateDto request)
    {
        _logger.LogInformation($"Criando lote de medicamento: {request.Codigo}");
        var medicamento = _uow.MedicamentoRepository
            .GetMedicamentoById(request.MedicamentoId);
        if (medicamento == null)
            throw new RequestError(
                $"Medicamento de id não existe, Não foi possivel criar lote: {request.MedicamentoId}.",
                "Medicamento não encontrado.");

        var medicamentoLote = new MedicamentoLote(request);
        var entity = _uow.MedicamentoLoteRepository
            .CreateMedicamentoLote(medicamentoLote);

        if (medicamentoLote.Status != MedicamentoLoteStatus.Vencido)
            medicamento.Quantidade += medicamentoLote.Quantidade;

        medicamento.UpdateStatus();
        _uow.MedicamentoRepository.UpdateMedicamento(medicamento);
        _uow.Save();

        _logger.LogInformation($"Lote de medicamento criado: {request.Codigo}");
        return $"/api/medicamentos/lotes/{entity}";
    }
}