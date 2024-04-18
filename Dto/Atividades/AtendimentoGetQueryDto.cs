using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Dto.Atividades;
public class AtendimentoGetQueryDto
{
    public DateTime? minDate { get; set; }
    public DateTime? maxDate { get; set; }
    public int? medicoId { get; set; }
    public int? pacienteId { get; set; }
    public int? limit { get; set; }
    public int? page { get; set; }
}
