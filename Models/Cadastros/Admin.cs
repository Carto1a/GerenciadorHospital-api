using FluentResults;

using Hospital.Dto.Auth;

namespace Hospital.Models.Cadastro;
public class Admin
: Cadastro
{
    public static Result<Admin> Create(
        RegisterRequestAdminDto request)
    {
        var admin = new Admin
        {
            Email = request.Email,
            Nome = request.Nome,
            DataNascimento = DateOnly.FromDateTime(DateTime.Now),
            Genero = request.Genero,
            Telefone = request.Telefone,
            Cpf = request.Cpf,
            Cep = request.Cep,
            NumeroCasa = request.NumeroCasa,
            UserName = request.Email,
            SecurityStamp = Guid.NewGuid().ToString(),
        };

        return Result.Ok(admin);
    }
}