using FluentResults;
using Hospital.Database;
using Hospital.Dto.Agendamento.Get;
using Hospital.Models.Agendamentos;
using Hospital.Models.Atendimento;
using Hospital.Repository.Agendamentos.Interfaces;
using Hospital.Repository.Atendimentos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Repository.Agendamentos;
public class RetornoAgendamentoRepository
: IRetornoAgendamentoRepository
{
    private readonly AppDbContext _ctx;
    public RetornoAgendamentoRepository(AppDbContext context)
    {
        _ctx = context;
    }

    public async Task<Result> CreateAgentamento(RetornoAgendamento agentamento)
    {
        try
        {
            await _ctx.AgendamentosRetornos.AddAsync(agentamento);
            await _ctx.SaveChangesAsync();
            return Result.Ok();
        }
        catch (Exception error)
        {
            // jeito preguisa das ideias
            return Result.Fail(error.Message);
        }
    }

    public async Task<Result<RetornoAgendamento?>> GetAgendamentoById(int id)
    {
        try
        {
            var list = await _ctx.AgendamentosRetornos
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.ID == id);
            return Result.Ok(list);
        }
        catch (Exception error)
        {
            return Result.Fail(error.Message);
        }
    }

    public async Task<Result<List<RetornoAgendamento>>> GetAgendamentoByQuery(
        AgendamentoGetByQueryDto query)
    {
        try
        {
            // TODO: adiciona pesquisa pela data de criação
            var queryList = _ctx.AgendamentosRetornos.AsQueryable();
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

    public Result<List<RetornoAgendamento>> GetAgendamentosByDate(
        DateTime minDate, DateTime maxDate, int limit, int page = 0)
    {
        try
        {
            var list = _ctx.AgendamentosRetornos
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

    public async Task<Result<List<RetornoAgendamento>>> GetAgendamentosByMedico(
        string medicoId, int limit, int page = 0)
    {
        try
        {
            var list = await _ctx.AgendamentosRetornos
                .Where(e => e.Medico.Id == medicoId)
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

    public Result<List<RetornoAgendamento>> GetAgendamentosByPaciente(
        string pacienteId, int limit, int page = 0)
    {
        try
        {
            return _ctx.AgendamentosRetornos
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

    public async Task<Result> UpdateAgentamento(RetornoAgendamento NovoAgendamento)
    {
        try
        {
            _ctx.AgendamentosRetornos.Update(NovoAgendamento);
            await _ctx.SaveChangesAsync();

            return Result.Ok();
        }
        catch (Exception error)
        {
            return Result.Fail(error.Message);
        }
    }
}
