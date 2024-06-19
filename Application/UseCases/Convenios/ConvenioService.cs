/* using FluentResults; */

/* using Hospital.Dto.Convenios; */
/* using Hospital.Models.Cadastro; */
/* using Hospital.Repository.Convenios.Ineterfaces; */
/* using Hospital.Service.Convenios.Interfaces; */

/* namespace Hospital.Service.Convenios; */
/* public class ConvenioService */
/* : IConvenioService */
/* { */
/*     private readonly ILogger<ConvenioService> _logger; */
/*     private readonly IConvenioRepository _repository; */
/*     public ConvenioService( */
/*         IConvenioRepository repository, */
/*         ILogger<ConvenioService> logger) */
/*     { */
/*         _repository = repository; */
/*         _logger = logger; */
/*         _logger.LogDebug(1, "NLog injected into ConvenioService"); */
/*     } */

/*     public Result Delete(Guid id) */
/*     { */
/*         _logger.LogInformation($"Deletando convenio: {id}"); */
/*         var response = GetById(id); */
/*         if (response.IsFailed) */
/*         { */
/*             _logger.LogError($"Convenio não encontrado para deletar: {id}"); */
/*             return Result.Fail("Convenio não encontrado"); */
/*         } */

/*         var convenio = response.Value; */
/*         convenio.Deletar(); */

/*         var responseDeletado = _repository.UpdateConvenio(convenio); */
/*         if (responseDeletado.IsFailed) */
/*         { */
/*             _logger.LogError($"Não foi possível deletar o convenio: {id}"); */
/*             return Result.Fail("Não foi possível deletar o convenio"); */
/*         } */

/*         _logger.LogInformation($"Convenio deletado: {id}"); */
/*         return Result.Ok(); */
/*     } */

/*     public Result<Convenio?> GetByCnpj(string cnpj) */
/*     { */
/*         _logger.LogInformation($"Buscando convenio por cnpj: {cnpj}"); */
/*         var convenio = _repository.GetConvenioByCnpj(cnpj); */
/*         if (convenio.IsFailed) */
/*         { */
/*             _logger.LogError($"CNPJ do convenio não existe no banco de dados: {cnpj}"); */
/*             return Result.Fail("CNPJ não existe no banco de dados"); */
/*         } */

/*         _logger.LogInformation($"Convenio encontrado por cnpj: {cnpj}"); */
/*         return convenio; */
/*     } */

/*     public Result<Convenio?> GetById(Guid id) */
/*     { */
/*         _logger.LogInformation($"Buscando convenio por id: {id}"); */
/*         var response = _repository.GetConvenioById(id); */
/*         if (response.IsFailed) */
/*         { */
/*             _logger.LogError($"Convenio não encontrado: {id}"); */
/*             return Result.Fail("Convenio não encontrado"); */
/*         } */

/*         _logger.LogInformation($"Convenio encontrado: {id}"); */
/*         return Result.Ok(response.Value); */
/*     } */

/*     public async Task<Result<List<Convenio>>> GetByQuery( */
/*         ConvenioGetByQueryDto query) */
/*     { */
/*         _logger.LogInformation($"Buscando convenio por query: {query}"); */
/*         // TODO: Separar o nome para fazer full text search */
/*         // TODO: Verificar o cnpj */
/*         var response = _repository.GetConvenios(query); */

/*         _logger.LogInformation($"Convenio encontrado por query: {response.Value.Count}"); */
/*         return Result.Ok(response.Value); */
/*     } */

/*     public Task<Result> Update( */
/*         ConvenioUpdateDto request, Guid id) */
/*     { */
/*         throw new NotImplementedException(); */
/*     } */
/* } */