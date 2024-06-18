using Hospital.Domain.Entities.Cadastros;

namespace Hospital.Application.Services;
public interface IJwtTokenService
{
    string GenerateUserToken(Cadastro user, IList<string> userRoles);
}