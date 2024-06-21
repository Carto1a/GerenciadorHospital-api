using Hospital.Domain.Validators;

namespace Hospital.Domain.Entities.ValueObjects;
public class MedicamentoPrescricao : ValueObject
{
    public string Nome { get; set; }
    public Dosagem Dosagem { get; set; }
    public TimeSpan Frequencia { get; set; }
    public TimeSpan Duracao { get; set; }
    public string Instucoes { get; set; }

    public MedicamentoPrescricao(
        string nome, TimeSpan frequencia, TimeSpan duracao,
        string instucoes, string unidade, int quantidade)
    {
        Nome = nome;
        Frequencia = frequencia;
        Duracao = duracao;
        Instucoes = instucoes;
        Dosagem = new Dosagem(quantidade, unidade);
    }

    public override DomainValidator Validations()
    {
        var validator = new DomainValidator("Medicamentos");

        validator.MinLength(Nome, 3, "Nome");
        validator.LoadValueObjectValidations(Dosagem.Validations());

        return validator;
    }

    public override string ToString()
    {
        return $"{Nome} - {Dosagem} - {Frequencia} - {Duracao} - {Instucoes}";
    }
}