using Hospital.Domain.Enums;

namespace Hospital.Application.Dto.Input.Medicamentos;
public record MedicamentoLoteGetByQueryDto(
    Guid? MedicamentoId,
    DateTime? MinDateFabricacao,
    DateTime? MaxDateFabricacao,
    DateTime? MinDateVencimento,
    DateTime? MaxDateVencimento,
    string? Fabricante,
    int? QuantidadeDisponivel,
    int? Quantidade,
    decimal? PrecoUnitario,
    MedicamentoLoteStatus? Status) : GetByQueryDto
{ }