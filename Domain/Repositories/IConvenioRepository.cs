using Hospital.Application.Dto.Input.Convenios;
using Hospital.Application.Dto.Output.Convenios;
using Hospital.Domain.Entities;

namespace Hospital.Domain.Repositories;
public interface IConvenioRepository
: IRepository<Convenio, ConvenioGetByQueryDto, ConvenioOutputDto>
{
    Task<Guid> CreateAsync(Convenio convenio);
    Task<Convenio?> GetByCnpjAsync(string cnpj);
}