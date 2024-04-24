using System.ComponentModel.DataAnnotations;

using Hospital.Enums;
using Hospital.Models.Agendamentos;

namespace Hospital.Models.Atendimento;
public class Consulta
: Atendimento
{
    public virtual ConsultaAgendamento? Agendamento { get; set; }
    public virtual Retorno? Retorno { get; set; }
    public virtual Retorno? VeioDeRetorno { get; set; }
    public virtual ICollection<Exame>? Exames { get; set; }
    public virtual ICollection<Laudo>? Laudos { get; set; }

    [EnumDataType(typeof(ConsultaStatus))]
    public ConsultaStatus Status { get; set; }

    public void Realizar() => Status = ConsultaStatus.Realizado;
    public void Processar() => Status = ConsultaStatus.Processando;
    public void Terminar() => Status = ConsultaStatus.Terminado;
    public void Ausente() => Status = ConsultaStatus.Ausencia;
}