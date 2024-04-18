using Hospital.Database;
using Hospital.Models;
using Hospital.Models.Agendamentos;
using Hospital.Repository.Generics;

namespace Hospital.Repository;
public class RetornoRepository :
    GenericAtendimentoRepository<Retorno, RetornoAgendamento>
{
    public RetornoRepository(AppDbContext context) : base(context)
    {
    }
}
