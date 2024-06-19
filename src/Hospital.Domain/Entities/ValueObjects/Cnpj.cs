using Hospital.Domain.Validators;

namespace Hospital.Domain.Entities.ValueObjects;
public class Cnpj : ValueObject
{
    public string Numero { get; set; }

    public Cnpj(string numero)
    {
        Numero = numero;
    }

    public override string ToString()
    {
        return Numero;
    }

    public override DomainValidator Validations()
    {
        var validator = new DomainValidator("Cnpj");
        validator.Cnpj(Numero, "Numero do CNPJ");

        return validator;
    }
}