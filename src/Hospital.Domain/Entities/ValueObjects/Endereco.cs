using Hospital.Domain.Validators;

namespace Hospital.Domain.Entities.ValueObjects;
public class Endereco : ValueObject
{
    public string Cep { get; set; }
    public string Numero { get; set; }
    public string? Complemento { get; set; }
    public Endereco(string cep, string numero, string? complemento)
    {
        Cep = cep;
        Numero = numero;
        Complemento = complemento;
    }

    public override DomainValidator Validations()
    {
        var validator = new DomainValidator("Endereco");
        validator.Cep(Cep, "CEP");
        validator.NumeroCasa(Numero, "Numero");

        return validator;
    }
}