namespace Hospital.Application.Dto.Input.Authentications;
public record PacienteGetByQueryDto(
    Guid? ConvenioId) : LoginGetByQueryDto
{ }