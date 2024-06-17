using Hospital.Enums;

namespace Hospital.Application.Dto.Input.Atendimentos;
public record RetornoUpdateDto : AtendimentoUpdateDto
{
    public Guid ConsultaId { get; set; }
    public Guid? NovaConsultaId { get; set; }

    public RetornoStatus Status { get; set; }
}