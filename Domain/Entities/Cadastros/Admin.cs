using System.Diagnostics.CodeAnalysis;
using Hospital.Application.Dto.Input.Authentications;

namespace Hospital.Domain.Entities.Cadastros;
public class Admin : Cadastro
{
    public Admin() { }
    [SetsRequiredMembers]
    public Admin(RegisterRequestAdminDto request) : base(request)
    { }
}