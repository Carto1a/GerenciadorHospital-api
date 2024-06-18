
using Hospital.Database;
using Hospital.Models.Atendimento;
using Hospital.Repository.Atendimentos.Interfaces;

using Microsoft.EntityFrameworkCore;


namespace Hospital.Repository.Atendimentos;
public class ExameRepository
: AtendimentoRepository<Exame>,
IExameRepository
{
    private readonly ILogger<ExameRepository> _logger;
    private readonly AppDbContext _ctx;
    private readonly UnitOfWork _uow;
    public ExameRepository(
        AppDbContext context,
        ILogger<ExameRepository> logger,
        UnitOfWork uow)
    : base(context, logger, uow)
    {
        _ctx = context;
        _logger = logger;
        _uow = uow;
        _logger.LogDebug(1, $"NLog injected into ExameRepository");
    }

    public Task<List<Exame>> GetExamesByIdsAsync(IEnumerable<Guid> ids)
    {
        try
        {
            var list = _ctx.Exames
                .Where(e => ids.Contains(e.Id))
                .ToListAsync();

            return list;
        }
        catch (Exception error)
        {
            _uow.Dispose();
            throw new Exception(error.Message);
        }
    }
}