using FluentResults;
using Hospital.Database;
using Hospital.Dto.Atividades;
using Hospital.Models;
using Hospital.Models.Agendamentos;
using Hospital.Repository.Generics.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Repository.Generics;
public class GenericAtendimentoRepository<T, TAgendamento> : IGenericAtendimentoRepository<T, TAgendamento>
    where T : Atendimento, new()
    where TAgendamento : Agendamento<T>
{
    private readonly AppDbContext _ctx;
    public GenericAtendimentoRepository(AppDbContext context)
    {
        _ctx = context;
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

    public async Task<Result> CreateAgentamento(TAgendamento agentamento)
    {
        try
        {
            await _ctx.Set<TAgendamento>().AddAsync(agentamento);
            await _ctx.SaveChangesAsync();
            return Result.Ok();
        }
        catch (Exception error)
        {
            // jeito preguisa das ideias
            return Result.Fail(error.Message);
        }
    }

    /* public async Task<Result> LinkAtendimento(TAgendamento atendimento) */
    /* { */
    /*     try */
    /*     { */
    /*         _ctx.Set<TAgendamento>().Update(atendimento); */
    /*         await _ctx.SaveChangesAsync(); */
    /*         return Result.Ok(); */
    /*     } */
    /*     catch(Exception error) */
    /*     { */
    /*         return Result.Fail(error.Message); */
    /*     } */
    /* } */

    public Result<List<TAgendamento>> GetAgendamentosByDate(DateTime minDate, DateTime maxDate, int limit, int page = 0)
    {
        try
        {
            var list = _ctx.Set<TAgendamento>()
                .Where(e => e.DataHora >= minDate && e.DataHora <= maxDate)
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

    public async Task<Result<TAgendamento?>> GetAgendamentoById(int id)
    {
        try
        {
            var list = await _ctx.Set<TAgendamento>()
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.ID == id);
            return Result.Ok(list);
        }
        catch (Exception error)
        {
            return Result.Fail(error.Message);
        }
    }

    public Result<List<TAgendamento>> GetAgendamentosByMedico(int medicoId, int limit, int page = 0)
    {
        try
        {
            var list = _ctx.Set<TAgendamento>()
                .Where(e => e.Medico.ID == medicoId)
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

    public Result<List<TAgendamento>> GetAgendamentosByPaciente(int pacienteId, int limit, int page = 0)
    {
        try
        {
            return _ctx.Set<TAgendamento>()
                .Where(e => e.Paciente.ID == pacienteId)
                .Skip(page)
                .Take(limit)
                .ToList();
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

    public async Task<Result<T?>> GetById(int id)
    {
        try
        {
            var list = await _ctx.Set<T>()
                .FirstOrDefaultAsync(e => e.ID == id);
            return Result.Ok(list);
        }
        catch (Exception error)
        {
            return Result.Fail(error.Message);
        }
    }

    public Result<List<T>> GetByMedico(int medicoId, int limit, int page = 0)
    {
        try
        {
            var list = _ctx.Set<T>()
                .Where(e => e.Medico.ID == medicoId)
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

    public Result<List<T>> GetByPaciente(int pacienteId, int limit, int page = 0)
    {
        try
        {
            var respose = _ctx.Set<T>()
                .Where(e => e.Paciente.ID == pacienteId)
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

    public async Task<Result> UpdateAgentamento(TAgendamento NovoAgendamento)
    {
        try
        {
            _ctx.Set<TAgendamento>().Update(NovoAgendamento);
            await _ctx.SaveChangesAsync();

            return Result.Ok();
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

    public Result<List<T>> GetByQuery(AtendimentoGetQueryDto query)
    {
        try
        {
            var queryList = _ctx.Set<T>().AsQueryable();
            if (query.MedicoId != null)
                queryList = queryList.Where(e =>
                    e.Medico.ID == query.MedicoId);

            if (query.PacienteId != null)
                queryList = queryList.Where(e =>
                    e.Paciente.ID == query.PacienteId);

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
