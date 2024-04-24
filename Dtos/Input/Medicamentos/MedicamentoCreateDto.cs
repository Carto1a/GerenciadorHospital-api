using Hospital.Enums;

namespace Hospital.Dtos.Input.Medicamentos;
public record MedicamentoCreateDto(
    int CodigoDeBarras,
    string Nome,
    string Descricao,
    string Composicao,
    decimal Preco,
    MedicamentoStatus Status
);
