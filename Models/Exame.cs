using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Models;
public class Exame
{
    public int ID { get; set; }
    // tipo de exame
    public DateTime DataHora { get; set; }
    public Paciente Paciente { get; set; }
    public Medico Medico { get; set; }
    public string Resultado { get; set; }
    public decimal Custo { get; set; }
}
