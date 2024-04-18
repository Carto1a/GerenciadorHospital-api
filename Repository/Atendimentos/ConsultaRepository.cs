
using Hospital.Database;
using Hospital.Models.Atendimento;
using Hospital.Repository.Atendimentos.Interfaces;


namespace Hospital.Repository.Atendimentos;
public class ConsultaRepository
: AtendimentoRepository<Consulta>,
IConsultaRepository
{
    private readonly ILogger<ConsultaRepository> _logger;
    private readonly AppDbContext _ctx;
    public ConsultaRepository(
        AppDbContext context,
        ILogger<ConsultaRepository> logger)
    : base(context, logger)
    {
        _ctx = context;
        _logger = logger;
        _logger.LogDebug(1, $"NLog injected into ConsultaRepository");
    }

    /* public async Task<Result<Consulta>> Create(Consulta etity) */
    /* { */
    /*     try */
    /*     { */
    /*         var returnEntity = await _ctx.Consultas */
    /*             .AddAsync(etity); */
    /*         await _ctx.SaveChangesAsync(); */
    /*         return Result.Ok(returnEntity.Entity); */
    /*     } */
    /*     catch (Exception error) */
    /*     { */
    /*         return Result.Fail(error.Message); */
    /*     } */
    /* } */

    /* public Result<List<Consulta>> GetByDate( */
    /*     DateTime minDate, DateTime maxDate, */
    /*     int limit, int page = 0) */
    /* { */
    /*     try */
    /*     { */
    /*         var list = _ctx.Consultas */
    /*             .Where(e => e.Inicio >= minDate && e.Inicio <= maxDate) */
    /*             .Skip(page) */
    /*             .Take(limit) */
    /*             .ToList(); */
    /*         return Result.Ok(list); */
    /*     } */
    /*     catch (Exception error) */
    /*     { */
    /*         return Result.Fail(error.Message); */
    /*     } */
    /* } */

    /* public async Task<Result<Consulta?>> GetById(Guid id) */
    /* { */
    /*     try */
    /*     { */
    /*         var list = await _ctx.Consultas */
    /*             .FirstOrDefaultAsync(e => e.Id == id); */
    /*         return Result.Ok(list); */
    /*     } */
    /*     catch (Exception error) */
    /*     { */
    /*         return Result.Fail(error.Message); */
    /*     } */
    /* } */

    /* public Result<List<Consulta>> GetByMedico( */
    /*     Guid medicoId, int limit, int page = 0) */
    /* { */
    /*     try */
    /*     { */
    /*         var list = _ctx.Consultas */
    /*             .Where(e => e.MedicoId == medicoId) */
    /*             .Skip(page) */
    /*             .Take(limit) */
    /*             .ToList(); */
    /*         return Result.Ok(list); */
    /*     } */
    /*     catch (Exception error) */
    /*     { */
    /*         return Result.Fail(error.Message); */
    /*     } */
    /* } */

    /* public Result<List<Consulta>> GetByPaciente( */
    /*     Guid pacienteId, int limit, int page = 0) */
    /* { */
    /*     try */
    /*     { */
    /*         var respose = _ctx.Consultas */
    /*             .Where(e => e.PacienteId == pacienteId) */
    /*             .Skip(page) */
    /*             .Take(limit) */
    /*             .ToList(); */

    /*         return Result.Ok(respose); */
    /*     } */
    /*     catch (Exception error) */
    /*     { */
    /*         return Result.Fail(error.Message); */
    /*     } */
    /* } */

    /* public async Task<Result> Update(Consulta entity) */
    /* { */
    /*     try */
    /*     { */
    /*         _ctx.Consultas.Update(entity); */
    /*         await _ctx.SaveChangesAsync(); */

    /*         return Result.Ok(); */
    /*     } */
    /*     catch (Exception error) */
    /*     { */
    /*         return Result.Fail(error.Message); */
    /*     } */
    /* } */

    /* public Result<List<Consulta>> GetByQuery( */
    /*     AtendimentoGetByQueryDto query) */
    /* { */
    /*     try */
    /*     { */
    /*         var queryList = _ctx.Consultas.AsQueryable(); */
    /*         if (query.MedicoId != null) */
    /*             queryList = queryList.Where(e => */
    /*                 e.MedicoId == query.MedicoId); */

    /*         if (query.PacienteId != null) */
    /*             queryList = queryList.Where(e => */
    /*                 e.PacienteId == query.PacienteId); */

    /*         if (query.MinDate != null) */
    /*             queryList = queryList.Where( */
    /*                 e => e.Inicio >= query.MinDate */
    /*                 && e.Inicio <= query.MaxDate); */

    /*         if (query.Limit == null || query.Page == null) */
    /*             return Result.Fail("page e limit não deveriam ser nulls"); */

    /*         var result = queryList */
    /*             .Skip((int)query.Page) */
    /*             .Take((int)query.Limit) */
    /*             .ToList(); */

    /*         return Result.Ok(result); */
    /*     } */
    /*     catch (Exception error) */
    /*     { */
    /*         return Result.Fail(error.Message); */
    /*     } */

    /* } */
}