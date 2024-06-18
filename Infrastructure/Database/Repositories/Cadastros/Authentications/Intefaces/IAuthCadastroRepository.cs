namespace Hospital.Repository.Cadastros.Authentications.Interfaces;
public interface IAuthCadastroRepository<T, RequestDto>
{
    Task CreateAsync(T cadastro, string senha);
    Task AddToRoleAsync(T cadastro);
    Task<T?> FindByEmailAsync(string email);
    Task<bool> CheckPasswordAsync(T cadastro, string senha);
    Task<IList<string>> GetRolesAsync(T cadastro);
    bool CheckIfCadastroExists(RequestDto request);
}