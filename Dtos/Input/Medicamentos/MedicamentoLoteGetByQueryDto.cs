using Hospital.Enums;

namespace Hospital.Dtos.Input.Medicamentos;
public record MedicamentoLoteGetByQueryDto(
    Guid? MedicamentoId,
    DateTime? MinDateFabricacao,
    DateTime? MaxDateFabricacao,
    DateTime? MinDateVencimento,
    DateTime? MaxDateVencimento,
    DateTime? MinDateCadastro,
    DateTime? MaxDateCadastro,
    string? Fabricante,
    int? QuantidadeDisponivel,
    int? Quantidade,
    decimal? PrecoUnitario,
    MedicamentoLoteStatus? Status)
{
    public int? Page { get; set; } = 0;
    public int? Limit { get; set; } = 1;
}