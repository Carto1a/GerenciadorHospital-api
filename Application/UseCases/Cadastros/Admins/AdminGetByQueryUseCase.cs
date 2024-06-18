using Hospital.Application.Dto.Input.Authentications;
using Hospital.Application.Dto.Output.Cadastros;
using Hospital.Domain.Enums;
using Hospital.Domain.Repositories;
using Hospital.Domain.Repositories.Cadastros;
using Hospital.Domain.Validators;

namespace Hospital.Application.UseCases.Cadastros.Admins;
public class AdminGetByQueryUseCase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAdminRepository _adminRepository;
    public AdminGetByQueryUseCase(
        IUnitOfWork unitOfWork,
        IAdminRepository adminRepository)
    {
        _unitOfWork = unitOfWork;
        _adminRepository = adminRepository;
    }

    public async Task<IEnumerable<AdminOutputDto>> Handler(
        AdminGetByQueryDto query)
    {
        var validator = new DomainValidator("Não foi possível buscar administradores");
        validator.Query((int)query.Limit!, (int)query.Page!);

        if (query.Genero != null)
            validator.isInEnum(
                query.Genero,
                typeof(GeneroEnum),
                "Genero inválido");

        validator.Check();

        var admins = await _adminRepository
            .GetByQueryDtoAsync(query);
        return admins;
    }
}