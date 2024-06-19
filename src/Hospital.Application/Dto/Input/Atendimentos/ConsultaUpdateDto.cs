using Hospital.Domain.Enums;

namespace Hospital.Application.Dto.Input.Atendimentos;
public record ConsultaUpdateDto : AtendimentoUpdateDto
{
    public ConsultaStatus? Status { get; set; }
}