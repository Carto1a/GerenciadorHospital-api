using Hospital.Enums;

namespace Hospital.Dtos.Input.Medicamentos;
public record MedicamentoLoteGetByQueryDto(
    Guid? MedicamentoId,
    DateOnly? MinDateFabricacao,
    DateOnly? MaxDateFabricacao,
    DateOnly? MinDateVencimento,
    DateOnly? MaxDateVencimento,
    DateOnly? MinDateCadastro,
    DateOnly? MaxDateCadastro,
    string? Fabricante,
    int? QuantidadeDisponivel,
    int? Quantidade,
    decimal? PrecoUnitario,
    MedicamentoLoteStatus? Status)
{
    public int? Page { get; set; } = 0;
    public int? Limit { get; set; } = 1;
}