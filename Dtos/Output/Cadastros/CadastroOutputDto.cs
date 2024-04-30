using Hospital.Enums;
using Hospital.Models.Cadastro;

namespace Hospital.Dtos.Output.Cadastros;
public class CadastroOutputDto
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string Nome { get; set; }
    public DateOnly DataNascimento { get; set; }
    public GeneroEnum Genero { get; set; }
    public long? Telefone { get; set; }
    public string CPF { get; set; }
    public string CEP { get; set; }
    public string? NumeroCasa { get; set; }
    public bool Ativo { get; set; }

    public CadastroOutputDto(
        Cadastro cadastro)
    {
        Id = cadastro.Id;
        Email = cadastro.Email!;
        Nome = cadastro.Nome;
        DataNascimento = cadastro.DataNascimento;
        Genero = cadastro.Genero;
        Telefone = cadastro.Telefone;
        CPF = cadastro.CPF;
        CEP = cadastro.CEP;
        NumeroCasa = cadastro.NumeroCasa;
    }
};