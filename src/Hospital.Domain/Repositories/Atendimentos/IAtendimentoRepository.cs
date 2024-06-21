using Hospital.Domain.Entities.Atendimentos;

namespace Hospital.Domain.Repositories.Atendimentos;
public interface IAtendimentoRepository<T>
: IRepository<T>
where T : Atendimento
{ }