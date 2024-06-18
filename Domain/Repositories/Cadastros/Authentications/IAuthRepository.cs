namespace Hospital.Domain.Repositories.Cadastros.Authentications;
public interface IAuthRepository<T, TCheck>
{
    Task CreateAsync(T entity, string password);
    Task AddToRoleAsync(T entity, string role);
    Task<T?> FindByEmailAsync(string email);
    Task<bool> CheckPasswordAsync(T entity, string password);
    Task<bool> IsInRoleAsync(T entity, string role);
    Task<IList<string>> GetRolesAsync(T entity);
    Task<bool> CheckIfCadastroExistsAsync(TCheck request);
}