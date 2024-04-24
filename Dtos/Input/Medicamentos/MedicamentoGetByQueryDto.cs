using Hospital.Enums;

namespace Hospital.Dtos.Input.Medicamentos;
public record MedicamentoGetByQueryDto(
    Guid? PacienteId,
    DateTime? MinDate,
    DateTime? MaxDate,
    int? Quantidade,
    int? QuantidadeMin,
    string? PrincipioAtivo,
    MedicamentoStatus? Status)
{
    public int? Page { get; set; } = 0;
    public int? Limit { get; set; } = 1;
}