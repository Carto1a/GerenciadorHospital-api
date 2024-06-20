using Hospital.Domain.Entities.Atendimentos;
using Hospital.Domain.Entities.Cadastros;
using Hospital.Domain.Entities.Medicamentos;
using Hospital.Domain.Validators;

namespace Hospital.Domain.Entities;
public class Laudo : Entity
{
    public Medico Medico { get; set; }
    public Paciente Paciente { get; set; }
    public ICollection<Exame> Exames { get; set; }
    public ICollection<Medicamento>? Medicamentos { get; set; }

    public string Descricao { get; set; }
    public Guid? DocPath { get; set; }

    public Laudo(
        string descricao, Medico medico, Paciente paciente,
        ICollection<Exame> exames, ICollection<Medicamento>? medicamentos)
    {
        Descricao = descricao;
        Medico = medico;
        Paciente = paciente;
        Exames = exames;
        Medicamentos = medicamentos;

        Validate();
    }

    public void AddDoc(Guid docName)
    {
        DocPath = docName;
    }

    public void AddMedicamento(Medicamento medicamento)
    {
        if (Medicamentos == null)
            Medicamentos = new List<Medicamento>();

        Medicamentos.Add(medicamento);
    }

    public void AddExame(Exame exame)
    {
        if (Exames == null)
            Exames = new List<Exame>();

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