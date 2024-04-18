using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Models;
public class Paciente
{
    public int ID { get; set; }
    public Cadastro Cadastro { get; set; }
    public bool TemConvenio { get; set; }
    public List<Convenio>? Convenios { get; set; }
    public string ImgCarteiraConvenio { get; set; }
    public string ImgDocumento { get; set; }
}
