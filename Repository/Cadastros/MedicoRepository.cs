using FluentResults;

using Hospital.Database;
using Hospital.Models.Cadastro;
using Hospital.Repository.Cadastros.Interfaces;

namespace Hospital.Repository.Cadastros;
public class MedicoRepository
: IMedicoRepository
{
    private readonly ILogger<MedicoRepository> _logger;
    private readonly AppDbContext _ctx;
    public MedicoRepository(
        AppDbContext context,
        ILogger<MedicoRepository> logger)
    {
        _ctx = context;
        _logger = logger;
        _logger.LogDebug(1, $"NLog injected into MedicoRepository");
    }
    public Result<Medico?> GetMedicoById(Guid id)
    {
        try
        {
            var medico = _ctx.Medicos
                .FirstOrDefault(e => e.Id == id);
            return Result.Ok(medico);
        }
        catch (Exception error)
        {
            return Result.Fail(error.Message);
        }
    }

    public Result<List<Medico>> GetMedicos(int limit, int page = 0)
    {
        try
        {
            var medico = _ctx
                .Medicos
                .Skip(page)
                .Take(limit)
                .ToList();
            return Result.Ok(medico);
        }
        catch (Exception error)
        {
            return Result.Fail(error.Message);
        }
    }
}