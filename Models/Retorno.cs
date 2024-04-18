using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Models;
public class Retorno
{
    public int ID { get; set; }
    public DateTime DataHora { get; set; }
    public Consulta Consulta { get; set; }
    public Paciente Paciente { get; set; }
    public Medico Medico { get; set; }
    public string Observacoes { get; set; }
}
