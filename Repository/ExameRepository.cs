using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hospital.Database;
using Hospital.Models;
using Hospital.Models.Agendamentos;
using Hospital.Repository.Interfaces;

namespace Hospital.Repository;

public class ExameRepository : GenericAtentimento<Exame, ExameAgendamento>, IExamesRepository
{
    // private readonly AppDbContext _ctx;
    // public Task Create(Exame exame, ExameAgendamento agendamento)
    // {
    //     throw new NotImplementedException();
    // }

    // public async Task CreateAgentamento(ExameAgendamento agentamento)
    // {
    //     await _ctx.AgendamentosExames.AddAsync(agentamento);
    //     _ctx.SaveChanges();
    // }

    // public List<ExameAgendamento> GetAgendamentosByDate(DateTime minDate, DateTime maxDate, int limit, int page = 0)
    // {
    //     return _ctx.AgendamentosExames
    //         .Where(e => e.DataHora >= minDate && e.DataHora <= maxDate)
    //         .Skip(page)
    //         .Take(limit)
    //         .ToList();
    // }

    // public ExameAgendamento GetAgendamentosById(int id)
    // {
    //     return _ctx.AgendamentosExames
    //         .FirstOrDefault(e => e.ID == id); 
    // }

    // public List<ExameAgendamento> GetAgendamentosByMedico(int medicoId, int limit, int page = 0)
    // {
    //     return _ctx.AgendamentosExames
    //         .Where(e => e.Medico.ID == medicoId)
    //         .Skip(page)
    //         .Take(limit)
    //         .ToList();
    // }

    // public List<ExameAgendamento> GetAgendamentosByPaciente(int pacienteId, int limit, int page = 0)
    // {
    //     return _ctx.AgendamentosExames
    //         .Where(e => e.Paciente.ID == pacienteId)
    //         .Skip(page)
    //         .Take(limit)
    //         .ToList();
    // }

    // public List<Exame> GetByDate(DateTime minDate, DateTime maxDate, int limit, int page = 0)
    // {
    //     return _ctx.Exames
    //         .Where(e => e.DataHora >= minDate && e.DataHora <= maxDate)
    //         .Skip(page)
    //         .Take(limit)
    //         .ToList();
    // }

    // public Exame GetById(int id)
    // {
    //     return _ctx.Exames
    //         .FirstOrDefault(e => e.ID == id); 
    // }

    // public List<Exame> GetByMedico(int medicoId, int limit, int page = 0)
    // {
    //     return _ctx.Exames
    //         .Where(e => e.Medico.ID == medicoId)
    //         .Skip(page)
    //         .Take(limit)
    //         .ToList();
    // }

    // public List<Exame> GetByPaciente(int pacienteId, int limit, int page = 0)
    // {
    //     return _ctx.Exames
    //         .Where(e => e.Paciente.ID == pacienteId)
    //         .Skip(page)
    //         .Take(limit)
    //         .ToList();
    // }

    // public Task UpdateAgentamento(ExameAgendamento NovoAgendamento, int Id)
    // {
    //     throw new NotImplementedException();
    // }
}
