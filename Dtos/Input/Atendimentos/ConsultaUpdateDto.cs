using Hospital.Enums;

namespace Hospital.Dtos.Input.Atendimentos;
public record ConsultaUpdateDto
: AtendimentoUpdateDto
{
    public AtendimentoStatus? Status { get; set; }
}