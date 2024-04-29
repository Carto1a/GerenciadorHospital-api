using Hospital.Models.Cadastro;

namespace Hospital.Repository.Cadastros.Interfaces;
public interface IPacienteRepository
{
    Paciente? GetPacienteById(Guid id);
    List<Paciente> GetPacientes(int limit, int page = 0);
}