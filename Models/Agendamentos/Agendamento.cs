using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Models.Agendamentos;
public abstract class Agendamento<T>
{
    public int ID { get; set; }
    public T? Tipo { get; set; }
    public DateTime DataHora { get; set; }
    public DateTime Criação { get; set; }
    public Medico Medico { get; set; }
    public Paciente Paciente { get; set; }
    public bool Cancelado { get; set; }
}
