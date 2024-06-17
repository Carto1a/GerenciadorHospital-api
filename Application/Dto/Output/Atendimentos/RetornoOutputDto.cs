using Hospital.Domain.Enums;

namespace Hospital.Application.Dto.Output.Atendimentos;
public record RetornoOutputDto : AtendimentoOutputDto
{
    public Guid ConsultaId { get; init; }
    public RetornoStatus Status { get; init; }
}