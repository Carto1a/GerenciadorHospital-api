using FluentResults;
using Hospital.Dto.Agendamento.Create;
using Hospital.Dto.Agendamento.Get;
using Hospital.Dto.Agendamento.Update;

namespace Hospital.Service.Agendamentos.Interfaces;
public interface IAgendamentoService<T, TAgendamento, TCreation>
{
    Task<Result> CreateAgendamento(AgendamentoCreateDto request);
    Task<Result> LinkAtendimento(T entity, int id);
    Task<Result> CancelAgendamento(int id);
    Task<Result> EmAndamentoAgendamento(int id);
    Task<Result> EmEsperaAgendamento(int id);
    Task<Result> UpdateAgendamento(AgendamentoUpdateDto novo, int id);
    Task<Result<TAgendamento?>> GetAgendamentoById(int id);
    Result<List<TAgendamento>> GetAgendamentosByPaciente(string pacienteId, int limit, int page = 0);
    Task<Result<List<TAgendamento>>> GetAgendamentosByMedico(string medicoId, int limit, int page = 0);
    Result<List<TAgendamento>> GetAgendamentosByDate(DateTime minDate, DateTime maxDate, int limit, int page = 0);
    Task<Result<List<TAgendamento>>> GetAgendamentosByQuery(AgendamentoGetByQueryDto query);
}
