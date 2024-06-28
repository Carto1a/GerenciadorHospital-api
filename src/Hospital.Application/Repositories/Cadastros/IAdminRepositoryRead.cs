using Hospital.Application.Dto.Input.Authentications;
using Hospital.Application.Dto.Output.Cadastros;
using Hospital.Domain.Entities.Cadastros;

namespace Hospital.Application.Repositories.Cadastros;
public interface IAdminRepositoryRead
: IAuthRepositoryRead<Admin, AdminOutputDto, AdminGetByQueryDto>
{ }