/* using Hospital.Application.Dto.Input.Convenios; */
/* using Hospital.Application.Dto.Output.Convenios; */
/* using Hospital.Domain.Repositories; */
/* using Hospital.Domain.Validators; */

/* namespace Hospital.Application.UseCases.Convenios; */
/* public class ConvenioGetByQueryUseCase */
/* { */
/*     private readonly IConvenioRepository _convenioRepository; */
/*     public ConvenioGetByQueryUseCase( */
/*         IConvenioRepository convenioRepository) */
/*     { */
/*         _convenioRepository = convenioRepository; */
/*     } */

/*     public async Task<IEnumerable<ConvenioOutputDto>> Handler( */
/*         ConvenioGetByQueryDto query) */
/*     { */
/*         var validator = new DomainValidator("Não foi possível buscar convenios"); */
/*         // NOTE: colocar essas coisa no construtor da dto? */
/*         validator.Query((int)query.Limit!, (int)query.Page!); */
/*         if (query.CNPJ != null) */
/*             validator.Cnpj(query.CNPJ, "CNPJ inválido"); */

/*         if (query.Nome != null) */
/*         { */
/*             validator.NotNullOrEmpty(query.Nome, "Nome inválido"); */
/*             validator.MinLength(query.Nome, 2, "Nome inválido"); */
/*         } */

/*         // NOTE: break code execution if validation fails */
/*         validator.Check(); */

/*         var convenios = await _convenioRepository */
/*             .GetByQueryDtoAsync(query); */
/*         return convenios; */
/*     } */
/* } */