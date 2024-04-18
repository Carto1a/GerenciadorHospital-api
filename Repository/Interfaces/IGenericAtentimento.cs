using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hospital.Models;

namespace Hospital.Repository.Interfaces;
public interface IGenericAtentimento<T, TAgendamento>
{
    Task Create(T exame, TAgendamento agendamento);
    Task<T> GetById(int id);
    Task<List<T>> GetByDate(DateTime minDate, DateTime maxDate);
    Task<List<T>> GetByMedico(int medicoId);
    Task<List<T>> GetByPaciente(int pacienteId);
    Task CreateAgentamento(TAgendamento agentamento);
    Task UpdateAgentamento(TAgendamento NovoAgendamento, int Id);
    Task<TAgendamento> GetAgendamentosById(int id);
    Task<List<TAgendamento>> GetAgendamentosByPaciente(Paciente pacienteId);
    Task<List<TAgendamento>> GetAgendamentosByMedico(Medico medicoId);
    Task<List<TAgendamento>> GetAgendamentosByDate(DateTime minDate, DateTime maxDate);
}
