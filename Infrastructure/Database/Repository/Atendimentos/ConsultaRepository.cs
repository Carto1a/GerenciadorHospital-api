
using Hospital.Database;
using Hospital.Models.Atendimento;
using Hospital.Repository.Atendimentos.Interfaces;


namespace Hospital.Repository.Atendimentos;
public class ConsultaRepository
: AtendimentoRepository<Consulta>,
IConsultaRepository
{
    private readonly ILogger<ConsultaRepository> _logger;
    private readonly AppDbContext _ctx;
    private readonly UnitOfWork _uow;
    public ConsultaRepository(
        AppDbContext context,
        ILogger<ConsultaRepository> logger,
        UnitOfWork uow)
    : base(context, logger, uow)
    {
        _ctx = context;
        _logger = logger;
        _uow = uow;
    }
}