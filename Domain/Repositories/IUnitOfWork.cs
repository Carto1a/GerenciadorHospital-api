namespace Hospital.Domain.Repositories;
public interface IUnitOfWork : IDisposable
{
    Task SaveAsync();
}