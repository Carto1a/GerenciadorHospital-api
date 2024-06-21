using Hospital.Domain.Entities.Agendamentos;
using Hospital.Domain.Entities.Cadastros;
using Hospital.Domain.Validators;

namespace Hospital.Domain.Entities.Atendimentos;
public abstract class Atendimento : Entity
{
    public Medico Medico { get; set; }
    public Paciente Paciente { get; set; }
    public Convenio? Convenio { get; set; }

    public DateTime Inicio { get; set; }
    public DateTime Fim { get; set; }
    public decimal Custo { get; set; }
    public decimal CustoFinal { get; set; }

    public TimeSpan Duracao => Fim - Inicio;

    public Atendimento(Medico medico,
        DateTime inicio, DateTime fim)
    {
        Medico = medico;
        Inicio = inicio;
        Fim = fim;
    }

    public virtual void GetInfoAgendamento(Agendamento agendamento)
    {
        Paciente = agendamento.Paciente;
        Convenio = agendamento.Convenio;
        Custo = agendamento.Custo;
        CustoFinal = agendamento.CustoFinal;
    }

    public override void Validate()
    {
        var validate = new DomainValidator(
            $"Não foi possível criar o atendimento: {Inicio}");

        validate.MinDate(Inicio, DateTime.Now.AddMinutes(30), "Inicio");
        validate.MinDate(Fim, Inicio, "Fim");
        validate.MinValue(Custo, 0, "Custo");
    }
}