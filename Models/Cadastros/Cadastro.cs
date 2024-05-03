using System.Diagnostics.CodeAnalysis;

using FluentResults;

using Hospital.Dtos.Input.Authentications;
using Hospital.Enums;

using Microsoft.AspNetCore.Identity;

namespace Hospital.Models.Cadastro;
public class Cadastro
: IdentityUser<Guid>
{
    public required string Nome { get; set; }
    public required string Sobrenome { get; set; }
    public DateOnly DataNascimento { get; set; }
    public GeneroEnum Genero { get; set; }
    public long? Telefone { get; set; }
    public required string CPF { get; set; }
    public required string CEP { get; set; }
    public required string NumeroCasa { get; set; }

    public DateTime Criado { get; set; }
    public bool Ativo { get; set; }

    public Cadastro() { }
    [SetsRequiredMembers]
    public Cadastro(RegisterRequestDto request)
    {
        Nome = request.Nome.ToUpper();
        Sobrenome = request.Sobrenome.ToUpper();
        Genero = request.Genero;
        Telefone = request.Telefone;
        CPF = request.CPF;
        CEP = request.CEP;
        NumeroCasa = request.NumeroCasa.ToUpper();
        Email = request.Email;
        UserName = request.Email;
        DataNascimento = DateOnly
            .FromDateTime(request.DataNascimento);

        Criado = DateTime.Now;
        Ativo = true;

        Validate();
    }

    public void Validate()
    {
        var validator = new Validators(
            $"Não foi possível validar o usuário de email: {Email}");

        validator.MinLength(Nome, 3, "Nome");
        validator.MinLength(Sobrenome, 3, "Sobrenome");
        validator.MinDate(
            DataNascimento.ToDateTime(TimeOnly.MinValue),
            DateTime.Parse("1800-01-01"), "Data de Nascimento");
        validator.MaxDate(
            DataNascimento.ToDateTime(TimeOnly.MaxValue),
            DateTime.Now.AddYears(-1), "Data de Nascimento");
        validator.Cpf(CPF, "CPF");
        validator.Cep(CEP, "CEP");
        if (Telefone != null)
            validator.Telefone((long)Telefone, "Telefone");
        validator.NumeroCasa(NumeroCasa, "NumeroCasa");
        validator.isInEnum(
            Genero,
            typeof(GeneroEnum),
            "Genero");

        validator.Check();
    }
}