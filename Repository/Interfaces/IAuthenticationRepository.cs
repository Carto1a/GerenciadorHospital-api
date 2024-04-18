using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hospital.Models;

namespace Hospital.Repository.Interfaces;
public interface IAuthenticationRepository
{
    Task CreatePaciente(Paciente paciente);
}
