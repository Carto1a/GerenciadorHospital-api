using Hospital.Dto.Auth;

namespace Hospital.Models.Cadastro;
public class Admin
: Cadastro
{
    public void Create(
        RegisterRequestAdminDto request)
    {
        Email = request.Email;
        Nome = request.Nome;
        DataNascimento = DateOnly.FromDateTime(DateTime.Now);
        Genero = request.Genero;
        Telefone = request.Telefone;
        Cpf = request.Cpf;
        Cep = request.Cep;
        NumeroCasa = request.NumeroCasa;
        UserName = request.Email;
        SecurityStamp = Guid.NewGuid().ToString();
    }
}
