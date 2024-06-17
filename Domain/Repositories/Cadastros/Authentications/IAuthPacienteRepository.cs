using Hospital.Application.Dto.Input.Authentications;
using Hospital.Domain.Entities.Cadastros;

namespace Hospital.Domain.Repositories.Cadastros.Authentications;
public interface IAuthPacienteRepository
: IAuthRepository<Paciente, RegisterRequestPacienteDto>
{ }