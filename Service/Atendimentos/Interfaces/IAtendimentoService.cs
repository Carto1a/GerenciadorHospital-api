using FluentResults;
using Hospital.Dto.Atendimento.Get;

namespace Hospital.Service.Atendimentos.Interfaces;
public interface IAtendimentoService<
    T,
    TAgendamento,
    TCreation>
{
    Task<Result> Create(TCreation request);
    Task<Result<T>> GetById(int id);
    Result<List<T>> GetByQuery(AtendimentoGetByQueryDto query);
    Result<List<T>> GetByPaciente(int pacienteId, int limit, int page = 0);
    Result<List<T>> GetByMedico(int medicoId, int limit, int page = 0);
    Result<List<T>> GetByDate(DateTime minDate, DateTime maxDate, int limit, int page);
}
