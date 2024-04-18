using FluentResults;
using Hospital.Database;
using Hospital.Dto.Agendamento.Get;
using Hospital.Models.Agendamentos;
using Hospital.Repository.Atendimentos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Repository.Agendamentos;
public class ExameAgendamentoRepository
: IExameAgendamentoRepository
{
    private readonly ILogger<ExameAgendamentoRepository> _logger;
    private readonly AppDbContext _ctx;
    public ExameAgendamentoRepository(
        AppDbContext context,
        ILogger<ExameAgendamentoRepository> logger)
    {
        _ctx = context;
        _logger = logger;
        _logger.LogDebug(1, $"NLog injected into ExameAgendamentoRepository");
    }

    public async Task<Result> CreateAgentamento(ExameAgendamento agentamento)
    {
        try
        {
            await _ctx.AgendamentosExames.AddAsync(agentamento);
            await _ctx.SaveChangesAsync();
            return Result.Ok();
        }
        catch (Exception error)
        {
            // jeito preguisa das ideias
            return Result.Fail(error.Message);
        }
    }

    public async Task<Result<ExameAgendamento?>> GetAgendamentoById(
        Guid id)
    {
        try
        {
            var list = await _ctx.AgendamentosExames
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
            return Result.Ok(list);
        }
        catch (Exception error)
        {
            return Result.Fail(error.Message);
        }
    }

    public async Task<Result<List<ExameAgendamento>>> GetAgendamentoByQuery(
        AgendamentoGetByQueryDto query)
    {
        try
        {
            // TODO: adiciona pesquisa pela data de criação
            var queryList = _ctx.AgendamentosExames.AsQueryable();
            if (query.MedicoId != null)
                queryList = queryList.Where(e =>
                    e.MedicoId == query.MedicoId);

            if (query.PacienteId != null)
                queryList = queryList.Where(e =>
                    e.PacienteId == query.PacienteId);

            if (query.MinDate != null)
                queryList = queryList.Where(
                    e => e.DataHora >= query.MinDate
                    && e.DataHora <= query.MaxDate);

            if (query.Limit == null || query.Page == null)
                return Result.Fail("page e limit não deveriam ser nulls");

            var result = await queryList
                .Skip((int)query.Page)
                .Take((int)query.Limit)
                .ToListAsync();

            return Result.Ok(result);
        }
        catch (Exception error)
        {
            return Result.Fail(error.Message);
        }
    }

    public Result<List<ExameAgendamento>> GetAgendamentosByDate(
        DateTime minDate, DateTime maxDate, int limit, int page = 0)
    {
        try
        {
            var list = _ctx.AgendamentosExames
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

    public async Task<Result<List<ExameAgendamento>>> GetAgendamentosByMedico(
        Guid medicoId, int limit, int page = 0)
    {
        try
        {
            var list = await _ctx.AgendamentosExames
                .Where(e => e.MedicoId == medicoId)
                .Skip(page)
                .Take(limit)
                .ToListAsync();
            return Result.Ok(list);
        }
        catch (Exception error)
        {
            return Result.Fail(error.Message);
        }
    }

    public Result<List<ExameAgendamento>> GetAgendamentosByPaciente(
        Guid pacienteId, int limit, int page = 0)
    {
        try
        {
            return _ctx.AgendamentosExames
                .Where(e => e.PacienteId == pacienteId)
                .Skip(page)
                .Take(limit)
                .ToList();
        }
        catch (Exception error)
        {
            return Result.Fail(error.Message);
        }
    }

    public async Task<Result> UpdateAgentamento(
        ExameAgendamento NovoAgendamento)
    {
        try
        {
            _ctx.AgendamentosExames.Update(NovoAgendamento);
            await _ctx.SaveChangesAsync();

            return Result.Ok();
        }
        catch (Exception error)
        {
            return Result.Fail(error.Message);
        }
    }
}
