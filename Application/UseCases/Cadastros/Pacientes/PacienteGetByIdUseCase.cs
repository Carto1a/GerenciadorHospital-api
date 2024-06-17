namespace Hospital.Application.UseCases.Cadastros.Pacientes;
public class PacienteGetByIdUseCase
{
    private readonly UnitOfWork _unitOfWork;
    private readonly IPacienteRepository _pacienteRepository;
    public PacienteGetByIdUseCase(
        UnitOfWork unitOfWork,
        IPacienteRepository pacienteRepository)
    {
        _unitOfWork = unitOfWork;
        _pacienteRepository = pacienteRepository;
    }

    public PacienteOutputDto? Handler(
        Guid id)
    {
        var paciente = _pacienteRepository
            .GetPacienteByIdDto(id);
        return paciente;
    }
}