using Hospital.Domain.Validators;

namespace Hospital.Domain.Entities.ValueObjects;
public class Dosagem : ValueObject
{
    public int Quantidade { get; set; }
    public string Unidade { get; set; }

    public Dosagem(int quantidade, string unidade)
    {
        Quantidade = quantidade;
        Unidade = unidade;
    }

    public override DomainValidator Validations()
    {
        var validator = new DomainValidator("Dosagem");

        validator.MinValue(Quantidade, 1, "Quantidade");
        validator.NotNull(Unidade, "Unidade");
        // NOTE: não sei como validar a unidade

        return validator;
    }

    public override string ToString()
    {
        return $"{Quantidade} {Unidade}";
    }
}