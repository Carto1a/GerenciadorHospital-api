using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Models;
public class Medico
{
    public int ID { get; set; }
    public Cadastro Cadastro { get; set; }
    public string Especialidade { get; set; }
}
