using Hospital.Dtos.Input.Authentications;
using Hospital.Dtos.Output.Cadastros;
using Hospital.Enums;
using Hospital.Repository;
using Hospital.Repository.Cadastros.Interfaces;

namespace Hospital.Services.Cadastros.Pacientes;
public class PacienteGetByQueryService
{
    private readonly UnitOfWork _unitOfWork;
    private readonly IPacienteRepository _pacienteRepository;
    public PacienteGetByQueryService(
        UnitOfWork unitOfWork,
        IPacienteRepository pacienteRepository)
    {
        _unitOfWork = unitOfWork;
        _pacienteRepository = pacienteRepository;
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

        var pacientes = _pacienteRepository
            .GetPacienteByQueryDto(query);

        return pacientes;
    }
}