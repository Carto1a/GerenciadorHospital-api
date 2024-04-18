using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Models;
public class Convenio
{
    public int ID { get; set; }
    public string Nome { get; set; }
    public string Descrição { get; set; }
    public string Endereco { get; set; }
    public int Telefone { get; set; }
}
