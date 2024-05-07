using Hospital.Database;
using Hospital.Dtos.Input.Agendamentos;
using Hospital.Dtos.Output.Agendamentos;
using Hospital.Models.Agendamentos;
using Hospital.Models.Atendimento;
using Hospital.Repository.Atendimentos.Interfaces;

using Microsoft.EntityFrameworkCore;


namespace Hospital.Repository.Agendamentos;
public class ExameAgendamentoRepository
: AgendamentoRepository<
    Exame,
    ExameAgendamento>,
IExameAgendamentoRepository
{
    private readonly AppDbContext _ctx;
    private readonly UnitOfWork _uow;
    public ExameAgendamentoRepository(
        AppDbContext context,
        UnitOfWork uow)
    : base(context, uow)
    {
        _ctx = context;
        _uow = uow;
    }

    public new async Task<List<AgendamentoOutputDto>> GetByQueryDtoAsync(
        ExameAgendamentoGetByQueryDto query)
    {
        try
        {
            var queryCtx = _ctx.AgendamentosExames.AsQueryable();
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

            if (query.ConsultaId != null)
                queryCtx = queryCtx.Where(e =>
                    e.ConsultaId == query.ConsultaId);

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
}