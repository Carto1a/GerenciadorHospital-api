using Hospital.Domain.Enums;

namespace Hospital.Application.Dto.Input.Atendimentos;
public record ConsultaGetByQueryDto : AtendimentoGetByQueryDto
{
    public ConsultaStatus Status { get; set; }
}