using Hospital.Enums;

namespace Hospital.Dtos.Input.Atendimentos;
public record ConsultaCreateDto
: AtendimentoCreateDto
{
    public ConsultaStatus Status { get; set; }
}