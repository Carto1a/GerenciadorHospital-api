/* using Hospital.Application.Dto.Input.Agendamentos; */
/* using Hospital.Application.Dto.Output.Agendamentos; */
/* using Hospital.Domain.Entities.Agendamentos; */
/* using Hospital.Domain.Repositories; */
/* using Hospital.Domain.Repositories.Agendamentos; */

/* using Microsoft.EntityFrameworkCore; */

/* namespace Hospital.Infrastructure.Database.Repositories.Agendamentos; */
/* public class RetornoAgendamentoRepository */
/* : AgendamentoRepository<RetornoAgendamento, AgendamentoRetornoGetByQuery, AgendamentoRetornoOutputDto>, */
/* IRetornoAgendamentoRepository */
/* { */
/*     private readonly AppDbContext _ctx; */
/*     private readonly IUnitOfWork _uow; */
/*     public RetornoAgendamentoRepository( */
/*         AppDbContext context, */
/*         IUnitOfWork uow) */
/*     : base(context, uow) */
/*     { */
/*         _ctx = context; */
/*         _uow = uow; */
/*     } */

/*     public override Task<List<AgendamentoRetornoOutputDto>> GetByQueryDtoAsync(AgendamentoRetornoGetByQuery query) */
/*     { */
/*         try */
/*         { */
/*             var queryCtx = _ctx.AgendamentosRetornos.AsQueryable(); */
/*             if (query.MedicoId != null) */
/*                 queryCtx = queryCtx.Where(e => */
/*                     e.MedicoId == query.MedicoId); */

/*             if (query.PacienteId != null) */
/*                 queryCtx = queryCtx.Where(e => */
/*                     e.PacienteId == query.PacienteId); */

/*             if (query.MinDateCriado != null) */
/*                 queryCtx = queryCtx.Where(e => */
/*                     e.Criado >= query.MinDateCriado); */

/*             if (query.MaxDateCriado != null) */
/*                 queryCtx = queryCtx.Where(e => */
/*                     e.Criado <= query.MaxDateCriado); */

/*             if (query.ConvencioId != null) */
/*                 queryCtx = queryCtx.Where(e => */
/*                     e.ConvenioId == query.ConvencioId); */

/*             if (query.MinDataHora != null) */
/*                 queryCtx = queryCtx.Where(e => */
/*                     e.DataHora >= query.MinDataHora); */

/*             if (query.MaxDataHora != null) */
/*                 queryCtx = queryCtx.Where(e => */
/*                     e.DataHora <= query.MaxDataHora); */

/*             if (query.Status != null) */
/*                 queryCtx = queryCtx.Where(e => */
/*                     e.Status == query.Status); */

/*             var result = queryCtx */
/*                 .Skip((int)query.Page!) */
/*                 .Take((int)query.Limit!) */
/*                 .Select(e => new AgendamentoRetornoOutputDto(e)); */

/*             return result.ToListAsync(); */
/*         } */
/*         catch (Exception error) */
/*         { */
/*             _uow.Dispose(); */
/*             throw new Exception(error.Message); */
/*         } */
/*     } */
/* } */