namespace Hospital.Dtos.Output.Cadastros;
public record CadastroOutputDto
{
    public string Id { get; set; }
    string Email { get; set; }
    string Nome { get; set; }
    DateOnly DataNascimento { get; set; }
    bool Genero { get; set; }
    string? Telefone { get; set; }
    int CPF { get; set; }
    int CEP { get; set; }
    string? NumeroCasa { get; set; }

    public CadastroOutputDto(
        string id,
        string email,
        string nome,
        DateOnly dataNascimento,
        bool genero,
        string? telefone,
        int cPF,
        int cEP,
        string? numeroCasa)
    {
        Id = id;
        Email = email;
        Nome = nome;
        DataNascimento = dataNascimento;
        Genero = genero;
        Telefone = telefone;
        CPF = cPF;
        CEP = cEP;
        NumeroCasa = numeroCasa;
    }
};