using FluentResults;
using Hospital.Dto.Agendamento;
using Hospital.Dto.Atividades;

namespace Hospital.Service.Generics.Interfaces;
public interface IGenericAtendimentoService<T, TAgendamento, TCreation>
{
    Task<Result> CreateAgendamento(AgendamentoCreateDto agendamento);
    Task<Result> Create(TCreation exame);
    Task<Result> LinkAtendimento(T entity, int id);
    Task<Result> CancelAgendamento(int id);
    Task<Result> UpdateDateAgendamento(int id, DateTime date);
    Task<Result> UpdateAgendamento(TAgendamento agendamento, int id);
    Task<Result<T>> GetById(int id);
    Result<List<T>> GetByQuery(AtendimentoGetQueryDto query);
    Result<List<T>> GetByPaciente(int pacienteId, int limit, int page = 0);
    Result<List<T>> GetByMedico(int medicoId, int limit, int page = 0);
    Result<List<T>> GetByDate(DateTime minDate, DateTime maxDate, int limit, int page);
    Task<Result<TAgendamento>> GetAgendamentoById(int id);
    Result<List<TAgendamento>> GetAgendamentosByPaciente(int pacienteId, int limit, int page = 0);
    Result<List<TAgendamento>> GetAgendamentosByMedico(int medicoId, int limit, int page = 0);
    Result<List<TAgendamento>> GetAgendamentosByDate(DateTime minDate, DateTime maxDate, int limit, int page = 0);
}
