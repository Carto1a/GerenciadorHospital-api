using Hospital.Domain.Enums;

namespace Hospital.Application.Dto.Output.Medicamentos;
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
    )
    { }
}