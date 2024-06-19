using Hospital.Domain.Repositories;

namespace Hospital.Infrastructure.Database.Repositories;
public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _ctx;
    private bool disposed = false;
    public UnitOfWork(
        AppDbContext context)
    {
        _ctx = context;
    }

    public async Task SaveAsync()
    {
        _ = await _ctx.SaveChangesAsync();
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                _ctx.Dispose();
            }
        }
        disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}