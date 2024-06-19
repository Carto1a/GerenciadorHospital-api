using Hospital.Domain.Enums;

namespace Hospital.Application.Dto.Input.Atendimentos;
public record ConsultaCreateDto : AtendimentoCreateDto
{
    public ConsultaStatus Status { get; set; }
}