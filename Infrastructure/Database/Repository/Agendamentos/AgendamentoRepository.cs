using Hospital.Database;
using Hospital.Dtos.Input.Agendamentos;
using Hospital.Dtos.Output.Agendamentos;
using Hospital.Models.Agendamentos;
using Hospital.Models.Atendimento;
using Hospital.Repository.Agendamentos.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace Hospital.Repository.Agendamentos;
public class AgendamentoRepository<T, TAgendamento>
: IAgendamentoRepository<T, TAgendamento>
    where T : Atendimento, new()
    where TAgendamento : Agendamento
{
    private readonly AppDbContext _ctx;
    private readonly UnitOfWork _uow;
    public AgendamentoRepository(
        AppDbContext context,
        UnitOfWork uow)
    {
        _ctx = context;
        _uow = uow;
    }

    public async Task<Guid> CreateAsync(
        TAgendamento agentamento)
    {
        try
        {
            var result = await _ctx.Set<TAgendamento>().AddAsync(agentamento);
            await _ctx.SaveChangesAsync();
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
            var list = _ctx.Set<TAgendamento>()
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

    public async Task<TAgendamento?> GetByIdAsync(
        Guid id)
    {
        try
        {
            var list = await _ctx.Set<TAgendamento>()
                .FirstOrDefaultAsync(e => e.Id == id);

            return list;
        }
        catch (Exception error)
        {
            _uow.Dispose();
            throw new Exception(error.Message);
        }
    }

    public AgendamentoOutputDto? GetByIdDto(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<AgendamentoOutputDto>> GetByQueryDtoAsync(
        AgendamentoGetByQueryDto query)
    {
        try
        {
            var queryCtx = _ctx.Set<TAgendamento>().AsQueryable();
            if (query.MedicoId != null)
                queryCtx = queryCtx.Where(e =>
                    e.MedicoId == query.MedicoId);

            if (query.PacienteId != null)
                queryCtx = queryCtx.Where(e =>
                    e.PacienteId == query.PacienteId);

            if (query.MinDateCriado != null)
                queryCtx = queryCtx.Where(e =>
                    e.Criado >= query.MinDateCriado);

            if (query.MaxDateCriado != null)
                queryCtx = queryCtx.Where(e =>
                    e.Criado <= query.MaxDateCriado);

            if (query.ConvencioId != null)
                queryCtx = queryCtx.Where(e =>
                    e.ConvenioId == query.ConvencioId);

            if (query.MinDataHora != null)
                queryCtx = queryCtx.Where(e =>
                    e.DataHora >= query.MinDataHora);

            if (query.MaxDataHora != null)
                queryCtx = queryCtx.Where(e =>
                    e.DataHora <= query.MaxDataHora);

            if (query.Status != null)
                queryCtx = queryCtx.Where(e =>
                    e.Status == query.Status);

            var result = await queryCtx
                .Skip((int)query.Page!)
                .Take((int)query.Limit!)
                .Select(e => new AgendamentoOutputDto(e))
                .ToListAsync();

            return result;
        }
        catch (Exception error)
        {
            _uow.Dispose();
            throw new Exception(error.Message);
        }
    }

    public async Task UpdateAsync(
        TAgendamento NovoAgendamento)
    {
        try
        {
            _ctx.Set<TAgendamento>().Update(NovoAgendamento);
            await _ctx.SaveChangesAsync();
        }
        catch (Exception error)
        {
            _uow.Dispose();
            throw new Exception(error.Message);
        }
    }
}