using FluentResults;
using Hospital.Database;
using Hospital.Dto.Agendamento.Get;
using Hospital.Models.Agendamentos;
using Hospital.Models.Atendimento;
using Hospital.Repository.Agendamentos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Repository.Agendamentos;
public class AgendamentoRepository<T, TAgendamento>
: IAgendamentoRepository<T, TAgendamento>
    where T : Atendimento, new()
    where TAgendamento : Agendamento<T>
{
    private readonly AppDbContext _ctx;
    public AgendamentoRepository(AppDbContext context)
    {
        _ctx = context;
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

    public Result<List<TAgendamento>> GetAgendamentoByQuery(
        AgendamentoGetByQueryDto query)
    {
        try
        {
            // TODO: adiciona pesquisa pela data de criação
            var queryList = _ctx.Set<TAgendamento>().AsQueryable();
            if (query.MedicoId != null)
                queryList = queryList.Where(e =>
                    e.Medico.Id == query.MedicoId);

            if (query.PacienteId != null)
                queryList = queryList.Where(e =>
                    e.Paciente.Id == query.PacienteId);

            if (query.MinDate != null)
                queryList = queryList.Where(
                    e => e.DataHora >= query.MinDate
                    && e.DataHora <= query.MaxDate);

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

    public Result<List<TAgendamento>> GetAgendamentosByDate(
        DateTime minDate, DateTime maxDate, int limit, int page = 0)
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

    public Result<List<TAgendamento>> GetAgendamentosByMedico(
        string medicoId, int limit, int page = 0)
    {
        try
        {
            var list = _ctx.Set<TAgendamento>()
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

    public Result<List<TAgendamento>> GetAgendamentosByPaciente(
        string pacienteId, int limit, int page = 0)
    {
        try
        {
            return _ctx.Set<TAgendamento>()
                .Where(e => e.Paciente.Id == pacienteId)
                .Skip(page)
                .Take(limit)
                .ToList();
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
}
