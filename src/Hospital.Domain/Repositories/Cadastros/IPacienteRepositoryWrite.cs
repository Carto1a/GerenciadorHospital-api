using Hospital.Domain.Entities.Cadastros;

namespace Hospital.Domain.Repositories.Cadastros;
public interface IPacienteRepositoryWrite
: IAuthRepositoryWrite<Paciente>
{
    Task<Paciente?> GetByCPFAsync(string cpf);
}