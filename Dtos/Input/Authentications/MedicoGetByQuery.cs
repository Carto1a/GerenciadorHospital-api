using Hospital.Enums;

namespace Hospital.Dtos.Input.Authentications;
public record MedicoGetByQuery(
    string? Especialidade,
    bool? Ativo,
    DateTime? MinDate,
    DateTime? MaxDate,
    GeneroEnum? Genero,
    int CEP)
{
    public int? Page { get; set; } = 0;
    public int? Limit { get; set; } = 1;
}