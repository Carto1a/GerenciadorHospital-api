using Hospital.Domain.Entities.ValueObjects;
using Hospital.Domain.Enums;
using Hospital.Domain.Validators;

namespace Hospital.Domain.Entities.Cadastros;
public abstract class Cadastro : Entity
{
    public Email Email { get; set; }
    public string PasswordHash { get; set; }
    public bool EmailConfirmed { get; set; }

    public NomeCompleto NomeCompleto { get; set; }
    public DateOnly DataNascimento { get; set; }
    public GeneroEnum Genero { get; set; }
    public Telefone? Telefone { get; set; }
    public Cpf CPF { get; set; }
    public Endereco Endereco { get; set; }

    public Cadastro(
        string email, string passwordHash, bool emailConfirmed,
        string nome, string sobrenome, DateOnly dataNascimento,
        GeneroEnum genero, string? ddd, string? telefoneNumero, TipoTelefone tipoTelefone,
        string cpf, string cep, string numeroCasa, string? complemento)
    {
        Email = new Email(email);
        PasswordHash = passwordHash;
        EmailConfirmed = emailConfirmed;

        NomeCompleto = new NomeCompleto(nome, sobrenome);
        DataNascimento = dataNascimento;
        Genero = genero;
        CPF = new Cpf(cpf);
        Endereco = new Endereco(cep, numeroCasa, complemento);

        if (ddd != null && telefoneNumero != null)
            Telefone = new Telefone(ddd, telefoneNumero, tipoTelefone);

        Validate();
    }

    public override void Validate()
    {
        var validator = new DomainValidator(
            $"Não foi possível validar o usuário de email: {Email}");

        validator.MinDate(
            DataNascimento.ToDateTime(TimeOnly.MinValue),
            DateTime.Parse("1800-01-01"), "Data de Nascimento");
        // NOTE: validar isso
        validator.MaxDate(
            DataNascimento.ToDateTime(TimeOnly.MaxValue),
            DateTime.Now.AddYears(-18), "Data de Nascimento");

        validator.isInEnum(Genero, typeof(GeneroEnum), "Genero");

        // NOTE: não parece legal
        validator.LoadValueObjectValidations(NomeCompleto.Validations());
        validator.LoadValueObjectValidations(Email.Validations());
        validator.LoadValueObjectValidations(Endereco.Validations());
        validator.LoadValueObjectValidations(CPF.Validations());

        if (Telefone != null)
            validator.LoadValueObjectValidations(Telefone.Validations());

        validator.Check();
    }

    public abstract bool CheckUniqueness<TCadastro>(TCadastro cadastro)
    where TCadastro : Cadastro;
}