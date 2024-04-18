using FluentResults;
using Hospital.Database;
using Hospital.Dto.Atendimento.Get;
using Hospital.Models.Atendimento;
using Hospital.Repository.Atendimentos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Repository.Atendimentos;
public class AtendimentoRepository<T>
: IAtendimentoRepository<T>
    where T : Atendimento, new()
{
    private readonly ILogger<AtendimentoRepository<T>> _logger;
    private readonly AppDbContext _ctx;
    public AtendimentoRepository(
        AppDbContext context,
        ILogger<AtendimentoRepository<T>> logger)
    {
        _ctx = context;
        _logger = logger;
        _logger.LogDebug(1, $"NLog injected into AtendimentoRepository {nameof(T)}");
    }

    public async Task<Result<T>> Create(T etity)
    {
        try
        {
            var returnEntity = await _ctx.Set<T>()
                .AddAsync(etity);
            await _ctx.SaveChangesAsync();
            return Result.Ok(returnEntity.Entity);
        }
        catch (Exception error)
        {
            return Result.Fail(error.Message);
        }
    }

    public Result<List<T>> GetByDate(
        DateTime minDate, DateTime maxDate,
        int limit, int page = 0)
    {
        try
        {
            var list = _ctx.Set<T>()
                .Where(e => e.Inicio >= minDate && e.Inicio <= maxDate)
                .Skip(page)
                .Take(limit)
                .ToList();
            return Result.Ok(list);
        }
        catch (Exception error)
        {
            return Result.Fail(error.Message);
        }
    }

    public async Task<Result<T?>> GetById(Guid id)
    {
        try
        {
            var teste = typeof(T);
            var list = await _ctx.Set<T>()
                .FirstOrDefaultAsync(e => e.Id == id);
            return Result.Ok(list);
        }
        catch (Exception error)
        {
            return Result.Fail(error.Message);
        }
    }

    public Result<List<T>> GetByMedico(
        Guid medicoId, int limit, int page = 0)
    {
        try
        {
            var list = _ctx.Set<T>()
                .Where(e => e.MedicoId == medicoId)
                .Skip(page)
                .Take(limit)
                .ToList();
            return Result.Ok(list);
        }
        catch (Exception error)
        {
            return Result.Fail(error.Message);
        }
    }

    public Result<List<T>> GetByPaciente(
        Guid pacienteId, int limit, int page = 0)
    {
        try
        {
            var respose = _ctx.Set<T>()
                .Where(e => e.PacienteId == pacienteId)
                .Skip(page)
                .Take(limit)
                .ToList();

            return Result.Ok(respose);
        }
        catch (Exception error)
        {
            return Result.Fail(error.Message);
        }
    }

    public async Task<Result> Update(T entity)
    {
        try
        {
            _ctx.Set<T>().Update(entity);
            await _ctx.SaveChangesAsync();

            return Result.Ok();
        }
        catch (Exception error)
        {
            return Result.Fail(error.Message);
        }
    }

    public Result<List<T>> GetByQuery(
        AtendimentoGetByQueryDto query)
    {
        try
        {
            var queryList = _ctx.Set<T>().AsQueryable();
            if (query.MedicoId != null)
                queryList = queryList.Where(e =>
                    e.MedicoId == query.MedicoId);

            if (query.PacienteId != null)
                queryList = queryList.Where(e =>
                    e.PacienteId == query.PacienteId);

            if (query.MinDate != null)
                queryList = queryList.Where(
                    e => e.Inicio >= query.MinDate
                    && e.Inicio <= query.MaxDate);

            if (query.Limit == null || query.Page == null)
                return Result.Fail("page e limit não deveriam ser nulls");

            var result = queryList
                .Skip((int)query.Page)
                .Take((int)query.Limit)
                .ToList();

            return Result.Ok(result);
        }
        catch (Exception error)
        {
            return Result.Fail(error.Message);
        }
    }
}
