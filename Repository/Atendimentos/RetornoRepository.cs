
/* using Hospital.Database; */
/* using Hospital.Models.Atendimento; */
/* using Hospital.Repository.Atendimentos.Interfaces; */


/* namespace Hospital.Repository.Atendimentos; */
/* public class RetornoRepository */
/* : AtendimentoRepository<Retorno>, */
/* IRetornoRepository */
/* { */
/*     private readonly ILogger<RetornoRepository> _logger; */
/*     private readonly AppDbContext _ctx; */
/*     public RetornoRepository( */
/*         AppDbContext context, */
/*         ILogger<RetornoRepository> logger) */
/*     : base(context, logger) */
/*     { */
/*         _ctx = context; */
/*         _logger = logger; */
/*         _logger.LogDebug(1, $"NLog injected into RetornoRepository"); */
/*     } */

/*     /1* public async Task<Result<Retorno>> Create(Retorno etity) *1/ */
/*     /1* { *1/ */
/*     /1*     try *1/ */
/*     /1*     { *1/ */
/*     /1*         var returnEntity = await _ctx.Retornos *1/ */
/*     /1*             .AddAsync(etity); *1/ */
/*     /1*         await _ctx.SaveChangesAsync(); *1/ */
/*     /1*         return Result.Ok(returnEntity.Entity); *1/ */
/*     /1*     } *1/ */
/*     /1*     catch (Exception error) *1/ */
/*     /1*     { *1/ */
/*     /1*         return Result.Fail(error.Message); *1/ */
/*     /1*     } *1/ */
/*     /1* } *1/ */

/*     /1* public Result<List<Retorno>> GetByDate( *1/ */
/*     /1*     DateTime minDate, DateTime maxDate, *1/ */
/*     /1*     int limit, int page = 0) *1/ */
/*     /1* { *1/ */
/*     /1*     try *1/ */
/*     /1*     { *1/ */
/*     /1*         var list = _ctx.Retornos *1/ */
/*     /1*             .Where(e => e.Inicio >= minDate && e.Inicio <= maxDate) *1/ */
/*     /1*             .Skip(page) *1/ */
/*     /1*             .Take(limit) *1/ */
/*     /1*             .ToList(); *1/ */
/*     /1*         return Result.Ok(list); *1/ */
/*     /1*     } *1/ */
/*     /1*     catch (Exception error) *1/ */
/*     /1*     { *1/ */
/*     /1*         return Result.Fail(error.Message); *1/ */
/*     /1*     } *1/ */
/*     /1* } *1/ */

/*     /1* public async Task<Result<Retorno?>> GetById(Guid id) *1/ */
/*     /1* { *1/ */
/*     /1*     try *1/ */
/*     /1*     { *1/ */
/*     /1*         var teste = typeof(Retorno); *1/ */
/*     /1*         var list = await _ctx.Retornos *1/ */
/*     /1*             .FirstOrDefaultAsync(e => e.Id == id); *1/ */
/*     /1*         return Result.Ok(list); *1/ */
/*     /1*     } *1/ */
/*     /1*     catch (Exception error) *1/ */
/*     /1*     { *1/ */
/*     /1*         return Result.Fail(error.Message); *1/ */
/*     /1*     } *1/ */
/*     /1* } *1/ */

/*     /1* public Result<List<Retorno>> GetByMedico( *1/ */
/*     /1*     Guid medicoId, int limit, int page = 0) *1/ */
/*     /1* { *1/ */
/*     /1*     try *1/ */
/*     /1*     { *1/ */
/*     /1*         var list = _ctx.Retornos *1/ */
/*     /1*             .Where(e => e.MedicoId == medicoId) *1/ */
/*     /1*             .Skip(page) *1/ */
/*     /1*             .Take(limit) *1/ */
/*     /1*             .ToList(); *1/ */
/*     /1*         return Result.Ok(list); *1/ */
/*     /1*     } *1/ */
/*     /1*     catch (Exception error) *1/ */
/*     /1*     { *1/ */
/*     /1*         return Result.Fail(error.Message); *1/ */
/*     /1*     } *1/ */
/*     /1* } *1/ */

/*     /1* public Result<List<Retorno>> GetByPaciente( *1/ */
/*     /1*     Guid pacienteId, int limit, int page = 0) *1/ */
/*     /1* { *1/ */
/*     /1*     try *1/ */
/*     /1*     { *1/ */
/*     /1*         var respose = _ctx.Retornos *1/ */
/*     /1*             .Where(e => e.PacienteId == pacienteId) *1/ */
/*     /1*             .Skip(page) *1/ */
/*     /1*             .Take(limit) *1/ */
/*     /1*             .ToList(); *1/ */

/*     /1*         return Result.Ok(respose); *1/ */
/*     /1*     } *1/ */
/*     /1*     catch (Exception error) *1/ */
/*     /1*     { *1/ */
/*     /1*         return Result.Fail(error.Message); *1/ */
/*     /1*     } *1/ */
/*     /1* } *1/ */

/*     /1* public async Task<Result> Update(Retorno entity) *1/ */
/*     /1* { *1/ */
/*     /1*     try *1/ */
/*     /1*     { *1/ */
/*     /1*         _ctx.Retornos.Update(entity); *1/ */
/*     /1*         await _ctx.SaveChangesAsync(); *1/ */

/*     /1*         return Result.Ok(); *1/ */
/*     /1*     } *1/ */
/*     /1*     catch (Exception error) *1/ */
/*     /1*     { *1/ */
/*     /1*         return Result.Fail(error.Message); *1/ */
/*     /1*     } *1/ */
/*     /1* } *1/ */

/*     /1* public Result<List<Retorno>> GetByQuery( *1/ */
/*     /1*     AtendimentoGetByQueryDto query) *1/ */
/*     /1* { *1/ */
/*     /1*     try *1/ */
/*     /1*     { *1/ */
/*     /1*         var queryList = _ctx.Retornos.AsQueryable(); *1/ */
/*     /1*         if (query.MedicoId != null) *1/ */
/*     /1*             queryList = queryList.Where(e => *1/ */
/*     /1*                 e.MedicoId == query.MedicoId); *1/ */

/*     /1*         if (query.PacienteId != null) *1/ */
/*     /1*             queryList = queryList.Where(e => *1/ */
/*     /1*                 e.PacienteId == query.PacienteId); *1/ */

/*     /1*         if (query.MinDate != null) *1/ */
/*     /1*             queryList = queryList.Where( *1/ */
/*     /1*                 e => e.Inicio >= query.MinDate *1/ */
/*     /1*                 && e.Inicio <= query.MaxDate); *1/ */

/*     /1*         if (query.Limit == null || query.Page == null) *1/ */
/*     /1*             return Result.Fail("page e limit não deveriam ser nulls"); *1/ */

/*     /1*         var result = queryList *1/ */
/*     /1*             .Skip((int)query.Page) *1/ */
/*     /1*             .Take((int)query.Limit) *1/ */
/*     /1*             .ToList(); *1/ */

/*     /1*         return Result.Ok(result); *1/ */
/*     /1*     } *1/ */
/*     /1*     catch (Exception error) *1/ */
/*     /1*     { *1/ */
/*     /1*         return Result.Fail(error.Message); *1/ */
/*     /1*     } *1/ */

/*     /1* } *1/ */
/* } */