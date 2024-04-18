using Hospital.Database;
using Hospital.Dto.Atividades;
using Hospital.Models;
using Hospital.Models.Agendamentos;
using Hospital.Repository.Generics;

namespace Hospital.Repository;
public class ConsultaRepository :
    GenericAtendimentoRepository<Consulta, ConsultaAgendamento>
{
    public ConsultaRepository(AppDbContext context) : base(context)
    {
    }
}
