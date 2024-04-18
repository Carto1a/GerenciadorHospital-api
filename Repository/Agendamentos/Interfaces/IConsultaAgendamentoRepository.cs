using Hospital.Models.Agendamentos;
using Hospital.Models.Atendimento;
using Hospital.Repository.Agendamentos.Interfaces;

namespace Hospital.Repository.Atendimentos.Interfaces;

public interface IConsultaAgendamentoRepository
: IAgendamentoRepository<Consulta, ConsultaAgendamento>
{
}
