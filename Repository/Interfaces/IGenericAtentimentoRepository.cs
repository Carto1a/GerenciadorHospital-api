using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hospital.Models;

namespace Hospital.Repository.Interfaces;
public interface IGenericAtentimentoRepository<T, TAgendamento>
{
    Task Create(T exame);
    T GetById(int id);
    List<T> GetByDate(DateTime minDate, DateTime maxDate, int limit, int page = 0);
    List<T> GetByMedico(int medicoId, int limit, int page = 0);
    List<T> GetByPaciente(int pacienteId, int limit, int page = 0);
    Task CreateAgentamento(TAgendamento agentamento);
    Task UpdateAgentamento(TAgendamento NovoAgendamento, int Id);
    TAgendamento GetAgendamentosById(int id);
    List<TAgendamento> GetAgendamentosByPaciente(int pacienteId, int limit, int page = 0);
    List<TAgendamento> GetAgendamentosByMedico(int medicoId, int limit, int page = 0);
    List<TAgendamento> GetAgendamentosByDate(DateTime minDate, DateTime maxDate, int limit, int page = 0);
}
