using System.ComponentModel.DataAnnotations;

using Hospital.Enums;

namespace Hospital.Models.Atendimento;
public class Consulta
: Atendimento
{
    public virtual ICollection<Exame>? Exames { get; set; }
    public virtual ICollection<Laudo>? Laudos { get; set; }

    [EnumDataType(typeof(AtendimentoStatus))]
    public AtendimentoStatus Status { get; set; }

    /* public void Creation( */
    /*     ConsultaCreationDto request, */
    /*     Medico medico, */
    /*     Paciente paciente) */
    /* { */
    /*     base.Creation(request, medico, paciente); */
    /*     Diagnostico = request.Diagnostico; */
    /*     Observacoes = request.Observacoes; */
    /* } */
}