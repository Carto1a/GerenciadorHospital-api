using Hospital.Application.Dto.Input.Agendamentos;
using Hospital.Application.Dto.Output.Agendamentos;
using Hospital.Domain.Entities.Agendamentos;

namespace Hospital.Domain.Repositories.Agendamentos;
public interface IExameAgendamentoRepository
: IAgendamentoRepository<ExameAgendamento, AgendamentoExameGetByQuery, AgendamentoExameOutputDto>
{ }