using Hospital.Application.Dto.Input.Authentications;
using Hospital.Application.Dto.Output.Cadastros;
using Hospital.Domain.Entities.Cadastros;

namespace Hospital.Domain.Repositories.Cadastros;
public interface IPacienteRepository
: IRepository<Paciente, PacienteGetByQueryDto, PacienteOutputDto>
{ }