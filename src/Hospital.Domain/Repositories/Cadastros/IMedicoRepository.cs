using Hospital.Application.Dto.Input.Authentications;
using Hospital.Application.Dto.Output.Cadastros;
using Hospital.Domain.Entities.Cadastros;

namespace Hospital.Domain.Repositories.Cadastros;
public interface IMedicoRepository
: IRepository<Medico, MedicoGetByQueryDto, MedicoOutputDto>
{
    Task<Medico?> GetByCRMAsync(int crm);
    Task<Medico?> GetByCPFAsync(string cpf);
}