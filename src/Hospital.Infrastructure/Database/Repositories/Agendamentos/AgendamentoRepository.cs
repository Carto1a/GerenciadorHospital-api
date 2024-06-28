/* using Hospital.Domain.Entities.Agendamentos; */
/* using Hospital.Domain.Repositories; */
/* using Hospital.Domain.Repositories.Agendamentos; */

/* using Microsoft.EntityFrameworkCore; */

/* namespace Hospital.Infrastructure.Database.Repositories.Agendamentos; */
/* public abstract class AgendamentoRepository<TAgendamento, TQuery, TOut> */
/* : Repository<TAgendamento, TQuery, TOut>, */
/* IAgendamentoRepository<TAgendamento, TQuery, TOut> */
/* where TAgendamento : Agendamento */
/* where TQuery : class */
/* where TOut : class */
/* { */
/*     private readonly AppDbContext _ctx; */
/*     private readonly IUnitOfWork _uow; */
/*     private readonly DbSet<TAgendamento> _dbSet; */
/*     public AgendamentoRepository( */
/*         AppDbContext context, */
/*         IUnitOfWork uow) : base(context, uow) */
/*     { */
/*         _ctx = context; */
/*         _uow = uow; */
/*         _dbSet = _ctx.Set<TAgendamento>(); */
/*     } */

/*     public async Task<Guid> CreateAsync( */
/*         TAgendamento agentamento) */
/*     { */
/*         try */
/*         { */
/*             var result = await _dbSet.AddAsync(agentamento); */
/*             return result.Entity.Id; */
/*         } */
/*         catch (Exception error) */
/*         { */
/*             _uow.Dispose(); */
/*             throw new Exception(error.Message); */
/*         } */
/*     } */

/*     public Task<List<TAgendamento>> GetByDataHoraMedicoAsync( */
/*         DateTime dataHora, Guid medicoId) */
/*     { */
/*         try */
/*         { */
/*             var list = _dbSet */
/*                 .Where(e => e.MedicoId == medicoId) */
/*                 .Where(e => */
/*                     e.DataHora > dataHora.AddMinutes(-30) && */
/*                     e.DataHora < dataHora.AddMinutes(30)) */
/*                 .ToListAsync(); */

/*             return list; */
/*         } */
/*         catch (Exception error) */
/*         { */
/*             _uow.Dispose(); */
/*             throw new Exception(error.Message); */
/*         } */
/*     } */

/*     /1* { *1/ */
/*     /1*     try *1/ */
/*     /1*     { *1/ */
/*     /1*         var queryCtx = _ctx.Set<TAgendamento>().AsQueryable(); *1/ */
/*     /1*         if (query.MedicoId != null) *1/ */
/*     /1*             queryCtx = queryCtx.Where(e => *1/ */
/*     /1*                 e.MedicoId == query.MedicoId); *1/ */

/*     /1*         if (query.PacienteId != null) *1/ */
/*     /1*             queryCtx = queryCtx.Where(e => *1/ */
/*     /1*                 e.PacienteId == query.PacienteId); *1/ */

/*     /1*         if (query.MinDateCriado != null) *1/ */
/*     /1*             queryCtx = queryCtx.Where(e => *1/ */
/*     /1*                 e.Criado >= query.MinDateCriado); *1/ */

/*     /1*         if (query.MaxDateCriado != null) *1/ */
/*     /1*             queryCtx = queryCtx.Where(e => *1/ */
/*     /1*                 e.Criado <= query.MaxDateCriado); *1/ */

/*     /1*         if (query.ConvencioId != null) *1/ */
/*     /1*             queryCtx = queryCtx.Where(e => *1/ */
/*     /1*                 e.ConvenioId == query.ConvencioId); *1/ */

/*     /1*         if (query.MinDataHora != null) *1/ */
/*     /1*             queryCtx = queryCtx.Where(e => *1/ */
/*     /1*                 e.DataHora >= query.MinDataHora); *1/ */

/*     /1*         if (query.MaxDataHora != null) *1/ */
/*     /1*             queryCtx = queryCtx.Where(e => *1/ */
/*     /1*                 e.DataHora <= query.MaxDataHora); *1/ */

/*     /1*         if (query.Status != null) *1/ */
/*     /1*             queryCtx = queryCtx.Where(e => *1/ */
/*     /1*                 e.Status == query.Status); *1/ */

/*     /1*         var result = await queryCtx *1/ */
/*     /1*             .Skip((int)query.Page!) *1/ */
/*     /1*             .Take((int)query.Limit!) *1/ */
/*     /1*             .Select(e => new AgendamentoOutputDto(e)) *1/ */
/*     /1*             .ToListAsync(); *1/ */

/*     /1*         return result; *1/ */
/*     /1*     } *1/ */
/*     /1*     catch (Exception error) *1/ */
/*     /1*     { *1/ */
/*     /1*         _uow.Dispose(); *1/ */
/*     /1*         throw new Exception(error.Message); *1/ */
/*     /1*     } *1/ */
/*     /1* } *1/ */
/* } */