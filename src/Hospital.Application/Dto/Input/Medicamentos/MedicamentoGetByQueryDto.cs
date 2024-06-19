using Hospital.Domain.Enums;

namespace Hospital.Application.Dto.Input.Medicamentos;
public record MedicamentoGetByQueryDto(
    /* Guid? PacienteId, */
    int? Quantidade,
    int? QuantidadeMin,
    string? PrincipioAtivo,
    MedicamentoStatus? Status) : GetByQueryDto
{ }