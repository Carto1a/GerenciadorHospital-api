using System.Diagnostics.CodeAnalysis;

using Hospital.Dtos.Input.Authentications;

namespace Hospital.Models.Cadastro;
public class Admin
: Cadastro
{
    public Admin() { }
    [SetsRequiredMembers]
    public Admin(RegisterRequestAdminDto request)
    : base(request)
    { }
}