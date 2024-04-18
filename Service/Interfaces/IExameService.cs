using FluentResults;
using Hospital.Dto.Agendamento;
using Hospital.Dto.Atividades;
using Hospital.Models;
using Hospital.Models.Agendamentos;

namespace Hospital.Service.Interfaces;
public interface IExameService
{
    Task<Result> CreateAgendamento(AgendamentoCreateDto agendamento);
    Task<Result> Create(ExameCreationDto exame);
    Task<Result> CancelAgendamento(int id);
    Task<Result> UpdateDateAgendamento(int id, DateTime date);
    Task<Result> UpdateAgendamento(ExameAgendamento agendamento, int id);
    Task<Result<Exame>> GetExameById(int id);
    Task<Result<List<Exame>>> GetExamesByQuery(ExameGetQueryDto query);
    Task<Result<List<Exame>>> GetExamesByPaciente(int pacienteId);
    Task<Result<List<Exame>>> GetExamesByMedico(int medicoId);
    Task<Result<List<Exame>>> GetExamesByDate(DateTime minDate, DateTime maxDate);
    Task<Result<ExameAgendamento>> GetAgendamentoById(int id);
    Task<Result<List<ExameAgendamento>>> GetAgendamentosByPaciente(int pacienteId);
    Task<Result<List<ExameAgendamento>>> GetAgendamentosByMedico(int medicoId);
    Task<Result<List<ExameAgendamento>>> GetAgendamentosByDate(DateTime minDate, DateTime maxDate);
}
