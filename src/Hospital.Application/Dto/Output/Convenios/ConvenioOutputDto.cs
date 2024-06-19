using Hospital.Domain.Entities;

namespace Hospital.Application.Dto.Output.Convenios;
public record ConvenioOutputDto(
    Guid Id,
    string? CNPJ,
    string? CEP,
    string? Numero,
    string? Nome,
    string? Descrição,
    decimal Desconto,
    string? Telefone,
    string? Email,
    string? Site,
    DateTime Criado,
    bool Ativo
)
{
    public ConvenioOutputDto(Convenio original)
    : this(
        original.Id,
        original.CNPJ,
        original.CEP,
        original.Numero,
        original.Nome,
        original.Descrição,
        original.Desconto,
        original.Telefone,
        original.Email,
        original.Site,
        original.Criado,
        original.Ativo
    )
    { }
}