using Hospital.Domain.Enums;
using Hospital.Domain.Validators;

namespace Hospital.Domain.Entities.ValueObjects;
public class Telefone : ValueObject
{
    public string DDD { get; set; }
    public string Numero { get; set; }
    public TipoTelefone Tipo { get; set; }

    public Telefone(string ddd, string numero, TipoTelefone tipo)
    {
        DDD = ddd;
        Numero = numero;
        Tipo = tipo;
    }

    public override string ToString()
    {
        return $"({DDD}) {Numero}";
    }

    public override DomainValidator Validations()
    {
        var validator = new DomainValidator("Telefone");
        validator.DDD(DDD, "DDD");
        validator.isInEnum(Tipo, typeof(TipoTelefone), "Tipo de telefone");

        switch (Tipo)
        {
            case TipoTelefone.Celular:
                validator.NumeroCelular(Numero, "Numero");
                break;
            case TipoTelefone.Fixo:
                validator.NumeroTelefone(Numero, "Numero");
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        return validator;
    }
}