using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hospital.Models;

namespace Hospital.Dto.Agendamento;
public class AgendamentoCreateDto
{
    public DateTime DataHora { get; set; }
    public int MedicoId { get; set; }
    public int PacienteId { get; set; }
    public decimal Custo { get; set; }
    public bool Convenio { get; set; }
}
