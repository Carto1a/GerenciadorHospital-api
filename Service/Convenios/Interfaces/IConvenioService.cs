using FluentResults;

using Hospital.Dto.Convenios;
using Hospital.Models.Cadastro;

namespace Hospital.Service.Convenios.Interfaces;
public interface IConvenioService
{
    Task<Result> Create(ConvenioCreateDto request);
    Result<Convenio?> GetById(Guid id);
    Result<Convenio?> GetByCnpj(string cnpj);
    Task<Result<List<Convenio>>> GetByQuery(ConvenioGetByQueryDto query);
    Task<Result> Update(ConvenioUpdateDto request, Guid id);
    Result Delete(Guid id);
}