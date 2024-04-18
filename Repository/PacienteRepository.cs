using FluentResults;
using Hospital.Database;
using Hospital.Models;
using Hospital.Repository.Interfaces;

namespace Hospital.Repository;
public class PacienteRepository : IPacienteRepository
{
    private readonly AppDbContext _ctx;
    public PacienteRepository(AppDbContext context)
    {
        _ctx = context;
    }
    public Result<Paciente?> GetPacienteById(int id)
    {
        try
        {
            var paciente = _ctx.Pacientes.FirstOrDefault(e => e.ID == id);
            return Result.Ok(paciente);
        }
        catch (Exception error)
        {
            return Result.Fail(error.Message);
        }
    }
    public Result<List<Paciente>> GetPacientes(int limit, int page = 0)
    {
        try
        {
            var list = _ctx.Pacientes.Skip(page).Take(limit).ToList();
            return Result.Ok(list);
        }
        catch(Exception error)
        {
            return Result.Fail(error.Message);
        }
    }
}
