using FluentResults;
using Hospital.Models.Cadastro;

namespace Hospital.Repository.Cadastros.Interfaces;
public interface IPacienteRepository
{
    Result<Paciente?> GetPacienteById(string id);
    Result<List<Paciente>> GetPacientes(int limit, int page = 0);
}
