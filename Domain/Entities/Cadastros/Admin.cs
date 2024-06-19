using System.Diagnostics.CodeAnalysis;

using Hospital.Application.Dto.Input.Authentications;

namespace Hospital.Domain.Entities.Cadastros;
public class Admin : Cadastro
{
    public Admin() { }
    [SetsRequiredMembers]
    public Admin(RegisterRequestAdminDto request) : base(request)
    { }

    public override bool Equals<TRegister>(TRegister request)
    {
        if (request is RegisterRequestAdminDto requestAdmin)
        {
            return Email == requestAdmin.Email
                || CPF == requestAdmin.CPF;
        }

        throw new ArgumentException(
            "O tipo de registro não é um administrador.");
    }
}