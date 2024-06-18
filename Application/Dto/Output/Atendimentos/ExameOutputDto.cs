using Hospital.Domain.Entities.Atendimentos;
using Hospital.Domain.Enums;

namespace Hospital.Application.Dto.Output.Atendimentos;
public record ExameOutputDto : AtendimentoOutputDto
{
    public Guid ConsultaId { get; set; }
    public string Resultado { get; set; }
    public ExameStatus Status { get; set; }

    public ExameOutputDto(Exame original) : base(original)
    {
        ConsultaId = original.ConsultaId;
        Resultado = original.Resultado ?? string.Empty;
        Status = original.Status;
    }
}