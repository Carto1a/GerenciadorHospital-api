using Hospital.Enums;
using Hospital.Models.Atendimento;

namespace Hospital.Dtos.Output.Atendimentos;
public class AtendimentoRetornoOutputDto
: AtendimentoOutputDto
{
    public Guid ConsultaId { get; init; }
    public Guid? NovaConsultaId { get; init; }

    public RetornoStatus Status { get; init; }

    public AtendimentoRetornoOutputDto(Retorno original)
    : base(original)
    {
        ConsultaId = original.ConsultaId;
        NovaConsultaId = original.NovaConsultaId;
        Status = original.Status;
    }
}
