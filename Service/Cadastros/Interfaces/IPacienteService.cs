using System.Security.Claims;
using FluentResults;


namespace Hospital.Service.Interfaces;
public interface IPacienteService
{
    Result<string> GetPacienteDocumento(ClaimsPrincipal user, string guid);
}
