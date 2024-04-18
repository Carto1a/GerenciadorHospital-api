using FluentResults;
using Hospital.Database;
using Hospital.Dto.Atendimento.Create;
using Hospital.Dto.Atendimento.Get;
using Hospital.Models.Atendimento;
using Hospital.Repository.Atendimentos.Interfaces;
using Hospital.Repository.Cadastros.Interfaces;
using Hospital.Service.Agendamentos.Interfaces;
using Hospital.Service.Atendimentos.Interfaces;

namespace Hospital.Service.Atendimentos;
public class RetornoService
: IRetornoService
{
    private readonly IRetornoRepository _repo;
    private readonly IRetornoAgendamentoService _agendametoService;
    private readonly IPacienteRepository _pacienteRepo;
    private readonly IMedicoRepository _medicoRepo;
    private readonly AppDbContext _ctx;
    public RetornoService(
        IPacienteRepository paciente,
        IMedicoRepository medico,
        IRetornoRepository repository,
        IRetornoAgendamentoService agendamento,
        AppDbContext context)
    {
        _pacienteRepo = paciente;
        _medicoRepo = medico;
        _ctx = context;
        _repo = repository;
        _agendametoService = agendamento;
    }
    public async Task<Result> Create(RetornoCreationDto request)
    {
        var resMedico = _medicoRepo
            .GetMedicoById(request.MedicoId);
        if (resMedico.IsFailed)
            return Result.Fail("Não foi possivel achar o medico");

        var resPaciente = _pacienteRepo
            .GetPacienteById(request.PacienteId);
        if (resPaciente.IsFailed)
            return Result.Fail("Não foi possivel achar o paciente");

        var resAgendamendo = await _agendametoService
            .GetAgendamentoById(request.AgendamentoId);
        if (resAgendamendo.IsFailed)
            return Result.Fail("Não foi possivel achar o agendamento");

        Retorno atividade = new();
        atividade
            .Creation(request, resMedico.Value, resPaciente.Value);
        var respose = await _repo
            .Create(atividade);
        if (respose.IsFailed)
            return Result.Fail("Não foi possivel criar o atendimento");

        var resLink = await _agendametoService
            .LinkAtendimento(respose.Value, request.AgendamentoId);
        if (resLink.IsFailed)
            return Result.Fail("Não foi possivel criar o atendimento");

        return Result.Ok();
    }
    public Result<List<Retorno>> GetByDate(
        DateTime minDate, DateTime maxDate,
        int limit, int page)
    {
        var results = new Result[10];
        Result<List<Retorno>> resultRetorn;

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
    public async Task<Result<Retorno>> GetById(int id)
    {
        var respose = await _repo.GetById(id);
        if (respose.IsFailed)
            return Result.Fail("não foi possivel pegar a atividade");

        return respose;
    }
    public Result<List<Retorno>> GetByMedico(
        int medicoId, int limit, int page = 0)
    {
        var results = new List<Result<List<Retorno>>>();
        if (page < 0)
            results.Add(Result.Fail("page é negativo"));

        if (limit < 0)
            results.Add(Result.Fail("limit é negativo"));

        var respose = _repo.GetByMedico(medicoId, limit, page);
        if (respose.IsFailed)
            return Result.Fail("não foi possivel pegar a atividade");

        return respose;
    }
    public Result<List<Retorno>> GetByPaciente(
        int pacienteId, int limit, int page = 0)
    {
        var results = new List<Result<List<Retorno>>>();
        if (page < 0)
            results.Add(Result.Fail("page é negativo"));

        if (limit < 0)
            results.Add(Result.Fail("limit é negativo"));

        var respose = _repo.GetByPaciente(pacienteId, limit, page);
        if (respose.IsFailed)
            return Result.Fail("não foi possivel pegar a atividade");

        return respose;
    }
    public Result<List<Retorno>> GetByQuery(AtendimentoGetByQueryDto query)
    {
        var results = new List<Result<List<Retorno>>>();
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
}
