using Hospital.Models;
using Hospital.Models.Agendamentos;
using Hospital.Repository.Generics.Interfaces;

namespace Hospital.Repository.Interfaces;
public interface IRetornoRepository : IGenericAtendimentoRepository<Retorno, RetornoAgendamento>
{
}
