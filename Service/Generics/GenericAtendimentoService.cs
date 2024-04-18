using FluentResults;
using Hospital.Database;
using Hospital.Dto.Agendamento;
using Hospital.Dto.Atividades;
using Hospital.Models;
using Hospital.Models.Agendamentos;
using Hospital.Models.Generics.Interfaces;
using Hospital.Repository.Generics.Interfaces;
using Hospital.Repository.Interfaces;
using Hospital.Service.Generics.Interfaces;

namespace Hospital.Service.Generics;
public class GenericAtendimentoService<T, TAgendamento, TCreation> :
    IGenericAtendimentoService<T, TAgendamento, TCreation>
    where T : IAtendimento<TCreation>, new()
    where TAgendamento : Agendamento<T>, new()
    where TCreation : GenericAtividadesCreationDto
{
    private readonly IGenericAtendimentoRepository<T, TAgendamento> _repo;
    private readonly IPacienteRepository _pacienteRepo;
    private readonly IMedicoRepository _medicoRepo;
    private readonly AppDbContext _ctx;
    public GenericAtendimentoService(
        IPacienteRepository paciente,
        IMedicoRepository medico,
        IGenericAtendimentoRepository<T, TAgendamento> repository,
        AppDbContext context)
    {
        _pacienteRepo = paciente;
        _medicoRepo = medico;
        _ctx = context;
        _repo = repository;
    }
    public Task<Result> CancelAgendamento(int id)
    {
        // TODO: repo adicionar update
        throw new NotImplementedException();
    }
    public async Task<Result> Create(TCreation request)
    {
        var resMedico = _medicoRepo.GetMedicoById(request.MedicoId);
        if (resMedico.IsFailed)
            return Result.Fail("Não foi possivel achar o medico");

        var resPaciente = _pacienteRepo.GetPacienteById(request.PacienteId);
        if (resPaciente.IsFailed)
            return Result.Fail("Não foi possivel achar o paciente");

        var resAgendamendo = await _repo.GetAgendamentoById(request.AgendamentoId);
        if (resAgendamendo.IsFailed)
            return Result.Fail("Não foi possivel achar o agendamento");

        T atividade = new();
        atividade.Creation(request, resMedico.Value, resPaciente.Value);
        var respose = await _repo.Create(atividade);
        if (respose.IsFailed)
            return Result.Fail("Não foi possivel criar o atendimento");

        var resLink = await LinkAtendimento(respose.Value, request.AgendamentoId);
        if (resLink.IsFailed)
            return Result.Fail("Não foi possivel criar o atendimento");

        return Result.Ok();
    }
    public async Task<Result> CreateAgendamento(AgendamentoCreateDto request)
    {
        var results = new List<Result>();
        var medico = _medicoRepo.GetMedicoById(request.MedicoId);
        var paciente = _pacienteRepo.GetPacienteById(request.PacienteId);

        results.Add(medico == null ? Result.Fail("Medico não existe") : Result.Ok());
        results.Add(paciente == null ? Result.Fail("Paciente não existe") : Result.Ok());

        var mergedResult = results.Merge();

        if (mergedResult.IsFailed)
            return mergedResult;

        TAgendamento agendamento = new()
        {
            Paciente = paciente.Value,
            Medico = medico.Value,
            DataHora = request.DataHora,
            Criação = DateTime.Now,
            Tipo = default,
            Cancelado = false,
            Custo = request.Custo,
            Convenio = request.Convenio
        };

        var respose = await _repo.CreateAgentamento(agendamento);
        if (respose.IsFailed)
            return Result.Fail("Não foi possivel criar o agendamento");

        return Result.Ok();
    }
    public async Task<Result> LinkAtendimento(T entity, int id)
    {
        var resAgendamendo = await GetAgendamentoById(id);
        if (resAgendamendo.IsFailed)
            return Result.Fail("Não foi possivel linkar o agendamento");

        var agendamento = resAgendamendo.Value;
        agendamento.Tipo = entity;

        var response = await _repo.UpdateAgentamento(agendamento);
        if (response.IsFailed)
            return Result.Fail("Falha a dar update no agendamento");

        return Result.Ok();
    }
    public async Task<Result<TAgendamento>> GetAgendamentoById(int id)
    {
        var respose = await _repo.GetAgendamentoById(id);
        if (respose.IsFailed)
            return Result.Fail("Não foi possivel achar o agendamento");

        return respose;
    }
    public Result<List<TAgendamento>> GetAgendamentosByDate(
        DateTime minDate, DateTime maxDate, int limit, int page = 0)
    {
        var results = new List<Result<List<TAgendamento>>>();
        if (page < 0)
            results.Add(Result.Fail("page é negativo"));

        if (limit < 0)
            results.Add(Result.Fail("limit é negativo"));

        var respose = _repo.GetAgendamentosByDate(minDate, maxDate, limit, page);
        if (respose.IsFailed)
            return Result.Fail("Não foi possivel pegar o agendamento");

        return respose;
    }
    public Result<List<TAgendamento>> GetAgendamentosByMedico(
        int medicoId, int limit, int page = 0)
    {
        var results = new List<Result<List<TAgendamento>>>();
        if (page < 0)
            results.Add(Result.Fail("page é negativo"));

        if (limit < 0)
            results.Add(Result.Fail("limit é negativo"));

        var respose = _repo.GetAgendamentosByMedico(medicoId, limit, page);
        if (respose.IsFailed)
            return Result.Fail("Não foi possivel pegar os Agendamentos");

        return respose;

    }
    public Result<List<TAgendamento>> GetAgendamentosByPaciente(
        int pacienteId, int limit, int page = 0)
    {
        var results = new List<Result<List<TAgendamento>>>();
        if (page < 0)
            results.Add(Result.Fail("page é negativo"));

        if (limit < 0)
            results.Add(Result.Fail("limit é negativo"));

        var respose = _repo.GetAgendamentosByPaciente(pacienteId, limit, page);
        if (respose.IsFailed)
            return Result.Fail("Não foi possivel pegar os Agendamentos");

        return respose;
    }
    public Result<List<T>> GetByDate(
        DateTime minDate, DateTime maxDate,
        int limit, int page)
    {
        var results = new Result[10];
        Result<List<T>> resultRetorn;

        if (limit < 1 || limit > 100)
            results.Append(Result.Fail("limite com valor errado"));

        if (page < 0)
            results.Append(Result.Fail("Page com valor negativo"));

        resultRetorn = Result.Merge(results);
        if (resultRetorn.IsFailed)
            return resultRetorn;

        var respose = _repo.GetByDate(minDate, maxDate, limit, page);
        return respose;
    }
    public async Task<Result<T>> GetById(int id)
    {
        var respose = await _repo.GetById(id);
        if (respose.IsFailed)
            return Result.Fail("não foi possivel pegar a atividade");

        return respose;
    }
    public Result<List<T>> GetByMedico(
        int medicoId, int limit, int page = 0)
    {
        var results = new List<Result<List<TAgendamento>>>();
        if (page < 0)
            results.Add(Result.Fail("page é negativo"));

        if (limit < 0)
            results.Add(Result.Fail("limit é negativo"));

        var respose = _repo.GetByMedico(medicoId, limit, page);
        if (respose.IsFailed)
            return Result.Fail("não foi possivel pegar a atividade");

        return respose;
    }
    public Result<List<T>> GetByPaciente(
        int pacienteId, int limit, int page = 0)
    {
        var results = new List<Result<List<TAgendamento>>>();
        if (page < 0)
            results.Add(Result.Fail("page é negativo"));

        if (limit < 0)
            results.Add(Result.Fail("limit é negativo"));

        var respose = _repo.GetByPaciente(pacienteId, limit, page);
        if (respose.IsFailed)
            return Result.Fail("não foi possivel pegar a atividade");

        return respose;
    }
    public Result<List<T>> GetByQuery(AtendimentoGetQueryDto query)
    {
        var results = new List<Result<List<T>>>();
        if (query.Page < 0)
            results.Add(Result.Fail("page é negativo"));

        if (query.Limit < 0)
            results.Add(Result.Fail("limit é negativo"));

        if (query.Limit == null)
            query.Limit = 10;

        if (query.Page == null)
            query.Page = 0;

        var respose = _repo.GetByQuery(query);
        if (respose.IsFailed)
            return Result.Fail("não foi possivel pegar a atividade");

        return respose;
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
