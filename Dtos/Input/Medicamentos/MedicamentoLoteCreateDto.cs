namespace Hospital.Dtos.Input.Medicamentos;
public record MedicamentoLoteCreateDto(
    Guid MedicamentoId,
    string Codigo,
    DateOnly DataFabricacao,
    DateOnly DataVencimento,
    DateOnly DataCadastro,
    string Fabricante,
    int Quantidade,
    decimal PrecoUnitario
);