using Hospital.Domain.Validators;

namespace Hospital.Domain.Entities.ValueObjects;
public class Cpf : ValueObject
{
    public string Numero { get; set; }

    public Cpf(string numero)
    {
        Numero = numero;
    }

    public override string ToString()
    {
        return Numero;
    }

    public override DomainValidator Validations()
    {
        var validator = new DomainValidator("Cpf");
        validator.Cpf(Numero, "Numero do CPF");

        return validator;
    }
}