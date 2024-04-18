using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Models;
public class Retorno : Atendimento
{
    public Consulta Consulta { get; set; }
    public string Observacoes { get; set; }
}
