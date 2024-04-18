using FluentResults;
using Hospital.Dto.Agendamento.Create;
using Hospital.Dto.Agendamento.Get;
using Hospital.Dto.Agendamento.Update;

namespace Hospital.Service.Agendamentos.Interfaces;
public interface IAgendamentoService<T, TAgendamento, TCreation>
{
    Task<Result> CreateAgendamento(AgendamentoCreateDto request);
    Task<Result> LinkAtendimento(T entity, Guid id);
    Task<Result> CancelAgendamento(Guid id);
    Task<Result> EmAndamentoAgendamento(Guid id);
    Task<Result> EmEsperaAgendamento(Guid id);
    Task<Result> UpdateAgendamento(AgendamentoUpdateDto novo, Guid id);
    Task<Result<TAgendamento?>> GetAgendamentoById(Guid id);
    Result<List<TAgendamento>> GetAgendamentosByPaciente(Guid pacienteId, int limit, int page = 0);
    Task<Result<List<TAgendamento>>> GetAgendamentosByMedico(Guid medicoId, int limit, int page = 0);
    Result<List<TAgendamento>> GetAgendamentosByDate(DateTime minDate, DateTime maxDate, int limit, int page = 0);
    Task<Result<List<TAgendamento>>> GetAgendamentosByQuery(AgendamentoGetByQueryDto query);
}
