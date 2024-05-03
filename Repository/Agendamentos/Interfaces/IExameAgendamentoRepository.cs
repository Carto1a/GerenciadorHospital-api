using Hospital.Dtos.Output.Agendamentos;
using Hospital.Models.Agendamentos;
using Hospital.Models.Atendimento;
using Hospital.Repository.Agendamentos.Interfaces;

namespace Hospital.Repository.Atendimentos.Interfaces;

public interface IExameAgendamentoRepository
: IAgendamentoRepository<Exame, ExameAgendamento, AgendamentoOutputDto>
{ }