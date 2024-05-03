using System.ComponentModel.DataAnnotations;

using Hospital.Dtos.Input.Agendamentos;
using Hospital.Enums;
using Hospital.Models.Cadastro;

namespace Hospital.Models.Agendamentos;
public abstract class Agendamento
{
    [Key]
    public Guid Id { get; set; }
    public Guid MedicoId { get; set; }
    public Guid? PacienteId { get; set; }
    public Guid? ConvenioId { get; set; }

    public virtual Medico? Medico { get; set; }
    public virtual Paciente? Paciente { get; set; }
    public virtual Convenio? Convenio { get; set; }

    [EnumDataType(typeof(AgendamentoStatus))]
    public AgendamentoStatus Status { get; set; }
    public decimal Custo { get; set; }
    public decimal CustoFinal { get; set; }

    public DateTime DataHora { get; set; }
    public DateTime Criado { get; set; }
    public bool Deletado { get; set; }

    public void Cancelar() => Status = AgendamentoStatus.Cancelado;
    public void Realizar() => Status = AgendamentoStatus.Realizado;
    public void EmEspera() => Status = AgendamentoStatus.EmEspera;
    public void EmAndamento() => Status = AgendamentoStatus.EmAndamento;
    public void Deletar()
    {
        Deletado = true;
        Status = AgendamentoStatus.Cancelado;
    }
    public void Update(AgendamentoUpdateDto request)
    {
        DataHora = request.DataHora;
        Custo = request.Custo;
    }

    public Agendamento() { }
    public Agendamento Create(AgendamentoCreateDto request)
    {
        MedicoId = request.MedicoId;
        PacienteId = request.PacienteId;
        ConvenioId = request.ConvenioId;
        DataHora = request.DataHora;
        Custo = request.Custo;
        Criado = DateTime.Now;
        Deletado = false;
        Status = AgendamentoStatus.Agendado;

        // NOTE: If this object is invalid,
        // it will throw an exception
        Validate();
        return this;
    }

    public void Validate()
    {
        var validate = new Validators(
            $"Não foi possível criar o agendamento: {DataHora}");

        validate.MinDate(DataHora, DateTime.Now.AddMinutes(10), "DataHora");
        validate.MinValue(Custo, 0, "Custo");

        validate.Check();
    }
}