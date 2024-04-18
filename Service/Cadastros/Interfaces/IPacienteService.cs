using System.Security.Claims;

using FluentResults;

using Hospital.Models.Cadastro;


namespace Hospital.Service.Interfaces;
public interface IPacienteService
{
    Result<string> GetPacienteDocumento(ClaimsPrincipal user, Guid guid);
    Result<List<Paciente>> GetPacientes(int limit, int page = 0);
    Result<Paciente?> GetPacienteById(Guid pacienteId);
}