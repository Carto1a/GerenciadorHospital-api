namespace Hospital.Dtos.Input.Agendamentos;
public record ExameAgendamentoGetByQueryDto(
    Guid? ConsultaId)
: AgendamentoGetByQueryDto;