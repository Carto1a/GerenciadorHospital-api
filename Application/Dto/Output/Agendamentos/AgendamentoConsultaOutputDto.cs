using Hospital.Domain.Entities.Agendamentos;

namespace Hospital.Application.Dto.Output.Agendamentos;
public record AgendamentoConsultaOutputDto : AgendamentoOutputDto
{
    public AgendamentoConsultaOutputDto(ConsultaAgendamento original)
    : base(original)
    { }
}