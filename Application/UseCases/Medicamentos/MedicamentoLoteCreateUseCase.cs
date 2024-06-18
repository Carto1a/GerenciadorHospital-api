using Hospital.Dtos.Input.Medicamentos;
using Hospital.Enums;
using Hospital.Exceptions;
using Hospital.Infrastructure.Database;
using Hospital.Infrastructure.Database.Repositories;
using Hospital.Models.Medicamentos;
using Hospital.Repository.MedicamentoLotes.Interfaces;
using Hospital.Repository.Medicamentos.Interfaces;

namespace Hospital.Application.UseCases.Medicamentos;
public class MedicamentoLoteCreateUseCase
{
    private readonly ILogger<MedicamentoLoteCreateUseCase> _logger;
    private readonly AppDbContext _context;
    private readonly UnitOfWork _uow;
    private readonly IMedicamentoRepository _medicamentoRepository;
    private readonly IMedicamentoLoteRepository _medicamentoLoteRepository;
    public MedicamentoLoteCreateUseCase(
        ILogger<MedicamentoLoteCreateUseCase> logger,
        AppDbContext context,
        UnitOfWork uow,
        IMedicamentoRepository medicamentoRepository,
        IMedicamentoLoteRepository medicamentoLoteRepository)
    {
        _logger = logger;
        _context = context;
        _uow = uow;
        _medicamentoRepository = medicamentoRepository;
        _medicamentoLoteRepository = medicamentoLoteRepository;
    }

    public async Task<string> Handler(
        MedicamentoLoteCreateDto request)
    {
        _logger.LogInformation($"Criando lote de medicamento: {request.Codigo}");
        var medicamento = _medicamentoRepository
            .GetMedicamentoById(request.MedicamentoId);
        if (medicamento == null)
            throw new RequestError(
                $"Medicamento de id não existe, Não foi possivel criar lote: {request.MedicamentoId}.",
                "Medicamento não encontrado.");

        var medicamentoLote = new MedicamentoLote(request);
        var entity = _medicamentoLoteRepository
            .CreateMedicamentoLote(medicamentoLote);

        if (medicamentoLote.Status != MedicamentoLoteStatus.Vencido)
            medicamento.Quantidade += medicamentoLote.Quantidade;

        medicamento.UpdateStatus();
        _medicamentoRepository.UpdateMedicamento(medicamento);
        await _uow.SaveAsync();

        _logger.LogInformation($"Lote de medicamento criado: {request.Codigo}");
        return $"/api/medicamentos/lotes/{entity}";
    }
}