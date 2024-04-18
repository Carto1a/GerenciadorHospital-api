using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hospital.Models;

namespace Hospital.Dto.Agendamento;
public abstract class AgendamentoDto<T>
{
    public T? Referente { get; set; }
    public DateTime DataHora { get; set; }
    public Medico medico { get; set; }
    public Paciente paciente { get; set; }
}
