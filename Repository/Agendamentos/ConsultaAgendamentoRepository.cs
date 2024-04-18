
using Hospital.Database;
using Hospital.Models.Agendamentos;
using Hospital.Models.Atendimento;
using Hospital.Repository.Atendimentos.Interfaces;


namespace Hospital.Repository.Agendamentos;
public class ConsultaAgendamentoRepository
: AgendamentoRepository<
    Consulta,
    ConsultaAgendamento>,
IConsultaAgendamentoRepository
{
    private readonly ILogger<ConsultaAgendamentoRepository> _logger;
    private readonly AppDbContext _ctx;
    public ConsultaAgendamentoRepository(
        AppDbContext context,
        ILogger<ConsultaAgendamentoRepository> logger)
    : base(context, logger)
    {
        _ctx = context;
        _logger = logger;
        _logger.LogDebug(1, $"NLog injected into ConsultaAgendamentoRepository");
    }

    /* public async Task<Result> CreateAgentamento( */
    /*     ConsultaAgendamento agentamento) */
    /* { */
    /*     try */
    /*     { */
    /*         await _ctx.AgendamentosConsultas */
    /*             .AddAsync(agentamento); */
    /*         await _ctx.SaveChangesAsync(); */
    /*         return Result.Ok(); */
    /*     } */
    /*     catch (Exception error) */
    /*     { */
    /*         // jeito preguisa das ideias */
    /*         return Result.Fail(error.Message); */
    /*     } */
    /* } */

    /* public async Task<Result<ConsultaAgendamento?>> GetAgendamentoById( */
    /*     Guid id) */
    /* { */
    /*     try */
    /*     { */
    /*         var list = await _ctx.AgendamentosConsultas */
    /*             .AsNoTracking() */
    /*             .FirstOrDefaultAsync(e => e.Id == id); */
    /*         return Result.Ok(list); */
    /*     } */
    /*     catch (Exception error) */
    /*     { */
    /*         return Result.Fail(error.Message); */
    /*     } */
    /* } */

    /* public async Task<Result<List<ConsultaAgendamento>>> GetAgendamentoByQuery( */
    /*     AgendamentoGetByQueryDto query) */
    /* { */
    /*     try */
    /*     { */
    /*         // TODO: adiciona pesquisa pela data de criação */
    /*         var queryList = _ctx.AgendamentosConsultas.AsQueryable(); */
    /*         if (query.MedicoId != null) */
    /*             queryList = queryList.Where(e => */
    /*                 e.MedicoId == query.MedicoId); */

    /*         if (query.PacienteId != null) */
    /*             queryList = queryList.Where(e => */
    /*                 e.PacienteId == query.PacienteId); */

    /*         if (query.MinDate != null) */
    /*             queryList = queryList.Where( */
    /*                 e => e.DataHora >= query.MinDate */
    /*                 && e.DataHora <= query.MaxDate); */

    /*         if (query.Limit == null || query.Page == null) */
    /*             return Result.Fail("page e limit não deveriam ser nulls"); */

    /*         var result = await queryList */
    /*             .Skip((int)query.Page) */
    /*             .Take((int)query.Limit) */
    /*             .ToListAsync(); */

    /*         return Result.Ok(result); */
    /*     } */
    /*     catch (Exception error) */
    /*     { */
    /*         return Result.Fail(error.Message); */
    /*     } */
    /* } */

    /* public Result<List<ConsultaAgendamento>> GetAgendamentosByDate( */
    /*     DateTime minDate, DateTime maxDate, int limit, int page = 0) */
    /* { */
    /*     try */
    /*     { */
    /*         var list = _ctx.AgendamentosConsultas */
    /*             .Where(e => e.DataHora >= minDate && e.DataHora <= maxDate) */
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

    /* public async Task<Result<List<ConsultaAgendamento>>> GetAgendamentosByMedico( */
    /*     Guid medicoId, int limit, int page = 0) */
    /* { */
    /*     try */
    /*     { */
    /*         var list = await _ctx.AgendamentosConsultas */
    /*             .Where(e => e.MedicoId == medicoId) */
    /*             .Skip(page) */
    /*             .Take(limit) */
    /*             .ToListAsync(); */
    /*         return Result.Ok(list); */
    /*     } */
    /*     catch (Exception error) */
    /*     { */
    /*         return Result.Fail(error.Message); */
    /*     } */
    /* } */

    /* public Result<List<ConsultaAgendamento>> GetAgendamentosByPaciente( */
    /*     Guid pacienteId, int limit, int page = 0) */
    /* { */
    /*     try */
    /*     { */
    /*         return _ctx.AgendamentosConsultas */
    /*             .Where(e => e.PacienteId == pacienteId) */
    /*             .Skip(page) */
    /*             .Take(limit) */
    /*             .ToList(); */
    /*     } */
    /*     catch (Exception error) */
    /*     { */
    /*         return Result.Fail(error.Message); */
    /*     } */
    /* } */

    /* public async Task<Result> UpdateAgentamento( */
    /*     ConsultaAgendamento NovoAgendamento) */
    /* { */
    /*     try */
    /*     { */
    /*         _ctx.AgendamentosConsultas.Update(NovoAgendamento); */
    /*         await _ctx.SaveChangesAsync(); */

    /*         return Result.Ok(); */
    /*     } */
    /*     catch (Exception error) */
    /*     { */
    /*         return Result.Fail(error.Message); */
    /*     } */
    /* } */
}