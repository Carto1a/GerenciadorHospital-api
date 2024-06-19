using Hospital.Domain.Enums;

namespace Hospital.Application.Dto.Input.Atendimentos;
public record ExameCreateDto : AtendimentoCreateDto
{
    public ExameStatus Status { get; set; }
    public Guid ConsultaId { get; set; }
    public string? Resultado { get; set; }
}