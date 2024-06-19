using Hospital.Domain.Enums;

namespace Hospital.Application.Dto.Input.Medicamentos;
public record MedicamentoCreateDto(
    int CodigoDeBarras,
    string Nome,
    string Descricao,
    string Composicao,
    string PrincipioAtivo,
    decimal Preco,
    int QuantidadeMinima,
    MedicamentoStatus Status
);