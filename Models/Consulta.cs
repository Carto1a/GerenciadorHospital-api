using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Models;
public class Consulta
{
    public int ID { get; set; }
    public DateTime DataHora { get; set; }
    public Medico Medico { get; set; }
    public Paciente Paciente { get; set; }
    public TimeOnly Duracao { get; set; }
    public string Diagnostico { get; set; }
    // prescrição medica
    public string Observacoes { get; set; }
}
