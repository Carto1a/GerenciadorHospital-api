using Hospital.Models;
using Hospital.Models.Agendamentos;
using Hospital.Repository.Generics.Interfaces;

namespace Hospital.Repository.Interfaces;
public interface IExamesRepository : IGenericAtendimentoRepository<Exame, ExameAgendamento>
{
}
