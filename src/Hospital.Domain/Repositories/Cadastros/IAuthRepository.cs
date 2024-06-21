using Hospital.Domain.Entities.Cadastros;

namespace Hospital.Domain.Repositories.Cadastros;
public interface IAuthRepository<T>
where T : Cadastro
{
    Task<T?> GetByIdAsync(Guid id);
    Task<T?> GetByIdAtivoAsync(Guid id);
    Task<List<T>> GetAllAsync(int limit = 10, int page = 0);
    Task UpdateAsync(T entity);
    Task CreateAsync(T entity, string password);
    Task AddToRoleAsync(T entity, string role);
    Task<T?> FindByEmailAsync(string email);
    Task<bool> CheckPasswordAsync(T entity, string password);
    Task<bool> IsInRoleAsync(T entity, string role);
    Task<IList<string>> GetRolesAsync(T entity);
    Task<bool> CheckIfCadastroExistsAsync(Cadastro cadastro);
}