using Hospital.Enums;

namespace Hospital.Dtos.Output.Medicamentos;
public record MedicamentoOutputDto(
    Guid Id,
    int CodigoDeBarras,
    string Nome,
    string Descricao,
    string Composicao,
    string PrincipioAtivo,
    decimal Preco,
    int Quantidade,
    int QuantidadeMinima,
    DateOnly Criado,
    MedicamentoStatus Status
);