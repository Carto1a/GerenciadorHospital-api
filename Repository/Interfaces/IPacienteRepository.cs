using FluentResults;
using Hospital.Models;

namespace Hospital.Repository.Interfaces;
public interface IPacienteRepository
{
    Result<Paciente?> GetPacienteById(int id);
    Result<List<Paciente>> GetPacientes(int limit, int page = 0);
}
