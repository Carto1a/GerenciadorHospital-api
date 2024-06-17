using Hospital.Application.Dto.Input.Convenios;
using Hospital.Application.Dto.Output.Convenios;
using Hospital.Domain.Entities.Cadastros;

namespace Hospital.Domain.Repositories;
public interface IConvenioRepository
: IRepository<Convenio, ConvenioGetByQueryDto, ConvenioOutputDto>
{
    Task<Guid> CreateAsync(Convenio convenio);
    Convenio? GetByCnpj(string cnpj);
}