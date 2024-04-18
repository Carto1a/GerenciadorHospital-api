using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hospital.Models;
using Hospital.Models.Agendamentos;

namespace Hospital.Repository.Interfaces;
public interface IRetornoRepository : IGenericAtentimento<Retorno, RetornoAgendamento>
{
}
