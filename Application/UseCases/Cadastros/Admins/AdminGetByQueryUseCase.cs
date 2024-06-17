namespace Hospital.Application.UseCases.Cadastros.Admins;
public class AdminGetByQueryUseCase
{
    private readonly UnitOfWork _unitOfWork;
    private readonly IAdminRepository _adminRepository;
    public AdminGetByQueryUseCase(
        UnitOfWork unitOfWork,
        IAdminRepository adminRepository)
    {
        _unitOfWork = unitOfWork;
        _adminRepository = adminRepository;
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

        var admins = _adminRepository
            .GetAdminByQueryDto(query);
        return admins;
    }
}