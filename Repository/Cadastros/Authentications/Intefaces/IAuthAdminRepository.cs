using Hospital.Dtos.Input.Authentications;
using Hospital.Models.Cadastro;

namespace Hospital.Repository.Cadastros.Authentications.Interfaces;
public interface IAuthAdminRepository
: IAuthCadastroRepository<Admin, RegisterRequestAdminDto>
{ }