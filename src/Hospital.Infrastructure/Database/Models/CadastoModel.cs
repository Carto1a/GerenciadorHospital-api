using System.Diagnostics.CodeAnalysis;

using Hospital.Domain.Entities.Cadastros;
using Hospital.Domain.Entities.ValueObjects;
using Hospital.Domain.Enums;

using Microsoft.AspNetCore.Identity;

namespace Hospital.Infrastructure.Database.Models;
public class CadastroModel : IdentityUser<Guid>, ICadastro
{
    public NomeCompleto NomeCompleto { get; set; }
    public DateOnly DataNascimento { get; set; }
    public GeneroEnum Genero { get; set; }
    public Telefone? Telefone { get; set; }
    public Cpf CPF { get; set; }
    public Endereco Endereco { get; set; }

    [SetsRequiredMembers]
    public CadastroModel() { }
}