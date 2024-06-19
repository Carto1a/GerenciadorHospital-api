using Hospital.Application.Dto.Input.Medicamentos;
using Hospital.Domain.Enums;
using Hospital.Domain.Exceptions;
using Hospital.Domain.Repositories;

namespace Hospital.Application.UseCases.Medicamentos;
public class MedicamentoWithdrawUseCase
{
    private readonly ILogger<MedicamentoWithdrawUseCase> _logger;
    private readonly IUnitOfWork _uow;
    private readonly IMedicamentoRepository _medicamentoRepository;
    private readonly IMedicamentoLoteRepository _medicamentoLoteRepository;
    public MedicamentoWithdrawUseCase(
        ILogger<MedicamentoWithdrawUseCase> logger,
        IUnitOfWork uow,
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
        var medicamentoLote = await _medicamentoLoteRepository
            .GetByCodigoByMedicamentoIdAsync(
                request.CodigoLote, id);
        if (medicamentoLote == null)
            throw new DomainException(
                $"Lote de medicamento não existe, Não foi possivel retirar medicamento: {id}.",
                "Lote de medicamento não encontrado.");

        if (medicamentoLote.Status == MedicamentoLoteStatus.Vencido)
            throw new DomainException(
                $"Lote de medicamento Vencido, Não foi possivel retirar medicamento: {id}.",
                "Lote de medicamento Vencido.");

        var medicamento = await _medicamentoRepository
            .GetByIdAsync(medicamentoLote.MedicamentoId);
        if (medicamento == null)
            throw new DomainException(
                $"Medicamento de id não existe, Não foi possivel retirar medicamento: {id}.",
                "Medicamento não encontrado.");

        if (request.Quantidade < 1)
            throw new DomainException(
                $"Quantidade de medicamento inválida, Não foi possivel retirar medicamento: {id}.",
                "Quantidade inválida.");

        if (medicamentoLote.Quantidade < request.Quantidade)
            throw new DomainException(
                $"Quantidade de medicamento insuficiente, Não foi possivel retirar medicamento: {id}.",
                "Quantidade insuficiente.");

        medicamentoLote.Quantidade -= request.Quantidade;
        medicamento.Quantidade -= request.Quantidade;
        medicamento.UpdateStatus();
        medicamentoLote.UpdateStatus();

        _medicamentoRepository.UpdateAsync(medicamento);
        _medicamentoLoteRepository.UpdateAsync(medicamentoLote);

        await _uow.SaveAsync();

        _logger.LogInformation($"Medicamento retirado: {id}");
    }
}