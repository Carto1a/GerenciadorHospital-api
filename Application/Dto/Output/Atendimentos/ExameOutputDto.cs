using Hospital.Domain.Enums;

namespace Hospital.Application.Dto.Output.Atendimentos;
public record ExameOutputDto : AtendimentoOutputDto
{
    public Guid ConsultaId { get; set; }
    public string Resultado { get; set; }
    public ExameStatus Status { get; set; }
}