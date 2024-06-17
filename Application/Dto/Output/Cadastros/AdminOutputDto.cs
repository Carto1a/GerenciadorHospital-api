using Hospital.Domain.Enums;

namespace Hospital.Application.Dto.Output.Cadastros;
public class AdminOutputDto
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

    public AdminOutputDto(Admin admin)
    {
        Id = admin.Id;
        Email = admin.Email!;
        Nome = admin.Nome;
        DataNascimento = admin.DataNascimento;
        Genero = admin.Genero;
        Telefone = admin.Telefone;
        CPF = admin.CPF;
        CEP = admin.CEP;
        NumeroCasa = admin.NumeroCasa;
        Ativo = admin.Ativo;
    }
}