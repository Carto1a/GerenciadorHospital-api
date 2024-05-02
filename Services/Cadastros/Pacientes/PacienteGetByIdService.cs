using Hospital.Dtos.Output.Cadastros;
using Hospital.Repository;

namespace Hospital.Services.Cadastros.Pacientes;
public class PacienteGetByIdService
{
    private readonly UnitOfWork _unitOfWork;
    public PacienteGetByIdService(
        UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public PacienteOutputDto? Handler(
        Guid id)
    {
        var paciente = _unitOfWork.PacienteRepository
            .GetPacienteByIdDto(id);
        return paciente;
    }
}