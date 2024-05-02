using Hospital.Enums;

namespace Hospital.Dtos.Input.Authentications;
public record MedicoGetByQueryDto(
    string? Especialidade,
    bool? Ativo,
    DateTime? MinDate,
    DateTime? MaxDate,
    GeneroEnum? Genero)
{
    public int? Page { get; set; } = 0;
    public int? Limit { get; set; } = 1;
}