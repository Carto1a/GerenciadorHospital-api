/* using Hospital.Application.Dto.Input.Medicamentos; */
/* using Hospital.Domain.Entities.Medicamentos; */
/* using Hospital.Domain.Enums; */
/* using Hospital.Domain.Exceptions; */
/* using Hospital.Domain.Repositories; */
/* using Hospital.Infrastructure.Database; */

/* namespace Hospital.Application.UseCases.Medicamentos; */
/* public class MedicamentoLoteCreateUseCase */
/* { */
/*     private readonly ILogger<MedicamentoLoteCreateUseCase> _logger; */
/*     private readonly AppDbContext _context; */
/*     private readonly IUnitOfWork _uow; */
/*     private readonly IMedicamentoRepository _medicamentoRepository; */
/*     private readonly IMedicamentoLoteRepository _medicamentoLoteRepository; */
/*     public MedicamentoLoteCreateUseCase( */
/*         ILogger<MedicamentoLoteCreateUseCase> logger, */
/*         AppDbContext context, */
/*         IUnitOfWork uow, */
/*         IMedicamentoRepository medicamentoRepository, */
/*         IMedicamentoLoteRepository medicamentoLoteRepository) */
/*     { */
/*         _logger = logger; */
/*         _context = context; */
/*         _uow = uow; */
/*         _medicamentoRepository = medicamentoRepository; */
/*         _medicamentoLoteRepository = medicamentoLoteRepository; */
/*     } */

/*     public async Task<Guid> Handler( */
/*         MedicamentoLoteCreateDto request) */
/*     { */
/*         _logger.LogInformation($"Criando lote de medicamento: {request.Codigo}"); */
/*         var medicamento = await _medicamentoRepository */
/*             .GetByIdAsync(request.MedicamentoId); */
/*         if (medicamento == null) */
/*             throw new ApplicationLayerException( */
/*                 $"Medicamento de id não existe, Não foi possivel criar lote: {request.MedicamentoId}.", */
/*                 "Medicamento não encontrado."); */

/*         var medicamentoLote = new MedicamentoLote(request); */
/*         var id = await _medicamentoLoteRepository */
/*             .CreateAsync(medicamentoLote); */

/*         if (medicamentoLote.Status != MedicamentoLoteStatus.Vencido) */
/*             medicamento.Quantidade += medicamentoLote.Quantidade; */

/*         medicamento.UpdateStatus(); */
/*         _medicamentoRepository.UpdateAsync(medicamento); */

/*         await _uow.SaveAsync(); */

/*         _logger.LogInformation($"Lote de medicamento criado: {request.Codigo}"); */
/*         return id; */
/*     } */
/* } */