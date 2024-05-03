using Hospital.Dtos.Input.Authentications;
using Hospital.Dtos.Output.Cadastros;
using Hospital.Enums;
using Hospital.Repository;

namespace Hospital.Services.Cadastros.Pacientes;
public class PacienteGetByQueryService
{
    private readonly UnitOfWork _unitOfWork;
    public PacienteGetByQueryService(
        UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public List<PacienteOutputDto> Handler(
        PacienteGetByQueryDto query)
    {
        var validator = new Validators("Não foi possível buscar pacientes");
        validator.Query((int)query.Limit!, (int)query.Page!);

        if (query.Genero != null)
            validator.isInEnum(
                query.Genero,
                typeof(GeneroEnum),
                "Genero inválido");

        // NOTE: break code execution if validation fails
        validator.Check();

        var pacientes = _unitOfWork.PacienteRepository
            .GetPacienteByQueryDto(query);

        return pacientes;
    }
}