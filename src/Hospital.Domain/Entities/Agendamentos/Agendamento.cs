using System.ComponentModel.DataAnnotations;

using Hospital.Application.Dto.Input.Agendamentos;
using Hospital.Domain.Entities.Cadastros;
using Hospital.Domain.Enums;
using Hospital.Domain.Validators;

namespace Hospital.Domain.Entities.Agendamentos;
public abstract class Agendamento : Entity, IAtrasado, IDescontavel
{
    public Guid MedicoId { get; set; }
    public Guid? PacienteId { get; set; }
    public Guid? ConvenioId { get; set; }
    public DateTime DataHora { get; set; }

    public virtual Medico? Medico { get; set; }
    public virtual Paciente? Paciente { get; set; }
    public virtual Convenio? Convenio { get; set; }

    [EnumDataType(typeof(AgendamentoStatus))]
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
    public void Update(AgendamentoUpdateDto request)
    {
        DataHora = request.DataHora;
        Custo = request.Custo;
    }

    public Agendamento() { }
    public Agendamento(AgendamentoCreateDto request)
    {
        MedicoId = request.MedicoId;
        PacienteId = request.PacienteId;
        ConvenioId = request.ConvenioId;
        DataHora = request.DataHora;
        Custo = request.Custo;
        Criado = DateTime.Now;
        Ativo = true;
        Status = AgendamentoStatus.Agendado;

        Validate();
    }

    public Agendamento Create(AgendamentoCreateDto request)
    {
        MedicoId = request.MedicoId;
        PacienteId = request.PacienteId;
        ConvenioId = request.ConvenioId;
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
}