using Hospital.Domain.Entities.Cadastros;

namespace Hospital.Domain.Repositories.Cadastros;
public interface IPacienteRepository
: IAuthRepository<Paciente>
{
    Task<Paciente?> GetByCPFAsync(string cpf);
}