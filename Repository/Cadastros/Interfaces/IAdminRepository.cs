using Hospital.Dtos.Input.Authentications;
using Hospital.Dtos.Output.Cadastros;

namespace Hospital.Repository.Cadastros.Interfaces;
public interface IAdminRepository
{
    List<AdminOutputDto> GetAdminByQueryDto(AdminGetByQueryDto query);
}