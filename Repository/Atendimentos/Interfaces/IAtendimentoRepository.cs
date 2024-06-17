using Hospital.Dtos.Input.Atendimentos;

namespace Hospital.Repository.Atendimentos.Interfaces;
public interface IAtendimentoRepository<T>
{
    Task<Guid> Create(T exame);
    Task<T?> GetByIdAsync(Guid id);
    Task Update(T entity);
    List<T> GetByQueryDtoAsync(AtendimentoGetByQueryDto query);
}