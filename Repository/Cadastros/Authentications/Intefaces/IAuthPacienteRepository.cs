using Hospital.Dtos.Input.Authentications;
using Hospital.Models.Cadastro;

namespace Hospital.Repository.Cadastros.Authentications.Interfaces;
public interface IAuthPacienteRepository
: IAuthCadastroRepository<Paciente, RegisterRequestPacienteDto>
{ }