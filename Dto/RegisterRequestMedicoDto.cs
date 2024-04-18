using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Dto;
public class RegisterRequestMedicoDto : RegisterRequestDto
{
    public string Especialidade { get; set; }
}
