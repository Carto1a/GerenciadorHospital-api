using Hospital.Domain.Enums;

namespace Hospital.Application.Dto.Output.Atendimentos;
public record ConsultaOutputDto : AtendimentoOutputDto
{
    public ConsultaStatus Status { get; init; }
}