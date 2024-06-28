/* using Hospital.Application.Dto.Input.Authentications; */
/* using Hospital.Application.Dto.Output.Cadastros; */
/* using Hospital.Domain.Enums; */
/* using Hospital.Domain.Repositories; */
/* using Hospital.Domain.Repositories.Cadastros; */
/* using Hospital.Domain.Validators; */

/* namespace Hospital.Application.UseCases.Cadastros.Medicos; */
/* public class MedicoGetByQueryUseCase */
/* { */
/*     private readonly ILogger<MedicoGetByQueryUseCase> _logger; */
/*     private readonly IUnitOfWork _uow; */
/*     private readonly IMedicoRepository _medicoRepository; */
/*     public MedicoGetByQueryUseCase( */
/*         ILogger<MedicoGetByQueryUseCase> logger, */
/*         IUnitOfWork uow, */
/*         IMedicoRepository medicoRepository) */
/*     { */
/*         _logger = logger; */
/*         _uow = uow; */
/*         _medicoRepository = medicoRepository; */
/*     } */

/*     public async Task<IEnumerable<MedicoOutputDto>> Handler( */
/*         MedicoGetByQueryDto query) */
/*     { */
/*         _logger.LogInformation($"Buscando medicos: {query.Limit} - {query.Page}"); */

/*         var validator = new DomainValidator("Não foi possível buscar medicos"); */
/*         validator.Query((int)query.Limit!, (int)query.Page!); */

/*         if (query.Genero != null) */
/*             validator.isInEnum( */
/*                 query.Genero, */
/*                 typeof(GeneroEnum), */
/*                 "Genero inválido"); */

/*         validator.Check(); */

/*         var medicos = await _medicoRepository */
/*             .GetByQueryDtoAsync(query); */

/*         _logger.LogInformation($"Medicos encontrados: {medicos.Count}"); */
/*         return medicos; */
/*     } */
/* } */