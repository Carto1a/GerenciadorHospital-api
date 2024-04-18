using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public Paciente? GetPacienteById(int id)
    {
        var paciente = _ctx.Pacientes.FirstOrDefault(e => e.ID == id);
        return paciente; 
    }
    public List<Paciente> GetPacientes(int limit, int page = 0)
    {
        return _ctx.Pacientes.Skip(page).Take(limit).ToList();
    }
}
