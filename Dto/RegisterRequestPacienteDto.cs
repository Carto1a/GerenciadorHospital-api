using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hospital.Models;

namespace Hospital.Dto;
public class RegisterRequestPacienteDto : RegisterRequestDto
{
    public IFormFile Convenio { get; set; }
    public IFormFile Documento { get; set; }
    public bool TemConvenio { get; set; }
    public List<Convenio>? Convenios { get; set; }
}
