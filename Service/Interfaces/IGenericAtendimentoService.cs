using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentResults;
using Hospital.Dto.Agendamento;
using Hospital.Dto.Atividades;

namespace Hospital.Service.Interfaces;
public interface IGenericAtendimentoService<T, TAgendamento, TCreation>
{
    Task<Result> CreateAgendamento(AgendamentoCreateDto agendamento);
    Task<Result> Create(TCreation exame);
    Task<Result> CancelAgendamento(int id);
    Task<Result> UpdateDateAgendamento(int id, DateTime date);
    Task<Result> UpdateAgendamento(TAgendamento agendamento, int id);
    Task<Result<T>> GetById(int id);
    Task<Result<List<T>>> GetByQuery(AtendimentoGetQueryDto query);
    Task<Result<List<T>>> GetByPaciente(int pacienteId);
    Task<Result<List<T>>> GetByMedico(int medicoId);
    Task<Result<List<T>>> GetByDate(DateTime minDate, DateTime maxDate);
    Task<Result<TAgendamento>> GetAgendamentoById(int id);
    Task<Result<List<TAgendamento>>> GetAgendamentosByPaciente(int pacienteId);
    Task<Result<List<TAgendamento>>> GetAgendamentosByMedico(int medicoId);
    Task<Result<List<TAgendamento>>> GetAgendamentosByDate(DateTime minDate, DateTime maxDate);
}
