using Hospital.Application.Dto.Input.Laudos;
using Hospital.Application.Dto.Output;
using Hospital.Domain.Entities;
using Hospital.Domain.Repositories;

namespace Hospital.Infrastructure.Database.Repositories;
public class LaudoRepository : Repository<Laudo, LaudoGetByQueryDto, LaudoOutputDto>,
ILaudoRepository
{
    private readonly AppDbContext _ctx;
    private readonly IUnitOfWork _uow;
    public LaudoRepository(
        AppDbContext context,
        UnitOfWork uow) : base(context, uow)
    {
        _ctx = context;
        _uow = uow;
    }

    public async Task<Guid> Create(Laudo laudo)
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

    public override Task<IEnumerable<LaudoOutputDto>> GetByQueryDtoAsync(
        LaudoGetByQueryDto query)
    {
        throw new NotImplementedException();
    }
}