using FluentResults;

using Hospital.Database;
using Hospital.Dto.Atendimento.Get;
using Hospital.Models.Atendimento;
using Hospital.Repository.Atendimentos.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace Hospital.Repository.Atendimentos;
public class RetornoRepository
: AtendimentoRepository<Retorno>,
IRetornoRepository
{
    private readonly ILogger<RetornoRepository> _logger;
    private readonly AppDbContext _ctx;
    public RetornoRepository(
        AppDbContext context,
        ILogger<RetornoRepository> logger)
    : base(context, logger)
    {
        _ctx = context;
        _logger = logger;
        _logger.LogDebug(1, $"NLog injected into RetornoRepository");
    }

    public async Task<Result<Retorno>> Create(Retorno etity)
    {
        try
        {
            var returnEntity = await _ctx.Retornos
                .AddAsync(etity);
            await _ctx.SaveChangesAsync();
            return Result.Ok(returnEntity.Entity);
        }
        catch (Exception error)
        {
            return Result.Fail(error.Message);
        }
    }

    public Result<List<Retorno>> GetByDate(
        DateTime minDate, DateTime maxDate,
        int limit, int page = 0)
    {
        try
        {
            var list = _ctx.Retornos
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

    public async Task<Result<Retorno?>> GetById(Guid id)
    {
        try
        {
            var teste = typeof(Retorno);
            var list = await _ctx.Retornos
                .FirstOrDefaultAsync(e => e.Id == id);
            return Result.Ok(list);
        }
        catch (Exception error)
        {
            return Result.Fail(error.Message);
        }
    }

    public Result<List<Retorno>> GetByMedico(
        Guid medicoId, int limit, int page = 0)
    {
        try
        {
            var list = _ctx.Retornos
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

    public Result<List<Retorno>> GetByPaciente(
        Guid pacienteId, int limit, int page = 0)
    {
        try
        {
            var respose = _ctx.Retornos
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

    public async Task<Result> Update(Retorno entity)
    {
        try
        {
            _ctx.Retornos.Update(entity);
            await _ctx.SaveChangesAsync();

            return Result.Ok();
        }
        catch (Exception error)
        {
            return Result.Fail(error.Message);
        }
    }

    public Result<List<Retorno>> GetByQuery(
        AtendimentoGetByQueryDto query)
    {
        try
        {
            var queryList = _ctx.Retornos.AsQueryable();
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