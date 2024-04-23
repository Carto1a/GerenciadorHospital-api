using Hospital.Enums;

namespace Hospital.Dtos.Input.Atendimentos;
public record ExameUpdateDto
: AtendimentoUpdateDto
{
    public ExameStatus? Status { get; set; }
}