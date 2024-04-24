using Hospital.Enums;

namespace Hospital.Dtos.Output.Medicamentos;
public record MedicamentoLoteOutputDto(
    Guid Id,
    Guid MedicamentoId,
    string Codigo,
    DateOnly DataFabricacao,
    DateOnly DataVencimento,
    DateOnly DataCadastro,
    string Fabricante,
    int Quantidade,
    int QuantidadeDisponivel,
    decimal PrecoUnitario,
    MedicamentoLoteStatus Status
);