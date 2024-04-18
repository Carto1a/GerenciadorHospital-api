using FluentResults;
using Hospital.Dto.Agendamento.Get;
using Hospital.Models.Atendimento;
using Hospital.Models.Agendamentos;

namespace Hospital.Repository.Agendamentos.Interfaces;
public interface IAgendamentoRepository<T, TAgendamento>
    where T : Atendimento
    where TAgendamento : Agendamento<T>
{
    Task<Result> CreateAgentamento(TAgendamento agentamento);
    Task<Result> UpdateAgentamento(TAgendamento NovoAgendamento);
    Task<Result<TAgendamento?>> GetAgendamentoById(int id);
    Result<List<TAgendamento>> GetAgendamentosByPaciente(int pacienteId, int limit, int page = 0);
    Result<List<TAgendamento>> GetAgendamentosByMedico(int medicoId, int limit, int page = 0);
    Result<List<TAgendamento>> GetAgendamentosByDate(DateTime minDate, DateTime maxDate, int limit, int page = 0);
    Result<List<TAgendamento>> GetAgendamentoByQuery(AgendamentoGetByQueryDto query);
}
