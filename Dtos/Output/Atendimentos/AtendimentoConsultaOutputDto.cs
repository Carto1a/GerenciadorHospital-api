using Hospital.Enums;
using Hospital.Models.Atendimento;

namespace Hospital.Dtos.Output.Atendimentos;
public class AtendimentoConsultaOutputDto
: AtendimentoOutputDto
{
    public ConsultaStatus Status { get; init; }

    public AtendimentoConsultaOutputDto(Consulta original)
    : base(original)
    {
        Status = original.Status;
    }

    public AtendimentoConsultaOutputDto Create(
        Consulta original)
    {
        return new AtendimentoConsultaOutputDto(original);
    }
}