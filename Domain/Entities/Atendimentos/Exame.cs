using System.ComponentModel.DataAnnotations;

using Hospital.Application.Dto.Input.Atendimentos;
using Hospital.Domain.Entities.Agendamentos;
using Hospital.Domain.Enums;

namespace Hospital.Domain.Entities.Atendimentos;
public class Exame : Atendimento
{
    // TODO: colocar o tipo de exame
    public Guid ConsultaId { get; set; }

    public virtual ExameAgendamento? Agendamento { get; set; }
    public virtual Consulta? Consulta { get; set; }
    /* public virtual ICollection<Laudo?>? Laudos { get; set; } */
    public virtual ICollection<Exame_Laudo?>? ExamesLaudos { get; set; }

    // TODO: criar uma entidade para exame resultado
    public string? Resultado { get; set; }

    [EnumDataType(typeof(ExameStatus))]
    public ExameStatus Status { get; set; }

    public Exame() { }

    public Exame(ExameCreateDto dto)
    {
        AgendamentoId = dto.AgendamentoId;
        Inicio = dto.Inicio;
        Fim = dto.Fim;
        Criado = DateTime.Now;
        Status = dto.Status;
        ConsultaId = dto.ConsultaId;
        Resultado = dto.Resultado;
        ConsultaId = dto.ConsultaId;
    }

    public void Processar() => Status = ExameStatus.Processando;
    public void Completar() => Status = ExameStatus.Completado;
    public void Cancelar() => Status = ExameStatus.Cancelado;
}