using Hospital.Domain.Entities.Cadastros;
using Hospital.Domain.Entities.ValueObjects;
using Hospital.Domain.Validators;

namespace Hospital.Domain.Entities;
public class Prescricao : Entity
{
    public Medico Medico { get; set; }
    public Paciente Paciente { get; set; }
    public List<MedicamentoPrescricao> Medicamentos { get; set; }
    public string Observacao { get; set; }

    public Prescricao(Medico medico, Paciente paciente,
        string observacao)
    {
        Medico = medico;
        Paciente = paciente;
        Observacao = observacao;
        Medicamentos = new List<MedicamentoPrescricao>();

        Validate();
    }

    public void AddMedicamento(
        string nome, TimeSpan frequencia, TimeSpan duracao,
        string instucoes, string unidade, int quantidade)
    {
        var medicamento = new MedicamentoPrescricao(
            nome, frequencia, duracao, instucoes, unidade, quantidade);

        medicamento.Validations().Check();

        Medicamentos.Add(medicamento);
    }

    public override void Validate()
    {
        var validator = new DomainValidator("Prescricao");

        validator.MinLength(Observacao, 3, "Observacao");

        validator.Check();
    }
}