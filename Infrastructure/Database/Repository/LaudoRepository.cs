using Hospital.Database;
using Hospital.Dtos.Input.Laudos;
using Hospital.Models;

using Microsoft.EntityFrameworkCore;

namespace Hospital.Repository;
public class LaudoRepository : ILaudoRepository
{
    private readonly AppDbContext _ctx;
    private readonly UnitOfWork _uow;
    public LaudoRepository(
        AppDbContext context,
        UnitOfWork uow)
    {
        _ctx = context;
        _uow = uow;
    }

    public UnitOfWork Uow => _uow;

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

    public async Task<Laudo?> GetByIdAsync(Guid id)
    {
        try
        {
            var list = await _ctx.Laudos
                .FirstOrDefaultAsync(e => e.Id == id);

            return list;
        }
        catch (Exception error)
        {
            _uow.Dispose();
            throw new Exception(error.Message);
        }
    }

    public List<Laudo> GetByQueryDtoAsync(LaudoGetByQueryDto query)
    {
        throw new NotImplementedException();
    }

    public async Task Update(Laudo laudo)
    {
        try
        {
            _ctx.Laudos.Update(laudo);
            await _ctx.SaveChangesAsync();
        }
        catch (Exception error)
        {
            _uow.Dispose();
            throw new Exception(error.Message);
        }
    }
}