namespace Hospital.Dtos.Input.Medicamentos;
public record MedicamentoLoteCreateDto(
    Guid MedicamentoId,
    string Codigo,
    DateTime DataFabricacao,
    DateTime DataVencimento,
    string Fabricante,
    int Quantidade,
    int QuantidadeDisponivel,
    decimal PrecoUnitario
);