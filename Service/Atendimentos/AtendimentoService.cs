using FluentResults;

using Hospital.Database;
using Hospital.Dto.Atendimento.Create;
using Hospital.Dto.Atendimento.Get;
using Hospital.Dto.Atendimento.Update;
using Hospital.Models.Agendamentos;
using Hospital.Models.Atendimento;
using Hospital.Repository.Atendimentos.Interfaces;
using Hospital.Repository.Cadastros.Interfaces;
using Hospital.Service.Agendamentos.Interfaces;
using Hospital.Service.Atendimentos.Interfaces;

namespace Hospital.Service.Atendimentos;
public class AtendimentoService<T, TAgendamento, TCreation, TUpdate>
: IAtendimentoService<
    T,
    TAgendamento,
    TCreation,
    TUpdate>
    /* where T : IAtendimento<TCreation>, new() */
    where T : Atendimento, new()
    where TCreation : AtendimentoCreationDto
    where TAgendamento : Agendamento<T>
    where TUpdate : AtendimentoUpdateDto
{
    private readonly ILogger<AtendimentoService<T, TAgendamento, TCreation, TUpdate>> _logger;
    private readonly IAtendimentoRepository<T> _repo;
    private readonly IAgendamentoService<T, TAgendamento, TCreation> _agendametoService;
    private readonly IPacienteRepository _pacienteRepo;
    private readonly IMedicoRepository _medicoRepo;
    private readonly AppDbContext _ctx;
    public AtendimentoService(
        IPacienteRepository paciente,
        IMedicoRepository medico,
        IAtendimentoRepository<T> repository,
        IAgendamentoService<T, TAgendamento, TCreation> agendamento,
        AppDbContext context,
        ILogger<AtendimentoService<T, TAgendamento, TCreation, TUpdate>> logger)
    {
        _pacienteRepo = paciente;
        _medicoRepo = medico;
        _ctx = context;
        _repo = repository;
        _agendametoService = agendamento;
        _logger = logger;
        _logger.LogDebug(1, $"NLog injected into AtendimentoService {typeof(T).Name}");
    }
    public async Task<Result> Create(TCreation request)
    {
        _logger.LogInformation($"Criando atendimento - {typeof(T).Name}");
        var resMedico = _medicoRepo
            .GetMedicoById(request.MedicoId);
        if (resMedico.IsFailed)
        {
            _logger.LogError($"Não foi possivel achar o medico: {request.MedicoId} - {typeof(T).Name}");
            return Result.Fail("Não foi possivel achar o medico");
        }

        var resPaciente = _pacienteRepo
            .GetPacienteById(request.PacienteId);
        if (resPaciente.IsFailed)
        {
            _logger.LogError($"Não foi possivel achar o paciente: {request.PacienteId} - {typeof(T).Name}");
            return Result.Fail("Não foi possivel achar o paciente");
        }

        var resAgendamendo = await _agendametoService
            .GetAgendamentoById(request.AgendamentoId);
        if (resAgendamendo.IsFailed)
        {
            _logger.LogError($"Não foi possivel achar o agendamento: {request.AgendamentoId} - {typeof(T).Name}");
            return Result.Fail("Não foi possivel achar o agendamento");
        }

        T atividade = new();
        atividade
            .Creation(request, resMedico.Value, resPaciente.Value);
        var respose = await _repo.Create(atividade);
        if (respose.IsFailed)
        {
            _logger.LogError($"Não foi possivel criar o atendimento - {typeof(T).Name}");
            return Result.Fail("Não foi possivel criar o atendimento");
        }

        var resLink = await _agendametoService
            .LinkAtendimento(respose.Value, request.AgendamentoId);
        if (resLink.IsFailed)
        {
            _logger.LogError($"Não foi possivel linkar o atendimento: {request.AgendamentoId} - {typeof(T).Name}");
            return Result.Fail("Não foi possivel criar o atendimento");
        }

        var id = respose.Value.Id;
        _logger.LogInformation($"Atendimento criado com sucesso: {id} - {typeof(T).Name}");
        return Result.Ok();
    }
    public Result<List<T>> GetByDate(
        DateTime minDate, DateTime maxDate,
        int limit, int page)
    {
        _logger.LogInformation($"Pegando atendimentos por data - {typeof(T).Name}");
        var results = new Result[10];
        Result<List<T>> resultRetorn;

        if (limit < 1 || limit > 100)
            results.Append(Result.Fail("limite com valor errado"));

        if (page < 0)
            results.Append(Result.Fail("Page com valor negativo"));

        resultRetorn = Result.Merge(results);
        if (resultRetorn.IsFailed)
        {
            _logger.LogError($"Erro ao pegar atendimentos por data - {typeof(T).Name}");
            return resultRetorn;
        }

        var respose = _repo.GetByDate(minDate, maxDate, limit, page);
        _logger.LogInformation($"Atendimentos por data pegos com sucesso: {respose.Value.Count} - {typeof(T).Name}");
        return respose;
    }
    public async Task<Result<T?>> GetById(Guid id)
    {
        _logger.LogInformation($"Pegando atendimento por id: {id} - {typeof(T).Name}");
        var respose = await _repo.GetById(id);
        if (respose.IsFailed)
        {
            _logger.LogError($"Não foi possivel pegar a atividade: {id} - {typeof(T).Name}");
            return Result.Fail("não foi possivel pegar a atividade");
        }

        _logger.LogInformation($"Atendimento por id pegos com sucesso: {id} - {typeof(T).Name}");
        return respose;
    }
    public Result<List<T>> GetByMedico(
        Guid medicoId, int limit, int page = 0)
    {
        _logger.LogInformation($"Pegando atendimentos por medico: {medicoId} - {typeof(T).Name}");
        var results = new List<Result<List<T>>>();
        if (page < 0)
            results.Add(Result.Fail("page é negativo"));

        if (limit < 0)
            results.Add(Result.Fail("limit é negativo"));

        var respose = _repo.GetByMedico(medicoId, limit, page);
        if (respose.IsFailed)
        {
            _logger.LogError($"Não foi possivel achar o medico: {medicoId} - {typeof(T).Name}");
            return Result.Fail("não foi possivel pegar a atividade");
        }

        _logger.LogInformation($"Atendimentos por medico pegos com sucesso: {respose.Value.Count} - {typeof(T).Name}");
        return respose;
    }
    public Result<List<T>> GetByPaciente(
        Guid pacienteId, int limit, int page = 0)
    {
        _logger.LogInformation($"Pegando atendimentos por paciente: {pacienteId} - {typeof(T).Name}");
        var results = new List<Result<List<T>>>();
        if (page < 0)
            results.Add(Result.Fail("page é negativo"));

        if (limit < 0)
            results.Add(Result.Fail("limit é negativo"));

        var respose = _repo.GetByPaciente(pacienteId, limit, page);
        if (respose.IsFailed)
        {
            _logger.LogError($"Não foi possivel achar o paciente: {pacienteId} - {typeof(T).Name}");
            return Result.Fail("não foi possivel pegar a atividade");
        }

        _logger.LogInformation($"Atendimentos por paciente pegos com sucesso: {respose.Value.Count} - {typeof(T).Name}");
        return respose;
    }
    public Result<List<T>> GetByQuery(AtendimentoGetByQueryDto query)
    {
        _logger.LogInformation($"Pegando atendimentos por query: {query.Serialize()} - {typeof(T).Name}");
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
        {
            _logger.LogError($"Não foi possivel pegar a atividade por query: {query.Serialize()} - {typeof(T).Name}");
            return Result.Fail("não foi possivel pegar a atividade");
        }

        _logger.LogInformation($"Atendimentos por query pegos com sucesso: {respose.Value.Count} - {typeof(T).Name}");
        return respose;
    }

    public Task<Result> Update(TUpdate request, Guid id)
    {
        throw new NotImplementedException();
    }
}