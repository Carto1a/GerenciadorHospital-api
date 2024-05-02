using Hospital.Enums;
using Hospital.Models.Medicamentos;

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
    DateTime Criado,
    MedicamentoStatus Status
)
{
    public MedicamentoOutputDto(Medicamento original)
    : this(
        original.Id,
        original.CodigoDeBarras,
        original.Nome,
        original.Descricao,
        original.Composicao,
        original.PrincipioAtivo,
        original.Preco,
        original.Quantidade,
        original.QuantidadeMinima,
        original.Criado,
        original.Status
    ) { }
}