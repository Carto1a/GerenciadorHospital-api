using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hospital.Models;
using Hospital.Models.Agendamentos;
using Hospital.Repository.Interfaces;

namespace Hospital.Repository;
public class ConsultaRepository : GenericAtentimento<Consulta, ConsultaAgendamento>
{
}
