using Hospital.Domain.Entities.Atendimentos;
using Hospital.Domain.Entities.Cadastros;
using Hospital.Domain.Exceptions;
using Hospital.Domain.Validators;

namespace Hospital.Domain.Entities;
public class Laudo : Entity
{
    public Medico Medico { get; set; }
    public Paciente Paciente { get; set; }
    public ICollection<Exame> Exames { get; set; }

    public string Descricao { get; set; }
    public string Diagnostico { get; set; }
    public string Recomendacoes { get; set; }
    public Guid? DocPath { get; set; }

    public Laudo(
        string descricao, string diagnostico, string recomendacoes, Medico medico, Paciente paciente,
        ICollection<Exame> exames)
    {
        Descricao = descricao;
        Diagnostico = diagnostico;
        Recomendacoes = recomendacoes;
        Medico = medico;
        Paciente = paciente;
        Exames = exames;

        Validate();
    }

    public void AddDoc(Guid docName)
    {
        DocPath = docName;
    }

    public void AddExame(Exame exame)
    {
        if (Exames == null)
            Exames = new List<Exame>();

        if (Exames.Any(e => e.Id == exame.Id))
            throw new DomainException(
                $"O exame já foi adicionado: {exame.Id}.");

        Exames.Add(exame);
    }

    public override void Validate()
    {
        var validator = new DomainValidator(
            $"Não foi possível validar o laudo do medico: {Medico.Id} e paciente: {Paciente.Id}");

        validator.MinLength(Descricao, 10, "Descrição");
        validator.MinValue(Exames.Count, 1, "Exames");

        validator.Check();
    }
}