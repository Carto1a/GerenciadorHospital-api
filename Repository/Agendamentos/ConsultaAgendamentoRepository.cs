
/* using Hospital.Database; */
/* using Hospital.Models.Agendamentos; */
/* using Hospital.Models.Atendimento; */
/* using Hospital.Repository.Atendimentos.Interfaces; */


/* namespace Hospital.Repository.Agendamentos; */
/* public class ConsultaAgendamentoRepository */
/* : AgendamentoRepository< */
/*     Consulta, */
/*     ConsultaAgendamento>, */
/* IConsultaAgendamentoRepository */
/* { */
/*     private readonly ILogger<ConsultaAgendamentoRepository> _logger; */
/*     private readonly AppDbContext _ctx; */
/*     public ConsultaAgendamentoRepository( */
/*         AppDbContext context, */
/*         ILogger<ConsultaAgendamentoRepository> logger) */
/*     : base(context, logger) */
/*     { */
/*         _ctx = context; */
/*         _logger = logger; */
/*         _logger.LogDebug(1, $"NLog injected into ConsultaAgendamentoRepository"); */
/*     } */

/*     /1* public async Task<Result> CreateAgentamento( *1/ */
/*     /1*     ConsultaAgendamento agentamento) *1/ */
/*     /1* { *1/ */
/*     /1*     try *1/ */
/*     /1*     { *1/ */
/*     /1*         await _ctx.AgendamentosConsultas *1/ */
/*     /1*             .AddAsync(agentamento); *1/ */
/*     /1*         await _ctx.SaveChangesAsync(); *1/ */
/*     /1*         return Result.Ok(); *1/ */
/*     /1*     } *1/ */
/*     /1*     catch (Exception error) *1/ */
/*     /1*     { *1/ */
/*     /1*         // jeito preguisa das ideias *1/ */
/*     /1*         return Result.Fail(error.Message); *1/ */
/*     /1*     } *1/ */
/*     /1* } *1/ */

/*     /1* public async Task<Result<ConsultaAgendamento?>> GetAgendamentoById( *1/ */
/*     /1*     Guid id) *1/ */
/*     /1* { *1/ */
/*     /1*     try *1/ */
/*     /1*     { *1/ */
/*     /1*         var list = await _ctx.AgendamentosConsultas *1/ */
/*     /1*             .AsNoTracking() *1/ */
/*     /1*             .FirstOrDefaultAsync(e => e.Id == id); *1/ */
/*     /1*         return Result.Ok(list); *1/ */
/*     /1*     } *1/ */
/*     /1*     catch (Exception error) *1/ */
/*     /1*     { *1/ */
/*     /1*         return Result.Fail(error.Message); *1/ */
/*     /1*     } *1/ */
/*     /1* } *1/ */

/*     /1* public async Task<Result<List<ConsultaAgendamento>>> GetAgendamentoByQuery( *1/ */
/*     /1*     AgendamentoGetByQueryDto query) *1/ */
/*     /1* { *1/ */
/*     /1*     try *1/ */
/*     /1*     { *1/ */
/*     /1*         // TODO: adiciona pesquisa pela data de criação *1/ */
/*     /1*         var queryList = _ctx.AgendamentosConsultas.AsQueryable(); *1/ */
/*     /1*         if (query.MedicoId != null) *1/ */
/*     /1*             queryList = queryList.Where(e => *1/ */
/*     /1*                 e.MedicoId == query.MedicoId); *1/ */

/*     /1*         if (query.PacienteId != null) *1/ */
/*     /1*             queryList = queryList.Where(e => *1/ */
/*     /1*                 e.PacienteId == query.PacienteId); *1/ */

/*     /1*         if (query.MinDate != null) *1/ */
/*     /1*             queryList = queryList.Where( *1/ */
/*     /1*                 e => e.DataHora >= query.MinDate *1/ */
/*     /1*                 && e.DataHora <= query.MaxDate); *1/ */

/*     /1*         if (query.Limit == null || query.Page == null) *1/ */
/*     /1*             return Result.Fail("page e limit não deveriam ser nulls"); *1/ */

/*     /1*         var result = await queryList *1/ */
/*     /1*             .Skip((int)query.Page) *1/ */
/*     /1*             .Take((int)query.Limit) *1/ */
/*     /1*             .ToListAsync(); *1/ */

/*     /1*         return Result.Ok(result); *1/ */
/*     /1*     } *1/ */
/*     /1*     catch (Exception error) *1/ */
/*     /1*     { *1/ */
/*     /1*         return Result.Fail(error.Message); *1/ */
/*     /1*     } *1/ */
/*     /1* } *1/ */

/*     /1* public Result<List<ConsultaAgendamento>> GetAgendamentosByDate( *1/ */
/*     /1*     DateTime minDate, DateTime maxDate, int limit, int page = 0) *1/ */
/*     /1* { *1/ */
/*     /1*     try *1/ */
/*     /1*     { *1/ */
/*     /1*         var list = _ctx.AgendamentosConsultas *1/ */
/*     /1*             .Where(e => e.DataHora >= minDate && e.DataHora <= maxDate) *1/ */
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

/*     /1* public async Task<Result<List<ConsultaAgendamento>>> GetAgendamentosByMedico( *1/ */
/*     /1*     Guid medicoId, int limit, int page = 0) *1/ */
/*     /1* { *1/ */
/*     /1*     try *1/ */
/*     /1*     { *1/ */
/*     /1*         var list = await _ctx.AgendamentosConsultas *1/ */
/*     /1*             .Where(e => e.MedicoId == medicoId) *1/ */
/*     /1*             .Skip(page) *1/ */
/*     /1*             .Take(limit) *1/ */
/*     /1*             .ToListAsync(); *1/ */
/*     /1*         return Result.Ok(list); *1/ */
/*     /1*     } *1/ */
/*     /1*     catch (Exception error) *1/ */
/*     /1*     { *1/ */
/*     /1*         return Result.Fail(error.Message); *1/ */
/*     /1*     } *1/ */
/*     /1* } *1/ */

/*     /1* public Result<List<ConsultaAgendamento>> GetAgendamentosByPaciente( *1/ */
/*     /1*     Guid pacienteId, int limit, int page = 0) *1/ */
/*     /1* { *1/ */
/*     /1*     try *1/ */
/*     /1*     { *1/ */
/*     /1*         return _ctx.AgendamentosConsultas *1/ */
/*     /1*             .Where(e => e.PacienteId == pacienteId) *1/ */
/*     /1*             .Skip(page) *1/ */
/*     /1*             .Take(limit) *1/ */
/*     /1*             .ToList(); *1/ */
/*     /1*     } *1/ */
/*     /1*     catch (Exception error) *1/ */
/*     /1*     { *1/ */
/*     /1*         return Result.Fail(error.Message); *1/ */
/*     /1*     } *1/ */
/*     /1* } *1/ */

/*     /1* public async Task<Result> UpdateAgentamento( *1/ */
/*     /1*     ConsultaAgendamento NovoAgendamento) *1/ */
/*     /1* { *1/ */
/*     /1*     try *1/ */
/*     /1*     { *1/ */
/*     /1*         _ctx.AgendamentosConsultas.Update(NovoAgendamento); *1/ */
/*     /1*         await _ctx.SaveChangesAsync(); *1/ */

/*     /1*         return Result.Ok(); *1/ */
/*     /1*     } *1/ */
/*     /1*     catch (Exception error) *1/ */
/*     /1*     { *1/ */
/*     /1*         return Result.Fail(error.Message); *1/ */
/*     /1*     } *1/ */
/*     /1* } *1/ */
/* } */