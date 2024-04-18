using FluentResults;
using Hospital.Dto.Atividades;

namespace Hospital.Repository.Generics.Interfaces;
public interface IGenericAtendimentoRepository<T, TAgendamento>
{
    Task<Result<T>> Create(T exame);
    Task<Result<T?>> GetById(int id);
    /* Task<Result> LinkAtendimento(T atendimento); */
    Result<List<T>> GetByDate(DateTime minDate, DateTime maxDate, int limit, int page = 0);
    Result<List<T>> GetByMedico(int medicoId, int limit, int page = 0);
    Result<List<T>> GetByPaciente(int pacienteId, int limit, int page = 0);
    Task<Result> CreateAgentamento(TAgendamento agentamento);
    Task<Result> Update(T entity);
    Task<Result> UpdateAgentamento(TAgendamento NovoAgendamento);
    Task<Result<TAgendamento?>> GetAgendamentoById(int id);
    Result<List<TAgendamento>> GetAgendamentosByPaciente(int pacienteId, int limit, int page = 0);
    Result<List<TAgendamento>> GetAgendamentosByMedico(int medicoId, int limit, int page = 0);
    Result<List<TAgendamento>> GetAgendamentosByDate(DateTime minDate, DateTime maxDate, int limit, int page = 0);
    Result<List<T>> GetByQuery(AtendimentoGetQueryDto query);
    /* Result<List<TAgendamento>> GetByQuery(AtendimentoGetQueryDto query); */
}
