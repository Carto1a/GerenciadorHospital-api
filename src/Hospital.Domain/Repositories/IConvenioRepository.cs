using Hospital.Domain.Entities;

namespace Hospital.Domain.Repositories;
public interface IConvenioRepository
: IRepository<Convenio>
{
    Task<Convenio?> GetByCnpjAsync(string cnpj);
}