using Hospital.Application.Dto.Input.Atendimentos;
using Hospital.Application.Dto.Output.Atendimentos;
using Hospital.Domain.Entities.Atendimentos;
using Hospital.Domain.Repositories;
using Hospital.Domain.Repositories.Atendimentos;

using Microsoft.EntityFrameworkCore;

namespace Hospital.Infrastructure.Database.Repositories.Atendimentos;
public class ExameRepository
: AtendimentoRepository<Exame, ExameGetByQueryDto, ExameOutputDto>,
IExameRepository
{
    private readonly AppDbContext _ctx;
    private readonly IUnitOfWork _uow;
    public ExameRepository(
        AppDbContext context,
        IUnitOfWork uow)
    : base(context, uow)
    {
        _ctx = context;
        _uow = uow;
    }

    public override Task<List<ExameOutputDto>> GetByQueryDtoAsync(ExameGetByQueryDto query)
    {
        try
        {
            var queryList = _ctx.Exames.AsQueryable();
            if (query.MedicoId != null)
                queryList = queryList.Where(e =>
                    e.MedicoId == query.MedicoId);

            if (query.PacienteId != null)
                queryList = queryList.Where(e =>
                    e.PacienteId == query.PacienteId);

            if (query.MinDateCriado != null && query.MaxDateCriado != null)
                queryList = queryList.Where(
                    e => e.Inicio >= query.MinDateCriado
                    && e.Inicio <= query.MaxDateCriado);

            var result = queryList
                .Skip((int)query.Page!)
                .Take((int)query.Limit!)
                .Select(e => new ExameOutputDto(e));

            return result.ToListAsync();
        }
        catch (Exception error)
        {
            _uow.Dispose();
            throw new Exception(error.Message);
        }
    }

    public Task<List<Exame>> GetExamesByIdsAsync(IEnumerable<Guid> ids)
    {
        try
        {
            var list = _ctx.Exames
                .Where(e => ids.Contains(e.Id))
                .ToListAsync();

            return list;
        }
        catch (Exception error)
        {
            _uow.Dispose();
            throw new Exception(error.Message);
        }
    }
}