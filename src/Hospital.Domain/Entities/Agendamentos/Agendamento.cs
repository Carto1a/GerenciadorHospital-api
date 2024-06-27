using Hospital.Domain.Entities.Agendamentos.Status;
using Hospital.Domain.Entities.Atendimentos;
using Hospital.Domain.Entities.Cadastros;
using Hospital.Domain.Enums;
using Hospital.Domain.Exceptions;
using Hospital.Domain.Validators;

namespace Hospital.Domain.Entities.Agendamentos;
public abstract class Agendamento : Entity
{
    public DateTime DataHora { get; set; }

    public Medico Medico { get; set; }
    public Paciente Paciente { get; set; }
    public Convenio? Convenio { get; set; }

    public AgendamentoStatusEnum Status { get; set; }
    public AgendamentoStatus State { get; set; }
    public decimal Custo { get; set; }
    public decimal CustoFinal { get; set; }
    public decimal CustoAtraso { get; set; }

    public void Cancelar()
    {
        State.Cancelar(this);
    }

    public void EmEspera()
    {
        State.EmEspera(this);
    }

    public void EmAndamento()
    {
        State.EmAndamento(this);
    }

    public void Ausencia()
    {
        State.Ausente(this);
    }

    public virtual void Realizar(Atendimento atendimento)
    {
        State.Realizar(this, atendimento);
    }

    public Agendamento() { }
    public Agendamento(DateTime dataHora, Medico medico, Paciente paciente,
        Convenio? convenio, decimal custo)
    {
        DataHora = dataHora;
        Medico = medico;
        Paciente = paciente;
        Convenio = convenio;
        Custo = custo;
        CustoFinal = custo;
        Status = AgendamentoStatusEnum.Agendado;
        State = new AgendamentoAgendado();
        State.CalcularDesconto(this);

        if (convenio != null)
        {
            if (convenio.Id != Paciente.Convenio?.Id)
                throw new DomainException(
                    "O convênio do paciente não é o mesmo do agendamento.");
        }

        Validate();
    }

    public override void Validate()
    {
        var validate = new DomainValidator(
            $"Não foi possível criar o agendamento: {DataHora}");

        validate.MinDate(DataHora, DateTime.Now.AddMinutes(30), "DataHora");
        validate.MinValue(Custo, 0, "Custo");

        validate.Check();
    }

    public virtual decimal CalcularDesconto()
    {
        if (Convenio == null)
            return Custo;

        return Custo * Convenio.Desconto;
    }

    public virtual decimal CalcularMultaAtraso()
    {
        if (Convenio == null)
            return Custo * 1.05m;

        return CustoFinal * 1.05m;
    }

    public virtual bool Atrasado(DateTime now)
    {
        return DataHora.AddMinutes(30) < now;
    }

    public virtual bool Ausente(DateTime now)
    {
        return DataHora.AddHours(1) < now;
    }

    public void Update(
        DateTime dataHora, decimal custo)
    {
        DataHora = dataHora;
        Custo = custo;

        Validate();
    }
}