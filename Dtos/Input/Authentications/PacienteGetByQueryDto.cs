namespace Hospital.Dtos.Input.Authentications;
public record Paciente(
    Guid? ConvenioId,
    bool? Ativo,
    DateTime? MinDateNasc,
    DateTime? MaxDateNasc,
    bool? Genero,
    int CEP)
{
    public int? Page { get; set; } = 0;
    public int? Limit { get; set; } = 1;
}