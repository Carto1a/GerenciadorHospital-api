using FluentResults;
using Hospital.Dto.Convenios;
using Hospital.Models.Cadastro;

namespace Hospital.Repository.Convenios.Ineterfaces;
public interface IConvenioRepository
{
    Task<Result<Convenio>> CreateConvenio(Convenio convenio);
    Result<Convenio?> GetConvenioById(Guid id);
    Result<Convenio?> GetConvenioByCnpj(string cnpj);
    Result<List<Convenio>> GetConvenios(ConvenioGetByQueryDto request, int limit = 1, int page = 0);
    Result<Convenio> UpdateConvenio(Convenio convenio);
    Result<List<Convenio>> GetConvenios(int limit = 1, int page = 0);
    Result DeleteConvenio(Guid id);
}
