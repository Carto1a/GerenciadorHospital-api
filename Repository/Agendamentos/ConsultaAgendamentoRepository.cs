using FluentResults;
using Hospital.Database;
using Hospital.Dto.Agendamento.Get;
using Hospital.Models.Agendamentos;
using Hospital.Repository.Atendimentos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Repository.Agendamentos;
public class ConsultaAgendamentoRepository
: IConsultaAgendamentoRepository
{
    private readonly AppDbContext _ctx;
    public ConsultaAgendamentoRepository(AppDbContext context)
    {
        _ctx = context;
    }

    public async Task<Result> CreateAgentamento(
        ConsultaAgendamento agentamento)
    {
        try
        {
            await _ctx.AgendamentosConsultas
                .AddAsync(agentamento);
            await _ctx.SaveChangesAsync();
            return Result.Ok();
        }
        catch (Exception error)
        {
            // jeito preguisa das ideias
            return Result.Fail(error.Message);
        }
    }

    public async Task<Result<ConsultaAgendamento?>> GetAgendamentoById(int id)
    {
        try
        {
            var list = await _ctx.AgendamentosConsultas
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.ID == id);
            return Result.Ok(list);
        }
        catch (Exception error)
        {
            return Result.Fail(error.Message);
        }
    }

    public Result<List<ConsultaAgendamento>> GetAgendamentoByQuery(
        AgendamentoGetByQueryDto query)
    {
        try
        {
            // TODO: adiciona pesquisa pela data de criação
            var queryList = _ctx.AgendamentosConsultas.AsQueryable();
            if (query.MedicoId != null)
                queryList = queryList.Where(e =>
                    e.Medico.ID == query.MedicoId);

            if (query.PacienteId != null)
                queryList = queryList.Where(e =>
                    e.Paciente.ID == query.PacienteId);

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

    public Result<List<ConsultaAgendamento>> GetAgendamentosByDate(
        DateTime minDate, DateTime maxDate, int limit, int page = 0)
    {
        try
        {
            var list = _ctx.AgendamentosConsultas
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

    public Result<List<ConsultaAgendamento>> GetAgendamentosByMedico(
        int medicoId, int limit, int page = 0)
    {
        try
        {
            var list = _ctx.AgendamentosConsultas
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

    public Result<List<ConsultaAgendamento>> GetAgendamentosByPaciente(
        int pacienteId, int limit, int page = 0)
    {
        try
        {
            return _ctx.AgendamentosConsultas
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

    public async Task<Result> UpdateAgentamento(
        ConsultaAgendamento NovoAgendamento)
    {
        try
        {
            _ctx.AgendamentosConsultas.Update(NovoAgendamento);
            await _ctx.SaveChangesAsync();

            return Result.Ok();
        }
        catch (Exception error)
        {
            return Result.Fail(error.Message);
        }
    }
}
