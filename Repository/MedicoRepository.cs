using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public Medico? GetMedicoById(int id)
    {
        var medico = _ctx.Medicos.FirstOrDefault(e => e.ID == id);
        return medico;
    }

    public List<Medico> GetMedicos(int limit, int page = 0)
    {
        return _ctx.Medicos.Skip(page).Take(limit).ToList();
    }
}
