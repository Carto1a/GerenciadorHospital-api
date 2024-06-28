/* using Hospital.Application.Dto.Input.Convenios; */
/* using Hospital.Application.Exceptions; */
/* using Hospital.Domain.Entities; */
/* using Hospital.Domain.Repositories; */

/* using Microsoft.Extensions.Logging; */

/* namespace Hospital.Application.UseCases.Convenios; */
/* public class ConvenioCreateUseCase */
/* { */
/*     private readonly ILogger<ConvenioCreateUseCase> _logger; */
/*     private readonly IUnitOfWork _uow; */
/*     private readonly IConvenioRepository _convenioRepository; */
/*     public ConvenioCreateUseCase( */
/*         ILogger<ConvenioCreateUseCase> logger, */
/*         IUnitOfWork uow, */
/*         IConvenioRepository convenioRepository) */
/*     { */
/*         _logger = logger; */
/*         _uow = uow; */
/*         _convenioRepository = convenioRepository; */
/*     } */

/*     public async Task<Guid> Handler( */
/*         ConvenioCreateDto request) */
/*     { */
/*         _logger.LogInformation($"Criando convenio: {request.CNPJ}"); */
/*         var findConvenio = await _convenioRepository */
/*             .GetByCnpjAsync(request.CNPJ); */
/*         if (findConvenio != null) */
/*             throw new ApplicationLayerException( */
/*                 $"Convenio já existe: {request.CNPJ}", */
/*                 "Convenio já existe"); */

/*         var convenio = new Convenio(request); */

/*         var id = await _convenioRepository */
/*             .CreateAsync(convenio); */

/*         await _uow.SaveAsync(); */

/*         _logger.LogInformation($"Convenio criado: {request.CNPJ}"); */

/*         return id; */
/*     } */
/* } */