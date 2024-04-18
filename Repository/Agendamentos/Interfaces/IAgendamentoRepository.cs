using FluentResults;
using Hospital.Dto.Agendamento.Get;
using Hospital.Models.Atendimento;
using Hospital.Models.Agendamentos;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Hospital.Repository.Agendamentos.Interfaces;
public interface IAgendamentoRepository<T, TAgendamento>
    where T : Atendimento
    where TAgendamento : Agendamento<T>
{
    Task<Result<EntityEntry<TAgendamento>>> CreateAgentamento(TAgendamento agentamento);
    Task<Result> UpdateAgentamento(TAgendamento NovoAgendamento);
    Task<Result<TAgendamento?>> GetAgendamentoById(Guid id);
    Result<List<TAgendamento>> GetAgendamentosByPaciente(Guid pacienteId, int limit, int page = 0);
    Task<Result<List<TAgendamento>>> GetAgendamentosByMedico(Guid medicoId, int limit, int page = 0);
    Result<List<TAgendamento>> GetAgendamentosByDate(DateTime minDate, DateTime maxDate, int limit, int page = 0);
    Task<Result<List<TAgendamento>>> GetAgendamentoByQuery(AgendamentoGetByQueryDto query);
}
