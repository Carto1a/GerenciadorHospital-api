namespace Hospital.Application.UseCases.Cadastros.Pacientes;
public class PacienteGetByQueryUseCase
{
    private readonly UnitOfWork _unitOfWork;
    private readonly IPacienteRepository _pacienteRepository;
    public PacienteGetByQueryUseCase(
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