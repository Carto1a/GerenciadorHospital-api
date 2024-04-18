using Hospital.Models.Cadastro;

namespace Hospital.Repository.Cadastros.Interfaces;
public interface IAuthenticationRepository
{
    Task CreatePaciente(Paciente paciente);
    Task CreateMedico(Medico paciente);
    Task CreateAdmin(Admin paciente);
    Task CreateCadastro(Cadastro cadastro);
    Task CreatePassHash(string pass);
}
