using Hospital.Domain.Entities.ValueObjects;
using Hospital.Domain.Validators;

namespace Hospital.Domain.Entities;
public class Convenio : Entity
{
    public Cnpj CNPJ { get; set; }
    public Endereco Endereco { get; set; }
    public Email Email { get; set; }
    public Telefone Telefone { get; set; }
    public string Nome { get; set; }
    public string? Descrição { get; set; }
    public string? Site { get; set; }
    public decimal Desconto { get; set; }

    public Convenio() { }
    public Convenio(string cnpj, string cep, string rua, string complemento,
        string email, string nome, string descricao, string site,
        decimal desconto)
    {
        CNPJ = new Cnpj(cnpj);
        Endereco = new Endereco(cep, rua, complemento);
        Email = new Email(email);
        Nome = nome;
        Descrição = descricao;
        Site = site;
        Desconto = desconto;

        Validate();
    }

    public override void Validate()
    {
        var validator = new DomainValidator(
            $"Não foi possível validar o convênio: {CNPJ.Numero}");

        validator.MinLength(Nome, 3, "Nome");
        validator.MinLength(Descrição, 3, "Descrição");
        validator.MinLength(Site, 8, "Site");
        validator.MinValue(Desconto, 0, "Desconto");
        validator.MaxValue(Desconto, 1, "Desconto");

        validator.LoadValueObjectValidations(CNPJ!.Validations());
        validator.LoadValueObjectValidations(Endereco!.Validations());
        validator.LoadValueObjectValidations(Email!.Validations());
        validator.LoadValueObjectValidations(Telefone!.Validations());

        validator.Check();
    }
}