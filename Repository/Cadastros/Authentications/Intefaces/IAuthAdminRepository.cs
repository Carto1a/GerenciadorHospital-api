using FluentResults;

using Hospital.Models.Cadastro;

namespace Hospital.Repository.Cadastros.Authentications.Interfaces;
public interface IAuthAdminRepository
{
    Task<Result> Create(Admin admin, string senha);
    Task<Result> AddToRole(Admin admin);
    Task<Admin?> FindByEmail(string email);
    Task<bool> CheckPassword(Admin admin, string senha);
    Task<IList<string>> GetRoles(Admin admin);
}