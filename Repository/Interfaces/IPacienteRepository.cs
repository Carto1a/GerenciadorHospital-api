using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hospital.Models;

namespace Hospital.Repository.Interfaces;
public interface IPacienteRepository
{
    Paciente GetPacienteById(int id);
    List<Paciente> GetPacientes(int limit, int page = 0);
}
