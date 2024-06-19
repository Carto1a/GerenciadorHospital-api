using Hospital.Domain.Validators;

namespace Hospital.Domain.Entities.ValueObjects;
public class Email : ValueObject
{
    public string Endereco { get; set; }

    public Email(string endereco)
    {
        Endereco = endereco;
    }

    public override string ToString()
    {
        return Endereco;
    }

    public override DomainValidator Validations()
    {
        var validator = new DomainValidator("Email");
        validator.Email(Endereco, "Endereco de email");

        return validator;
    }
}