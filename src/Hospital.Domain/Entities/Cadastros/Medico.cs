using Hospital.Domain.Entities.ValueObjects;
using Hospital.Domain.Enums;
using Hospital.Domain.Validators;

namespace Hospital.Domain.Entities.Cadastros;
public class Medico : Cadastro
{
    public Crm CRM { get; set; }
    public Guid? DocCRMPath { get; set; }
    public string Especialidade { get; set; }

    public Medico(
        string email, string passwordHash, bool emailConfirmed,
        string nome, string sobrenome, DateOnly dataNascimento,
        GeneroEnum genero, string? ddd, string? telefoneNumero, TipoTelefone tipoTelefone,
        string cpf, string cep, string numeroCasa, string? complemento,
        string crmNumero, string crmUf, string especialidade)
    : base(
        email, passwordHash, emailConfirmed,
        nome, sobrenome, dataNascimento,
        genero, ddd, telefoneNumero, tipoTelefone,
        cpf, cep, numeroCasa, complemento)
    {
        CRM = new Crm(crmNumero, crmUf);
        Especialidade = especialidade;

        Validate();
    }

    public void AddCrmDoc(Guid docName)
    {
        DocCRMPath = docName;
    }

    public override void Validate()
    {
        var validation = new DomainValidator(
            $"Não foi possível validar o medico de email: {Email}");

        validation.MinLength(Especialidade, 4, "Especialidade");
        validation.MaxLength(Especialidade, 50, "Especialidade");

        validation.LoadValueObjectValidations(CRM.Validations());

        validation.Check();
    }

    public override bool CheckUniqueness<TCadastro>(TCadastro cadastro)
    {
        if (cadastro is Medico medico)
        {
            return Email == medico.Email
                || CPF == medico.CPF
                || CRM == medico.CRM;
        }

        throw new ArgumentException(
            "O tipo de registro não é um médico.");
    }
}