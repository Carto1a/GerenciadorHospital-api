using Hospital.Domain.Enums;

namespace Hospital.Application.Dto.Input.Atendimentos;
public record ExameUpdateDto : AtendimentoUpdateDto
{
    public ExameStatus? Status { get; set; }
}