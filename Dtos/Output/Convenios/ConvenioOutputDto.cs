namespace Hospital.Dtos.Output.Convenios;
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
    bool Deletado
);