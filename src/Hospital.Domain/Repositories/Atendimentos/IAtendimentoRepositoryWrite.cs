using Hospital.Domain.Entities.Atendimentos;

namespace Hospital.Domain.Repositories.Atendimentos;
public interface IAtendimentoRepositoryWrite<T>
: IRepositoryWrite<T>
where T : Atendimento
{ }