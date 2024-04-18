using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hospital.Database;
using Hospital.Models;
using Hospital.Models.Agendamentos;
using Hospital.Repository.Interfaces;

namespace Hospital.Repository;
public class GenericAtentimento<T, TAgendamento> : IGenericAtentimentoRepository<T, TAgendamento>
    where T : Atendimento 
    where TAgendamento : Agendamento<T>
{
    private readonly AppDbContext _ctx;
    public Task Create(T exame)
    {
        throw new NotImplementedException();
    }

    public async Task CreateAgentamento(TAgendamento agentamento)
    {
        await _ctx.Set<TAgendamento>().AddAsync(agentamento);
        _ctx.SaveChanges();
    }

    public List<TAgendamento> GetAgendamentosByDate(DateTime minDate, DateTime maxDate, int limit, int page = 0)
    {
        return _ctx.Set<TAgendamento>()
            .Where(e => e.DataHora >= minDate && e.DataHora <= maxDate)
            .Skip(page)
            .Take(limit)
            .ToList();
    }

    public TAgendamento? GetAgendamentosById(int id)
    {
        return _ctx.Set<TAgendamento>()
            .FirstOrDefault(e => e.ID == id); 
    }

    public List<TAgendamento> GetAgendamentosByMedico(int medicoId, int limit, int page = 0)
    {
        return _ctx.Set<TAgendamento>()
            .Where(e => e.Medico.ID == medicoId)
            .Skip(page)
            .Take(limit)
            .ToList();
    }

    public List<TAgendamento> GetAgendamentosByPaciente(int pacienteId, int limit, int page = 0)
    {
        return _ctx.Set<TAgendamento>()
            .Where(e => e.Paciente.ID == pacienteId)
            .Skip(page)
            .Take(limit)
            .ToList();
    }

    public List<T> GetByDate(DateTime minDate, DateTime maxDate, int limit, int page = 0)
    {
        return _ctx.Set<T>()
            .Where(e => e.DataHora >= minDate && e.DataHora <= maxDate)
            .Skip(page)
            .Take(limit)
            .ToList();
    }

    public T? GetById(int id)
    {
        return _ctx.Set<T>()
            .FirstOrDefault(e => e.ID == id); 
    }

    public List<T> GetByMedico(int medicoId, int limit, int page = 0)
    {
        return _ctx.Set<T>()
            .Where(e => e.Medico.ID == medicoId)
            .Skip(page)
            .Take(limit)
            .ToList();
    }

    public List<T> GetByPaciente(int pacienteId, int limit, int page = 0)
    {
        return _ctx.Set<T>()
            .Where(e => e.Paciente.ID == pacienteId)
            .Skip(page)
            .Take(limit)
            .ToList();
    }

    public Task UpdateAgentamento(TAgendamento NovoAgendamento, int Id)
    {
        throw new NotImplementedException();
    }
}
