namespace Hospital.Application.Dto.Input.Authentications;
public record MedicoGetByQueryDto(
    string? Especialidade) : LoginGetByQueryDto
{ }