using FluentResults;
using Hospital.Dto.Atendimento.Get;

namespace Hospital.Service.Atendimentos.Interfaces;
public interface IAtendimentoService<
    T,
    TAgendamento,
    TCreation,
    TUpdate>
{
    Task<Result> Create(TCreation request);
    Task<Result<T?>> GetById(Guid id);
    Result<List<T>> GetByQuery(AtendimentoGetByQueryDto query);
    Result<List<T>> GetByPaciente(Guid pacienteId, int limit, int page = 0);
    Result<List<T>> GetByMedico(Guid medicoId, int limit, int page = 0);
    Result<List<T>> GetByDate(DateTime minDate, DateTime maxDate, int limit, int page);
    Task<Result> Update(TUpdate request, Guid id);
}
