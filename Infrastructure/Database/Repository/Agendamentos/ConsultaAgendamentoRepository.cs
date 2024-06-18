using Hospital.Database;
using Hospital.Models.Agendamentos;
using Hospital.Models.Atendimento;
using Hospital.Repository.Atendimentos.Interfaces;


namespace Hospital.Repository.Agendamentos;
public class ConsultaAgendamentoRepository
: AgendamentoRepository<
    Consulta,
    ConsultaAgendamento>,
IConsultaAgendamentoRepository
{
    private readonly AppDbContext _ctx;
    private readonly UnitOfWork _uow;
    public ConsultaAgendamentoRepository(
        AppDbContext context,
        UnitOfWork uow)
    : base(context, uow)
    {
        _ctx = context;
        _uow = uow;
    }
}