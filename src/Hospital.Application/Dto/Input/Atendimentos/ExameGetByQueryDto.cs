using Hospital.Domain.Enums;

namespace Hospital.Application.Dto.Input.Atendimentos;
public record ExameGetByQueryDto : AtendimentoGetByQueryDto
{
    public Guid? ConsultaId { get; set; }
    public ExameStatus Status { get; set; }
}