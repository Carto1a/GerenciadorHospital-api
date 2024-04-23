using System.ComponentModel.DataAnnotations;

using Hospital.Enums;

namespace Hospital.Models.Atendimento;
public class Exame
: Atendimento
{
    // TODO: colocar o tipo de exame
    public Guid LaudoId { get; set; }
    public Guid ConsultaId { get; set; }

    public virtual Laudo? Laudo { get; set; }
    public virtual Consulta? Consulta { get; set; }

    // TODO: criar uma entidade para exame resultado
    public string Resultado { get; set; }

    [EnumDataType(typeof(ExameStatus))]
    public ExameStatus Status { get; set; }
}