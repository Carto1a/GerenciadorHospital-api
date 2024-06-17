using Hospital.Dtos.Input.Medicamentos;
using Hospital.Enums;
using Hospital.Exceptions;
using Hospital.Repository;
using Hospital.Repository.MedicamentoLotes.Interfaces;
using Hospital.Repository.Medicamentos.Interfaces;

namespace Hospital.Application.UseCases.Medicamentos;
public class MedicamentoWithdrawUseCase
{
    private readonly ILogger<MedicamentoWithdrawUseCase> _logger;
    private readonly UnitOfWork _uow;
    private readonly IMedicamentoRepository _medicamentoRepository;
    private readonly IMedicamentoLoteRepository _medicamentoLoteRepository;
    public MedicamentoWithdrawUseCase(
        ILogger<MedicamentoWithdrawUseCase> logger,
        UnitOfWork uow,
        IMedicamentoRepository medicamentoRepository,
        IMedicamentoLoteRepository medicamentoLoteRepository)
    {
        _logger = logger;
        _uow = uow;
        _medicamentoRepository = medicamentoRepository;
        _medicamentoLoteRepository = medicamentoLoteRepository;
    }

    public async Task Handler(
        Guid id,
        MedicamentoWithdrawDto request)
    {
        _logger.LogInformation($"Retirando medicamento: {id} do lote: {request.CodigoLote}");
        var medicamentoLote = _medicamentoLoteRepository
            .GetMedicamentoLoteByCodigoByMedicamentoId(
                request.CodigoLote, id);
        if (medicamentoLote == null)
            throw new RequestError(
                $"Lote de medicamento não existe, Não foi possivel retirar medicamento: {id}.",
                "Lote de medicamento não encontrado.");

        if (medicamentoLote.Status == MedicamentoLoteStatus.Vencido)
            throw new RequestError(
                $"Lote de medicamento Vencido, Não foi possivel retirar medicamento: {id}.",
                "Lote de medicamento Vencido.");

        var medicamento = _medicamentoRepository
            .GetMedicamentoById(medicamentoLote.MedicamentoId);
        if (medicamento == null)
            throw new RequestError(
                $"Medicamento de id não existe, Não foi possivel retirar medicamento: {id}.",
                "Medicamento não encontrado.");

        if (request.Quantidade < 1)
            throw new RequestError(
                $"Quantidade de medicamento inválida, Não foi possivel retirar medicamento: {id}.",
                "Quantidade inválida.");

        if (medicamentoLote.Quantidade < request.Quantidade)
            throw new RequestError(
                $"Quantidade de medicamento insuficiente, Não foi possivel retirar medicamento: {id}.",
                "Quantidade insuficiente.");

        medicamentoLote.Quantidade -= request.Quantidade;
        medicamento.Quantidade -= request.Quantidade;
        medicamento.UpdateStatus();
        medicamentoLote.UpdateStatus();

        _medicamentoRepository.UpdateMedicamento(medicamento);
        _medicamentoLoteRepository.UpdateMedicamentoLote(medicamentoLote);
        await _uow.SaveAsync();

        _logger.LogInformation($"Medicamento retirado: {id}");
    }
}