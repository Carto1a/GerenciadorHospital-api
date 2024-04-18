using Hospital.Models;

namespace Hospital.Repository.Interfaces;
public interface IAuthenticationRepository
{
    Task CreatePaciente(Paciente paciente);
    Task CreateMedico(Medico paciente);
    Task CreateAdmin(Admin paciente);
}
