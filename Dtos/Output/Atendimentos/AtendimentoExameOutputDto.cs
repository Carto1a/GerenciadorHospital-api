using Hospital.Enums;
using Hospital.Models.Atendimento;

namespace Hospital.Dtos.Output.Atendimentos;
public class AtendimentoExameOutputDto
: AtendimentoOutputDto
{
    /* public Guid LaudoId { get; init; } */
    public Guid ConsultaId { get; init; }
    public string Resultado { get; init; }
    public ExameStatus Status { get; init; }

    public AtendimentoExameOutputDto(
        Exame original)
    : base(original)
    {
        /* LaudoId = original.LaudoId; */
        ConsultaId = original.ConsultaId;
        Resultado = original.Resultado;
        Status = original.Status;
    }

    public AtendimentoExameOutputDto Create(
        Exame original)
    {
        return new AtendimentoExameOutputDto(original);
    }
}