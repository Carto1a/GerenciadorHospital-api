using Hospital.Domain.Validators;

namespace Hospital.Domain.Entities.ValueObjects;
public class NomeCompleto : ValueObject
{
    public string Nome { get; set; }
    public string Sobrenome { get; set; }

    public NomeCompleto(string nome, string sobrenome)
    {
        Nome = nome;
        Sobrenome = sobrenome;
    }

    public override DomainValidator Validations()
    {
        var validator = new DomainValidator("NomeCompleto");
        validator.IsNome(Nome, "Nome");
        validator.IsNome(Sobrenome, "Sobrenome");

        return validator;
    }

    public override string ToString()
    {
        return $"{Nome} {Sobrenome}";
    }
}