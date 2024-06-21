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

    public AgendamentoStatus Status { get; set; }
    public decimal Custo { get; set; }
    public decimal CustoFinal { get; set; }
    public decimal CustoAtraso { get; set; }

    public abstract void Realizar(Atendimento atendimento);

    public void PodeSerRealizado()
    {
        // NOTE: isso esta errado, o correto seria permitir o Atendimento
        // se o Status for EmAndamento
        var pode =
            AgendamentoStatus.EmEspera;

        if (!Status.HasFlag(pode))
            throw new DomainException(
                "O agendamento não pode ser realizado.");
    }

    public void Cancelar()
    {
        var pode =
            AgendamentoStatus.Agendado;

        if (!Status.HasFlag(pode))
            throw new DomainException(
                "O agendamento não pode ser cancelado.");

        Status = AgendamentoStatus.Cancelado;
    }

    public void EmEspera()
    {
        var pode =
            AgendamentoStatus.Agendado;

        if (!Status.HasFlag(pode))
            throw new DomainException(
                "O agendamento não pode ser colocado em espera.");

        Status = AgendamentoStatus.EmEspera;
    }

    public void EmAndamento()
    {
        var pode =
            AgendamentoStatus.EmEspera | AgendamentoStatus.Agendado;

        if (!Status.HasFlag(pode))
            throw new DomainException(
                "O agendamento não pode ser colocado em andamento.");

        Status = AgendamentoStatus.EmAndamento;
    }

    public void Ausencia()
    {
        var pode =
            AgendamentoStatus.Agendado | AgendamentoStatus.EmEspera;

        if (!Status.HasFlag(pode))
            throw new DomainException(
                "O agendamento não pode ser colocado como ausência.");

        Status = AgendamentoStatus.Ausencia;
    }

    public Agendamento(DateTime dataHora, Medico medico, Paciente paciente,
        Convenio? convenio, decimal custo)
    {
        DataHora = dataHora;
        Medico = medico;
        Paciente = paciente;
        Convenio = convenio;
        Custo = custo;
        Status = AgendamentoStatus.Agendado;

        if (convenio != null)
        {
            if (convenio.Id != Paciente.Convenio?.Id)
                throw new DomainException(
                    "O convênio do paciente não é o mesmo do agendamento.");

            CalcularDesconto(convenio);
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

    public void CalcularDesconto(Convenio? convenio)
    {
        CustoFinal = Custo;
        if (convenio != null)
            CustoFinal = Custo * convenio.Desconto;
    }

    public void CalcularMulta(Convenio? convenio)
    {
        CustoAtraso = CustoFinal * 1.2m;
    }

    public bool Atrasado(DateTime now)
    {
        return DataHora.AddMinutes(30) < now;
    }

    public bool Ausente(DateTime now)
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