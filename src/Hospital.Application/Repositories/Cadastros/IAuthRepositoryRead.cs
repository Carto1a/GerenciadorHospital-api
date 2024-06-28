using Hospital.Domain.Entities.Cadastros;

namespace Hospital.Application.Repositories.Cadastros;
public interface IAuthRepositoryRead<T, TOut, TQuery>
: IRepositoryRead<T, TOut, TQuery>
{
    Task<TOut> GetByCpfDtoAsync(string cpf);
    Task<TOut> GetByEmailDtoAsync(string email);
    Task<bool> CheckIfCadastroExistsAsync(Cadastro cadastro);
    Task<bool> CheckPasswordAsync(T entity, string password);
}