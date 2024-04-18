using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using FluentResults;
using Hospital.Database;
using Hospital.Dto.Agendamento;
using Hospital.Dto.Atividades;
using Hospital.Models;
using Hospital.Models.Agendamentos;
using Hospital.Repository.Interfaces;

namespace Hospital.Service.Interfaces;
public class ExameService : IExameService
{
    private readonly IExamesRepository _exameRepo;
    private readonly IPacienteRepository _pacienteRepo; 
    private readonly IMedicoRepository _medicoRepo;
    private readonly AppDbContext _ctx;

    public ExameService(
        IExamesRepository exames,
        IPacienteRepository paciente,
        IMedicoRepository medico,
        AppDbContext context)
    {
        _ctx = context;
        _exameRepo = exames;
        _pacienteRepo = paciente;
        _medicoRepo = medico;
    }
    public Task<Result> CancelAgendamento(int id)
    {
        throw new NotImplementedException();
    }
    public Task<Result> Create(ExameCreationDto exame)
    {
        throw new NotImplementedException();
    }
    public async Task<Result> CreateAgendamento(AgendamentoCreateDto request)
    {
        var results = new List<Result>();
        var medico = _medicoRepo.GetMedicoById(request.MedicoId);
        var paciente = _pacienteRepo.GetPacienteById(request.PacienteId);

        results.Add(medico == null? Result.Fail("Medico não existe"): Result.Ok());
        results.Add(paciente == null? Result.Fail("Paciente não existe"): Result.Ok());

        var mergedResult = results.Merge();

        if(mergedResult.IsFailed)
            return mergedResult;

        ExameAgendamento agendamento = new()
        {
            Paciente = paciente,
            Medico = medico,
            DataHora = request.DataHora,
            Criação = DateTime.Now,
            Tipo = null,
            Cancelado = false,
            Custo = request.Custo,
            Convenio = request.Convenio 
        };

        await _exameRepo.CreateAgentamento(agendamento);

        return Result.Ok();
    }
    public Task<Result<ExameAgendamento>> GetAgendamentoById(int id)
    {
        throw new NotImplementedException();
    }
    public Task<Result<List<ExameAgendamento>>> GetAgendamentosByDate(DateTime minDate, DateTime maxDate)
    {
        throw new NotImplementedException();
    }
    public Task<Result<List<ExameAgendamento>>> GetAgendamentosByMedico(int medicoId)
    {
        throw new NotImplementedException();
    }
    public Task<Result<List<ExameAgendamento>>> GetAgendamentosByPaciente(int pacienteId)
    {
        throw new NotImplementedException();
    }
    public Task<Result<Exame>> GetExameById(int id)
    {
        throw new NotImplementedException();
    }
    public Task<Result<List<Exame>>> GetExamesByDate(DateTime minDate, DateTime maxDate)
    {
        throw new NotImplementedException();
    }
    public Task<Result<List<Exame>>> GetExamesByMedico(int medicoId)
    {
        throw new NotImplementedException();
    }
    public Task<Result<List<Exame>>> GetExamesByPaciente(int pacienteId)
    {
        throw new NotImplementedException();
    }

    public Task<Result<List<Exame>>> GetExamesByQuery(ExameGetQueryDto query)
    {
        throw new NotImplementedException();
    }

    public Task<Result> UpdateAgendamento(ExameAgendamento agendamento, int id)
    {
        throw new NotImplementedException();
    }

    public Task<Result> UpdateDateAgendamento(int id, DateTime date)
    {
        throw new NotImplementedException();
    }
}
