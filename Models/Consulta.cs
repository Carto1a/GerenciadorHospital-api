using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Models;
public class Consulta : Atendimento
{
    public string Diagnostico { get; set; }
    // prescrição medica
    public string? Observacoes { get; set; }
}
