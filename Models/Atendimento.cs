using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Models;
public abstract class Atendimento
{
    public int ID { get; set; }
    public DateTime DataHora { get; set; }
    public Medico Medico { get; set; }
    public Paciente Paciente { get; set; }
    public TimeSpan Duracao { get; set; }
    public bool Convenio { get; set; }
    public decimal Custo { get; set; }

}
