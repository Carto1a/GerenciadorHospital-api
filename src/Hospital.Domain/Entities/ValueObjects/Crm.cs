using Hospital.Domain.Validators;

namespace Hospital.Domain.Entities.ValueObjects;
public class Crm : ValueObject
{
    public string Numero { get; set; }
    public string Uf { get; set; }

    public Crm(string numero, string uf)
    {
        Numero = numero;
        Uf = uf;
    }

    public override DomainValidator Validations()
    {
        var validator = new DomainValidator("Crm");
        validator.Crm(Numero, "Numero do CRM");
        validator.CrmUf(Uf, "UF do CRM");

        return validator;
    }
}