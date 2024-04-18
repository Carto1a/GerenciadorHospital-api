using FluentResults;
using Hospital.Database;
using Hospital.Models.Cadastro;
using Hospital.Repository.Cadastros.Interfaces;

namespace Hospital.Repository.Cadastros;
public class PacienteRepository
: IPacienteRepository
{
    private readonly ILogger<PacienteRepository> _logger;
    private readonly AppDbContext _ctx;
    public PacienteRepository(
        AppDbContext context,
        ILogger<PacienteRepository> logger)
    {
        _ctx = context;
        _logger = logger;
        _logger.LogDebug(1, $"NLog injected into PacienteRepository");
    }
    public Result<Paciente?> GetPacienteById(Guid id)
    {
        try
        {
            var paciente = _ctx.Pacientes
                .FirstOrDefault(e => e.Id == id);
            return Result.Ok(paciente);
        }
        catch (Exception error)
        {
            return Result.Fail(error.Message);
        }
    }
    public Result<List<Paciente>> GetPacientes(
        int limit, int page = 0)
    {
        try
        {
            var list = _ctx.Pacientes
                .Skip(page)
                .Take(limit)
                .ToList();
            return Result.Ok(list);
        }
        catch (Exception error)
        {
            return Result.Fail(error.Message);
        }
    }
}
