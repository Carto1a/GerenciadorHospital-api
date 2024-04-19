using FluentResults;

using Hospital.Models.Cadastro;

namespace Hospital.Repository.Cadastros.Authentications.Interfaces;
public interface IAuthPacienteRepository
{
    Task<Result> Create(Paciente paciente, string senha);
    Task<Result> AddToRole(Paciente paciente);
    Task<Paciente?> FindByEmail(string email);
    Task<bool> CheckPassword(Paciente admin, string senha);
    Task<IList<string>> GetRoles(Paciente admin);
}