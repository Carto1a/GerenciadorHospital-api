using Hospital.Enums;

namespace Hospital.Dtos.Input.Atendimentos;
public record ExameCreateDto
: AtendimentoCreateDto
{
    public ExameStatus? Status { get; set; }
}