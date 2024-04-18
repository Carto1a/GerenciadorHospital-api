using FluentResults;
using Microsoft.EntityFrameworkCore;
using Hospital.Models.Atendimento;
using Hospital.Database;
using Hospital.Repository.Atendimentos.Interfaces;
using Hospital.Dto.Atendimento.Get;

namespace Hospital.Repository.Atendimentos;
public class ConsultaRepository
: IConsultaRepository
{
    private readonly AppDbContext _ctx;
    public ConsultaRepository(AppDbContext context)
    {
        _ctx = context;
    }

    public async Task<Result<Consulta>> Create(Consulta etity)
    {
        try
        {
            var returnEntity = await _ctx.Consultas
                .AddAsync(etity);
            await _ctx.SaveChangesAsync();
            return Result.Ok(returnEntity.Entity);
        }
        catch (Exception error)
        {
            return Result.Fail(error.Message);
        }
    }

    public Result<List<Consulta>> GetByDate(
        DateTime minDate, DateTime maxDate,
        int limit, int page = 0)
    {
        try
        {
            var list = _ctx.Consultas
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

    public async Task<Result<Consulta?>> GetById(int id)
    {
        try
        {
            var list = await _ctx.Consultas
                .FirstOrDefaultAsync(e => e.ID == id);
            return Result.Ok(list);
        }
        catch (Exception error)
        {
            return Result.Fail(error.Message);
        }
    }

    public Result<List<Consulta>> GetByMedico(string medicoId, int limit, int page = 0)
    {
        try
        {
            var list = _ctx.Consultas
                .Where(e => e.Medico.Id == medicoId)
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

    public Result<List<Consulta>> GetByPaciente(string pacienteId, int limit, int page = 0)
    {
        try
        {
            var respose = _ctx.Consultas
                .Where(e => e.Paciente.Id == pacienteId)
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

    public async Task<Result> Update(Consulta entity)
    {
        try
        {
            _ctx.Consultas.Update(entity);
            await _ctx.SaveChangesAsync();

            return Result.Ok();
        }
        catch (Exception error)
        {
            return Result.Fail(error.Message);
        }
    }

    public Result<List<Consulta>> GetByQuery(AtendimentoGetByQueryDto query)
    {
        try
        {
            var queryList = _ctx.Consultas.AsQueryable();
            if (query.MedicoId != null)
                queryList = queryList.Where(e =>
                    e.Medico.Id == query.MedicoId);

            if (query.PacienteId != null)
                queryList = queryList.Where(e =>
                    e.Paciente.Id == query.PacienteId);

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
