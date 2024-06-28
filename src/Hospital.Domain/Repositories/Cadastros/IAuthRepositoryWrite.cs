using Hospital.Domain.Entities.Cadastros;

namespace Hospital.Domain.Repositories.Cadastros;
public interface IAuthRepositoryWrite<T>
where T : ICadastro
{
    void Update(T entity);
    Task CreateAsync(T entity, string password);
    Task AddToRoleAsync(T entity, string role);
}