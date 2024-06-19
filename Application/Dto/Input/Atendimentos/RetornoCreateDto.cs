using Hospital.Domain.Enums;

namespace Hospital.Application.Dto.Input.Atendimentos;
public record RetornoCreateDto : AtendimentoCreateDto
{
    public Guid ConsultaId { get; set; }
    public RetornoStatus Status { get; set; }
}