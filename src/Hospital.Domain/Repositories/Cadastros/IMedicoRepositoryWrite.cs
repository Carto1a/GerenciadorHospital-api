using Hospital.Domain.Entities.Cadastros;

namespace Hospital.Domain.Repositories.Cadastros;
public interface IMedicoRepositoryWrite
: IAuthRepositoryWrite<Medico>
{
    Task<Medico?> GetByCRMAsync(int crm);
    Task<Medico?> GetByCPFAsync(string cpf);
}