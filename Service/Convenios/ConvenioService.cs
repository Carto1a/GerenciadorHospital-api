using FluentResults;
using Hospital.Dto.Convenios;
using Hospital.Models.Cadastro;
using Hospital.Repository.Convenios.Ineterfaces;
using Hospital.Service.Convenios.Interfaces;

namespace Hospital.Service.Convenios;
public class ConvenioService
: IConvenioService
{
    private readonly ILogger<ConvenioService> _logger;
    private readonly IConvenioRepository _repository;
    public ConvenioService(
        IConvenioRepository repository,
        ILogger<ConvenioService> logger)
    {
        _repository = repository;
        _logger = logger;
        _logger.LogDebug(1, "NLog injected into ConvenioService");
    }
    public async Task<Result> Create(
        ConvenioCreateDto request)
    {
        var convenio = GetByCnpj(request.CNPJ);
        if (convenio.Value != null)
            return Result.Fail("CNPJ já existe no banco de dados");

        var newConvenio = new Convenio();
        newConvenio.Create(request);
        var response = await _repository.CreateConvenio(newConvenio);
        if (response.IsFailed)
            return Result.Fail("Não foi possível criar o convenio");

        return Result.Ok();
    }

    public Result Delete(Guid id)
    {
        var response = GetById(id);
        if (response.IsFailed)
            return Result.Fail("Convenio não encontrado");

        var convenio = response.Value;
        convenio.Deletar();

        var responseDeletado = _repository.UpdateConvenio(convenio);
        if (responseDeletado.IsFailed)
            return Result.Fail("Não foi possível deletar o convenio");

        return Result.Ok();
    }

    public Result<Convenio?> GetByCnpj(string cnpj)
    {
        var convenio = _repository.GetConvenioByCnpj(cnpj);
        if (convenio.IsFailed)
            return Result.Fail("CNPJ não existe no banco de dados");

        return convenio;
    }

    public Result<Convenio?> GetById(Guid id)
    {
        var response = _repository.GetConvenioById(id);
        if (response.IsFailed)
            return Result.Fail("Convenio não encontrado");

        return Result.Ok(response.Value);
    }

    public async Task<Result<List<Convenio>>> GetByQuery(
        ConvenioGetByQueryDto query)
    {
        // TODO: Separar o nome para fazer full text search
        // TODO: Verificar o cnpj
        var response = _repository.GetConvenios(query);
        return Result.Ok(response.Value);
    }

    public Task<Result> Update(
        ConvenioUpdateDto request, Guid id)
    {
        throw new NotImplementedException();
    }
}
