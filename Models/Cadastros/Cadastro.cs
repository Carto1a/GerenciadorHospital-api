using Microsoft.AspNetCore.Identity;

namespace Hospital.Models.Cadastro;
public class Cadastro : IdentityUser<Guid>
{
    public string Nome { get; set; }
    public DateOnly DataNascimento { get; set; }
    public bool Genero { get; set; }
    public string? Telefone { get; set; }
    public int Cpf { get; set; }
    public int Cep { get; set; }
    public string? NumeroCasa { get; set; }
}