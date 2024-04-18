using Hospital.Models;
using Hospital.Models.Agendamentos;
using Hospital.Repository.Generics.Interfaces;

namespace Hospital.Repository.Interfaces;
public interface IConsultaRepository : IGenericAtendimentoRepository<Consulta, ConsultaAgendamento>
{
}
