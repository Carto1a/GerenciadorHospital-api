using Hospital.Dtos.Output.Cadastros;
using Hospital.Models.Cadastro;

namespace Hospital.Repository.Cadastros.Interfaces;
public interface IPacienteRepository
{
    Paciente? GetPacienteById(Guid id);
    PacienteOutputDto? GetPacienteByIdDto(Guid id);
    List<Paciente> GetPacientes(int limit, int page = 0);
}