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
public class ExameService
: AtendimentoService<
    Exame,
    ExameAgendamento,
    ExameCreationDto,
    ExameUpdateDto>,
IExameService
{
    private readonly ILogger<ExameService> _logger;
    private readonly IExameRepository _repo;
    private readonly IExameAgendamentoService _agendametoService;
    private readonly IPacienteRepository _pacienteRepo;
    private readonly IMedicoRepository _medicoRepo;
    private readonly AppDbContext _ctx;
    public ExameService(
        IPacienteRepository paciente,
        IMedicoRepository medico,
        IExameRepository repository,
        IExameAgendamentoService agendamento,
        AppDbContext context,
        ILogger<ExameService> logger)
    : base(paciente, medico, repository, agendamento, context, logger)
    {
        _pacienteRepo = paciente;
        _medicoRepo = medico;
        _ctx = context;
        _repo = repository;
        _agendametoService = agendamento;
        _logger = logger;
        _logger.LogDebug(1, $"NLog injected into ExameService");
    }

    /* public async Task<Result> Create(ExameCreationDto request) */
    /* { */
    /*     var resMedico = _medicoRepo */
    /*         .GetMedicoById(request.MedicoId); */
    /*     if (resMedico.IsFailed) */
    /*         return Result.Fail("Não foi possivel achar o medico"); */

    /*     var resPaciente = _pacienteRepo */
    /*         .GetPacienteById(request.PacienteId); */
    /*     if (resPaciente.IsFailed) */
    /*         return Result.Fail("Não foi possivel achar o paciente"); */

    /*     var resAgendamendo = await _agendametoService */
    /*         .GetAgendamentoById(request.AgendamentoId); */
    /*     if (resAgendamendo.IsFailed) */
    /*         return Result.Fail("Não foi possivel achar o agendamento"); */

    /*     Exame atividade = new(); */
    /*     atividade */
    /*         .Creation(request, resMedico.Value, resPaciente.Value); */
    /*     var respose = await _repo */
    /*         .Create(atividade); */
    /*     if (respose.IsFailed) */
    /*         return Result.Fail("Não foi possivel criar o atendimento"); */

    /*     var resLink = await _agendametoService */
    /*         .LinkAtendimento(respose.Value, request.AgendamentoId); */
    /*     if (resLink.IsFailed) */
    /*         return Result.Fail("Não foi possivel criar o atendimento"); */

    /*     return Result.Ok(); */
    /* } */
    /* public Result<List<Exame>> GetByDate( */
    /*     DateTime minDate, DateTime maxDate, */
    /*     int limit, int page) */
    /* { */
    /*     var results = new Result[10]; */
    /*     Result<List<Exame>> resultRetorn; */

    /*     if (limit < 1 || limit > 100) */
    /*         results.Append(Result.Fail("limite com valor errado")); */

    /*     if (page < 0) */
    /*         results.Append(Result.Fail("Page com valor negativo")); */

    /*     resultRetorn = Result.Merge(results); */
    /*     if (resultRetorn.IsFailed) */
    /*         return resultRetorn; */

    /*     var respose = _repo.GetByDate(minDate, maxDate, limit, page); */
    /*     return respose; */
    /* } */
    /* public async Task<Result<Exame>> GetById(Guid id) */
    /* { */
    /*     var respose = await _repo.GetById(id); */
    /*     if (respose.IsFailed) */
    /*         return Result.Fail("não foi possivel pegar a atividade"); */

    /*     return respose; */
    /* } */
    /* public Result<List<Exame>> GetByMedico( */
    /*     Guid medicoId, int limit, int page = 0) */
    /* { */
    /*     var results = new List<Result<List<Exame>>>(); */
    /*     if (page < 0) */
    /*         results.Add(Result.Fail("page é negativo")); */

    /*     if (limit < 0) */
    /*         results.Add(Result.Fail("limit é negativo")); */

    /*     var respose = _repo.GetByMedico(medicoId, limit, page); */
    /*     if (respose.IsFailed) */
    /*         return Result.Fail("não foi possivel pegar a atividade"); */

    /*     return respose; */
    /* } */
    /* public Result<List<Exame>> GetByPaciente( */
    /*     Guid pacienteId, int limit, int page = 0) */
    /* { */
    /*     var results = new List<Result<List<Exame>>>(); */
    /*     if (page < 0) */
    /*         results.Add(Result.Fail("page é negativo")); */

    /*     if (limit < 0) */
    /*         results.Add(Result.Fail("limit é negativo")); */

    /*     var respose = _repo.GetByPaciente(pacienteId, limit, page); */
    /*     if (respose.IsFailed) */
    /*         return Result.Fail("não foi possivel pegar a atividade"); */

    /*     return respose; */
    /* } */
    /* public Result<List<Exame>> GetByQuery( */
    /*     AtendimentoGetByQueryDto query) */
    /* { */
    /*     var results = new List<Result<List<Exame>>>(); */
    /*     if (query.Page < 0) */
    /*         results.Add(Result.Fail("page é negativo")); */

    /*     if (query.Limit < 0) */
    /*         results.Add(Result.Fail("limit é negativo")); */

    /*     if (query.Limit == null) */
    /*         query.Limit = 10; */

    /*     if (query.Page == null) */
    /*         query.Page = 0; */

    /*     var respose = _repo.GetByQuery(query); */
    /*     if (respose.IsFailed) */
    /*         return Result.Fail("não foi possivel pegar a atividade"); */

    /*     return respose; */
    /* } */

    /* public Task<Result> Update(ExameUpdateDto request, Guid id) */
    /* { */
    /*     throw new NotImplementedException(); */
    /* } */
}
