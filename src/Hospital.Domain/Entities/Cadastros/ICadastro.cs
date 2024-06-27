using Hospital.Domain.Entities.ValueObjects;
using Hospital.Domain.Enums;

namespace Hospital.Domain.Entities.Cadastros;
public interface ICadastro
{
    public NomeCompleto NomeCompleto { get; set; }
    public DateOnly DataNascimento { get; set; }
    public GeneroEnum Genero { get; set; }
    public Telefone? Telefone { get; set; }
    public Cpf CPF { get; set; }
    public Endereco Endereco { get; set; }
}