using Hospital.Enums;

namespace Hospital.Dtos.Input.Authentications;
public record PacienteGetByQueryDto(
    Guid? ConvenioId,
    bool? Ativo,
    DateTime? MinDateNasc,
    DateTime? MaxDateNasc,
    GeneroEnum? Genero,
    int CEP)
{
    public int? Page { get; set; } = 0;
    public int? Limit { get; set; } = 1;
}