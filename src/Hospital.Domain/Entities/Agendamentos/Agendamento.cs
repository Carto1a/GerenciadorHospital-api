using Hospital.Domain.Entities.Cadastros;
using Hospital.Domain.Enums;
using Hospital.Domain.Validators;

namespace Hospital.Domain.Entities.Agendamentos;
public abstract class Agendamento : Entity
{
    public DateTime DataHora { get; set; }

    public Medico? Medico { get; set; }
    public Paciente? Paciente { get; set; }
    public Convenio? Convenio { get; set; }

    public AgendamentoStatus Status { get; set; }
    public decimal Custo { get; set; }
    public decimal CustoFinal { get; set; }
    public decimal CustoAtraso { get; set; }

    public void Cancelar() => Status = AgendamentoStatus.Cancelado;
    public void Realizar() => Status = AgendamentoStatus.Realizado;
    public void EmEspera() => Status = AgendamentoStatus.EmEspera;
    public void EmAndamento() => Status = AgendamentoStatus.EmAndamento;
    public void Ausencia() => Status = AgendamentoStatus.Ausencia;

    public override void Deletar()
    {
        Ativo = false;
        Status = AgendamentoStatus.Cancelado;
    }

    public Agendamento(AgendamentoCreateDto request)
    {
        DataHora = request.DataHora;
        Custo = request.Custo;
        Status = AgendamentoStatus.Agendado;

        Validate();
    }

    public Agendamento Create(AgendamentoCreateDto request)
    {
        DataHora = request.DataHora;
        Custo = request.Custo;
        Criado = DateTime.Now;
        Ativo = true;
        Status = AgendamentoStatus.Agendado;

        Validate();
        return this;
    }

    public void Validate()
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