using Hospital.Enums;

namespace Hospital.Dtos.Output.Cadastros;
public record CadastroOutputDto
{
    public string Id { get; set; }
    string Email { get; set; }
    string Nome { get; set; }
    DateOnly DataNascimento { get; set; }
    GeneroEnum Genero { get; set; }
    string? Telefone { get; set; }
    int CPF { get; set; }
    int CEP { get; set; }
    string? NumeroCasa { get; set; }
    bool Ativo { get; set; }

    public CadastroOutputDto(
        string id,
        string email,
        string nome,
        DateOnly dataNascimento,
        GeneroEnum genero,
        string? telefone,
        int cpf,
        int cep,
        string? numeroCasa)
    {
        Id = id;
        Email = email;
        Nome = nome;
        DataNascimento = dataNascimento;
        Genero = genero;
        Telefone = telefone;
        CPF = cpf;
        CEP = cep;
        NumeroCasa = numeroCasa;
    }
};