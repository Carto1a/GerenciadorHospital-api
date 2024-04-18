using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentResults;
using Hospital.Dto.Agendamento;
using Hospital.Dto.Atividades;
using Hospital.Repository.Interfaces;
using Hospital.Service.Interfaces;

namespace Hospital.Service;
public class GenericAtendimentoService<T, TAgendamento, TCreation> :
    IGenericAtendimentoService<T, TAgendamento, TCreation>
{
    private readonly IGenericAtentimentoRepository<T, TAgendamento> _repo;
    public Task<Result> CancelAgendamento(int id)
    {
        throw new NotImplementedException();
    }
    public Task<Result> Create(TCreation exame)
    {
        throw new NotImplementedException();
    }
    public Task<Result> CreateAgendamento(AgendamentoCreateDto agendamento)
    {
        throw new NotImplementedException();
    }
    public Task<Result<TAgendamento>> GetAgendamentoById(int id)
    {
        throw new NotImplementedException();
    }
    public Task<Result<List<TAgendamento>>> GetAgendamentosByDate(DateTime minDate, DateTime maxDate)
    {
        throw new NotImplementedException();
    }
    public Task<Result<List<TAgendamento>>> GetAgendamentosByMedico(int medicoId)
    {
        throw new NotImplementedException();
    }
    public Task<Result<List<TAgendamento>>> GetAgendamentosByPaciente(int pacienteId)
    {
        throw new NotImplementedException();
    }
    public Task<Result<List<T>>> GetByDate(DateTime minDate, DateTime maxDate)
    {
        throw new NotImplementedException();
    }
    public Task<Result<T>> GetById(int id)
    {
        throw new NotImplementedException();
    }
    public Task<Result<List<T>>> GetByMedico(int medicoId)
    {
        throw new NotImplementedException();
    }
    public Task<Result<List<T>>> GetByPaciente(int pacienteId)
    {
        throw new NotImplementedException();
    }
    public Task<Result<List<T>>> GetByQuery(AtendimentoGetQueryDto query)
    {
        throw new NotImplementedException();
    }
    public Task<Result> UpdateAgendamento(TAgendamento agendamento, int id)
    {
        throw new NotImplementedException();
    }
    public Task<Result> UpdateDateAgendamento(int id, DateTime date)
    {
        throw new NotImplementedException();
    }
}
