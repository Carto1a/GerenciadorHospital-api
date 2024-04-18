using FluentResults;
using Hospital.Database;
using Hospital.Models;
using Hospital.Repository.Interfaces;

namespace Hospital.Repository;
public class MedicoRepository : IMedicoRepository
{
    private readonly AppDbContext _ctx;
    public MedicoRepository(AppDbContext context)
    {
        _ctx = context;
    }
    public Result<Medico?> GetMedicoById(int id)
    {
        try
        {
            var medico = _ctx.Medicos.FirstOrDefault(e => e.ID == id);
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
            var medico = _ctx.Medicos.Skip(page).Take(limit).ToList();
            return Result.Ok(medico);
        }
        catch (Exception error)
        {
            return Result.Fail(error.Message);
        }
    }
}
