using FluentResults;

using Hospital.Models.Cadastro;

namespace Hospital.Repository.Cadastros.Authentications.Interfaces;
public interface IAuthMedicoRepository
{
    Task<Result> Create(Medico medico, string senha);
    Task<Result> AddToRole(Medico medico);
    Task<Medico?> FindByEmail(string email);
    Task<bool> CheckPassword(Medico admin, string senha);
    Task<IList<string>> GetRoles(Medico admin);
}