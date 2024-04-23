using Hospital.Enums;

namespace Hospital.Dtos.Input.Atendimentos;
public record ConsultaCreateDto
: AtendimentoCreateDto
{
    public AtendimentoStatus Status { get; set; }
}