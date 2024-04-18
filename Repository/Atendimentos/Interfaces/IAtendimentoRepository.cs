using FluentResults;

using Hospital.Dto.Atendimento.Get;


namespace Hospital.Repository.Atendimentos.Interfaces;
public interface IAtendimentoRepository<T>
{
    Task<Result<T>> Create(T exame);
    Task<Result<T?>> GetById(Guid id);
    Result<List<T>> GetByDate(DateTime minDate, DateTime maxDate, int limit, int page = 0);
    Result<List<T>> GetByMedico(Guid medicoId, int limit, int page = 0);
    Result<List<T>> GetByPaciente(Guid pacienteId, int limit, int page = 0);
    Task<Result> Update(T entity);
    Result<List<T>> GetByQuery(AtendimentoGetByQueryDto query);
}