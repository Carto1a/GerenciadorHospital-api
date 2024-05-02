using Hospital.Dtos.Input.Medicamentos;
using Hospital.Enums;
using Hospital.Exceptions;
using Hospital.Repository;

namespace Hospital.Services.Medicamentos;
public class MedicamentoWithdrawService
{
    private readonly ILogger<MedicamentoWithdrawService> _logger;
    private readonly UnitOfWork _uow;
    public MedicamentoWithdrawService(
        ILogger<MedicamentoWithdrawService> logger,
        UnitOfWork uow)
    {
        _logger = logger;
        _uow = uow;
    }

    public void Handler(
        Guid id,
        MedicamentoWithdrawDto request)
    {
        _logger.LogInformation($"Retirando medicamento: {id} do lote: {request.CodigoLote}");
        var medicamentoLote = _uow.MedicamentoLoteRepository
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

        var medicamento = _uow.MedicamentoRepository
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

        _uow.MedicamentoRepository.UpdateMedicamento(medicamento);
        _uow.MedicamentoLoteRepository.UpdateMedicamentoLote(medicamentoLote);
        _uow.Save();

        _logger.LogInformation($"Medicamento retirado: {id}");
    }
}