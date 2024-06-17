using Hospital.Dtos.Output.Cadastros;
using Hospital.Repository;
using Hospital.Repository.Cadastros.Interfaces;

namespace Hospital.Services.Cadastros.Pacientes;
public class PacienteGetByIdService
{
    private readonly UnitOfWork _unitOfWork;
    private readonly IPacienteRepository _pacienteRepository;
    public PacienteGetByIdService(
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