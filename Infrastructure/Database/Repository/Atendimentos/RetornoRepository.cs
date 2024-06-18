
using Hospital.Database;
using Hospital.Models.Atendimento;
using Hospital.Repository.Atendimentos.Interfaces;


namespace Hospital.Repository.Atendimentos;
public class RetornoRepository
: AtendimentoRepository<Retorno>,
IRetornoRepository
{
    private readonly ILogger<RetornoRepository> _logger;
    private readonly AppDbContext _ctx;
    private readonly UnitOfWork _uow;
    public RetornoRepository(
        AppDbContext context,
        ILogger<RetornoRepository> logger,
        UnitOfWork uow)
    : base(context, logger, uow)
    {
        _ctx = context;
        _logger = logger;
        _uow = uow;
        _logger.LogDebug(1, $"NLog injected into RetornoRepository");
    }
}