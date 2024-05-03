using Hospital.Dtos.Input.Authentications;
using Hospital.Dtos.Output.Cadastros;
using Hospital.Enums;
using Hospital.Repository;

namespace Hospital.Services.Cadastros.Admins;
public class AdminGetByQueryService
{
    private readonly UnitOfWork _unitOfWork;
    public AdminGetByQueryService(
        UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public List<AdminOutputDto> Handler(
        AdminGetByQueryDto query)
    {
        var validator = new Validators("Não foi possível buscar administradores");
        validator.Query((int)query.Limit!, (int)query.Page!);

        if (query.Genero != null)
            validator.isInEnum(
                query.Genero,
                typeof(GeneroEnum),
                "Genero inválido");

        // NOTE: break code execution if validation fails
        validator.Check();

        var admins = _unitOfWork.AdminRepository
            .GetAdminByQueryDto(query);
        return admins;
    }
}