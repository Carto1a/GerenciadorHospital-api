using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Models;
public class Exame : Atendimento
{
    // tipo de exame
    public string Resultado { get; set; }
}
