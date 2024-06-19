using Hospital.Domain.Entities.Agendamentos;
using Hospital.Domain.Repositories;
using Hospital.Domain.Repositories.Agendamentos;

using Microsoft.EntityFrameworkCore;

namespace Hospital.Infrastructure.Database.Repositories.Agendamentos;
public abstract class AgendamentoRepository<TAgendamento, TQuery, TOut>
: Repository<TAgendamento, TQuery, TOut>,
IAgendamentoRepository<TAgendamento, TQuery, TOut>
where TAgendamento : Agendamento
where TQuery : class
where TOut : class
{
    private readonly AppDbContext _ctx;
    private readonly IUnitOfWork _uow;
    private readonly DbSet<TAgendamento> _dbSet;
    public AgendamentoRepository(
        AppDbContext context,
        IUnitOfWork uow) : base(context, uow)
    {
        _ctx = context;
        _uow = uow;
        _dbSet = _ctx.Set<TAgendamento>();
    }

    public async Task<Guid> CreateAsync(
        TAgendamento agentamento)
    {
        try
        {
            var result = await _dbSet.AddAsync(agentamento);
            return result.Entity.Id;
        }
        catch (Exception error)
        {
            _uow.Dispose();
            throw new Exception(error.Message);
        }
    }

    public Task<List<TAgendamento>> GetByDataHoraMedicoAsync(
        DateTime dataHora, Guid medicoId)
    {
        try
        {
            var list = _dbSet
                .Where(e => e.MedicoId == medicoId)
                .Where(e =>
                    e.DataHora > dataHora.AddMinutes(-30) &&
                    e.DataHora < dataHora.AddMinutes(30))
                .ToListAsync();

            return list;
        }
        catch (Exception error)
        {
            _uow.Dispose();
            throw new Exception(error.Message);
        }
    }

    /* { */
    /*     try */
    /*     { */
    /*         var queryCtx = _ctx.Set<TAgendamento>().AsQueryable(); */
    /*         if (query.MedicoId != null) */
    /*             queryCtx = queryCtx.Where(e => */
    /*                 e.MedicoId == query.MedicoId); */

    /*         if (query.PacienteId != null) */
    /*             queryCtx = queryCtx.Where(e => */
    /*                 e.PacienteId == query.PacienteId); */

    /*         if (query.MinDateCriado != null) */
    /*             queryCtx = queryCtx.Where(e => */
    /*                 e.Criado >= query.MinDateCriado); */

    /*         if (query.MaxDateCriado != null) */
    /*             queryCtx = queryCtx.Where(e => */
    /*                 e.Criado <= query.MaxDateCriado); */

    /*         if (query.ConvencioId != null) */
    /*             queryCtx = queryCtx.Where(e => */
    /*                 e.ConvenioId == query.ConvencioId); */

    /*         if (query.MinDataHora != null) */
    /*             queryCtx = queryCtx.Where(e => */
    /*                 e.DataHora >= query.MinDataHora); */

    /*         if (query.MaxDataHora != null) */
    /*             queryCtx = queryCtx.Where(e => */
    /*                 e.DataHora <= query.MaxDataHora); */

    /*         if (query.Status != null) */
    /*             queryCtx = queryCtx.Where(e => */
    /*                 e.Status == query.Status); */

    /*         var result = await queryCtx */
    /*             .Skip((int)query.Page!) */
    /*             .Take((int)query.Limit!) */
    /*             .Select(e => new AgendamentoOutputDto(e)) */
    /*             .ToListAsync(); */

    /*         return result; */
    /*     } */
    /*     catch (Exception error) */
    /*     { */
    /*         _uow.Dispose(); */
    /*         throw new Exception(error.Message); */
    /*     } */
    /* } */
}