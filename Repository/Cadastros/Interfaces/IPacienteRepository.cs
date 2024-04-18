using FluentResults;

using Hospital.Models.Cadastro;

namespace Hospital.Repository.Cadastros.Interfaces;
public interface IPacienteRepository
{
    Result<Paciente?> GetPacienteById(Guid id);
    Result<List<Paciente>> GetPacientes(int limit, int page = 0);
}