using Hospital.Application.Dto.Input.Laudos;
using Hospital.Application.Dto.Output;
using Hospital.Domain.Entities;
using Hospital.Domain.Repositories;

using Microsoft.EntityFrameworkCore;

namespace Hospital.Infrastructure.Database.Repositories;
public class LaudoRepository : Repository<Laudo, LaudoGetByQueryDto, LaudoOutputDto>,
ILaudoRepository
{
    private readonly AppDbContext _ctx;
    private readonly IUnitOfWork _uow;
    public LaudoRepository(
        AppDbContext context,
        IUnitOfWork uow) : base(context, uow)
    {
        _ctx = context;
        _uow = uow;
    }

    public async Task<Guid> CreateAsync(Laudo laudo)
    {
        try
        {
            var result = await _ctx.Laudos.AddAsync(laudo);
            await _ctx.SaveChangesAsync();
            return result.Entity.Id;
        }
        catch (Exception error)
        {
            _uow.Dispose();
            throw new Exception(error.Message);
        }
    }

    public override Task<List<LaudoOutputDto>> GetByQueryDtoAsync(
        LaudoGetByQueryDto query)
    {
        try
        {
            var queryList = _ctx.Laudos.AsQueryable();
            queryList.Include(e => e.ExamesLaudos);
            if (query.ConsultaId != null)
                queryList = queryList.Where(e =>
                    e.ConsultaId == query.ConsultaId);

            if (query.MedicoId != null)
                queryList = queryList.Where(e =>
                    e.MedicoId == query.MedicoId);

            if (query.PacienteId != null)
                queryList = queryList.Where(e =>
                    e.PacienteId == query.PacienteId);

            if (query.ExameId != null)
            {
                queryList = queryList.Where(e =>
                    e.ExamesLaudos.Any(el => el.ExameId == query.ExameId));
            }

            if (query.MinDateCriado != null && query.MaxDateCriado != null)
                queryList = queryList.Where(
                    e => e.Criado >= query.MinDateCriado
                    && e.Criado <= query.MaxDateCriado);

            var result = queryList
                .Skip((int)query.Page!)
                .Take((int)query.Limit!)
                .Select(e => new LaudoOutputDto(e));

            return result.ToListAsync();
        }
        catch (Exception error)
        {
            _uow.Dispose();
            throw new Exception(error.Message);
        }
    }
}