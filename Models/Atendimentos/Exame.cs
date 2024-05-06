using System.ComponentModel.DataAnnotations;

using Hospital.Dtos.Input.Atendimentos;
using Hospital.Enums;
using Hospital.Models.Agendamentos;

namespace Hospital.Models.Atendimento;
public class Exame
: Atendimento
{
    // TODO: colocar o tipo de exame
    // TODO: deixar o laudo vinculado somente a uma consulta
    /* public Guid LaudoId { get; set; } // NOTE: pode ser que de erro */
    public Guid ConsultaId { get; set; }

    public virtual ExameAgendamento? Agendamento { get; set; }
    public virtual Laudo? Laudo { get; set; }
    public virtual Consulta? Consulta { get; set; }

    // TODO: criar uma entidade para exame resultado?
    public string? Resultado { get; set; }

    [EnumDataType(typeof(ExameStatus))]
    public ExameStatus Status { get; set; }

    public void Processar() => Status = ExameStatus.Processando;
    public void Completar() => Status = ExameStatus.Completado;
    public void Cancelar() => Status = ExameStatus.Cancelado;

    public Exame() { }
    public Exame(ExameCreateDto original)
    : base(original)
    {
        Status = original.Status ?? ExameStatus.Processando;
        Resultado = original.Resultado;
    }
}