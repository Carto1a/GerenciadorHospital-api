/* using Hospital.Application.Dto.Input.Medicamentos; */
/* using Hospital.Domain.Repositories; */

/* using Microsoft.Extensions.Logging; */

/* namespace Hospital.Application.UseCases.Medicamentos; */
/* public class MedicamentoCreateUseCase */
/* { */
/*     private readonly ILogger<MedicamentoCreateUseCase> _logger; */
/*     private readonly IUnitOfWork _uow; */
/*     private readonly IMedicamentoRepository _medicamentoRepository; */
/*     public MedicamentoCreateUseCase( */
/*         ILogger<MedicamentoCreateUseCase> logger, */
/*         IUnitOfWork uow, */
/*         IMedicamentoRepository medicamentoRepository) */
/*     { */
/*         _logger = logger; */
/*         _uow = uow; */
/*         _medicamentoRepository = medicamentoRepository; */
/*     } */

/*     public async Task<Guid> Handler( */
/*         MedicamentoCreateDto request) */
/*     { */
/*         _logger.LogInformation($"Criando medicamento: {request.Nome}"); */
/*         var medicamento = new Medicamento(request); */
/*         medicamento.UpdateStatus(); */

/*         var id = await _medicamentoRepository.CreateAsync(medicamento); */

/*         _logger.LogInformation($"Medicamento criado: {request.Nome}"); */

/*         return id; */
/*     } */
/* } */