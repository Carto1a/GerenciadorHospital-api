using Hospital.Domain.Enums;

namespace Hospital.Application.Dto.Output.Medicamentos;
public record MedicamentoLoteOutputDto(
    Guid Id,
    Guid MedicamentoId,
    string Codigo,
    DateOnly DataFabricacao,
    DateOnly DataVencimento,
    DateTime DataCadastro,
    string Fabricante,
    int Quantidade,
    int QuantidadeDisponivel,
    decimal PrecoUnitario,
    MedicamentoLoteStatus Status
)
{
    public MedicamentoLoteOutputDto(MedicamentoLote original)
    : this(
        original.Id,
        original.MedicamentoId,
        original.Codigo,
        original.DataFabricacao,
        original.DataVencimento,
        original.DataCadastro,
        original.Fabricante,
        original.Quantidade,
        original.QuantidadeDisponivel,
        original.PrecoUnitario,
        original.Status
    )
    { }
}