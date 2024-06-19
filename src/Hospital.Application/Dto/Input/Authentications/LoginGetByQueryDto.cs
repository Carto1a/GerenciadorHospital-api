using Hospital.Domain.Enums;

namespace Hospital.Application.Dto.Input.Authentications;
public record LoginGetByQueryDto : GetByQueryDto
{
    public GeneroEnum? Genero { get; set; }
    public DateTime? MinDateNasc { get; set; }
    public DateTime? MaxDateNasc { get; set; }
}