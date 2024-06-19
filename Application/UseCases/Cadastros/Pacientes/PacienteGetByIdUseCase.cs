using Hospital.Application.Dto.Output.Cadastros;
using Hospital.Domain.Repositories.Cadastros;

namespace Hospital.Application.UseCases.Cadastros.Pacientes;
public class PacienteGetByIdUseCase
{
    private readonly IPacienteRepository _pacienteRepository;
    public PacienteGetByIdUseCase(
        IPacienteRepository pacienteRepository)
    {
        _pacienteRepository = pacienteRepository;
    }

    public Task<PacienteOutputDto?> Handler(
        Guid id)
    {
        var paciente = _pacienteRepository
            .GetByIdDtoAsync(id);
        return paciente;
    }
}