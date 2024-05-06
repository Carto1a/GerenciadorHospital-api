using System.ComponentModel.DataAnnotations;

using Hospital.Dtos.Input.Atendimentos;
using Hospital.Enums;
using Hospital.Models.Agendamentos;

namespace Hospital.Models.Atendimento;
public class Retorno
: Atendimento
{
    public Guid ConsultaId { get; set; }
    public Guid? NovaConsultaId { get; set; }

    public virtual RetornoAgendamento? Agendamento { get; set; }
    public virtual Consulta? Consulta { get; set; }
    public virtual Consulta? NovaConsulta { get; set; }

    [EnumDataType(typeof(RetornoStatus))]
    public RetornoStatus Status { get; set; }

    public void Realizar() => Status = RetornoStatus.Realizado;
    public void AgendarNovaConsulta() => Status = RetornoStatus.NovaConsulta;
    public void Cancelar() => Status = RetornoStatus.Cancelado;

    public Retorno() { }
    public Retorno(RetornoCreateDto original)
    : base(original)
    {
        Status = original.Status;
        ConsultaId = original.ConsultaId;
        NovaConsultaId = original.NovaConsultaId;
    }
}