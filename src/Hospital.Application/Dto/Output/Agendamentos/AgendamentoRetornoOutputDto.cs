using Hospital.Domain.Entities.Agendamentos;

namespace Hospital.Application.Dto.Output.Agendamentos;
public record AgendamentoRetornoOutputDto : AgendamentoOutputDto
{
    public Guid ConsultaId { get; set; }

    public AgendamentoRetornoOutputDto(RetornoAgendamento original)
    : base(original)
    {
        ConsultaId = original.ConsultaId;
    }
}