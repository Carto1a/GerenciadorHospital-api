using FluentResults;
using Hospital.Database;
using Hospital.Dto.Agendamento.Create;
using Hospital.Dto.Agendamento.Get;
using Hospital.Dto.Agendamento.Update;
using Hospital.Dto.Atendimento.Create;
using Hospital.Models.Agendamentos;
using Hospital.Models.Atendimento;
using Hospital.Repository.Atendimentos.Interfaces;
using Hospital.Repository.Cadastros.Interfaces;
using Hospital.Repository.Convenios.Ineterfaces;
using Hospital.Service.Agendamentos.Interfaces;

namespace Hospital.Service.Agendamentos;
public class RetornoAgendamentoService
: AgendamentoService<
    Retorno,
    RetornoAgendamento,
    RetornoCreationDto>,
IRetornoAgendamentoService
{
    private readonly ILogger<RetornoAgendamentoService> _logger;
    private readonly IRetornoAgendamentoRepository _repo;
    private readonly IMedicoRepository _medicoRepo;
    private readonly IPacienteRepository _pacienteRepo;
    private readonly IConvenioRepository _convenioRepo;
    private readonly AppDbContext _ctx;
    public RetornoAgendamentoService(
        IPacienteRepository paciente,
        IMedicoRepository medico,
        IConvenioRepository convenio,
        IRetornoAgendamentoRepository repository,
        AppDbContext context,
        ILogger<RetornoAgendamentoService> logger)
    : base(paciente, medico, convenio, repository, context, logger)
    {
        _pacienteRepo = paciente;
        _medicoRepo = medico;
        _convenioRepo = convenio;
        _ctx = context;
        _repo = repository;
        _logger = logger;
        _logger.LogDebug(1, $"NLog injected into RetornoAgendamentoService");
    }

    /* public async Task<Result> CancelAgendamento(Guid id) */
    /* { */
    /*     var resAgendamendo = await GetAgendamentoById(id); */
    /*     if (resAgendamendo.IsFailed) */
    /*         return Result.Fail("Não foi possivel linkar o agendamento"); */

    /*     var agendamento = resAgendamendo.Value; */
    /*     agendamento.Cancelar(); */

    /*     var response = await _repo.UpdateAgentamento(agendamento); */
    /*     if (response.IsFailed) */
    /*         return Result.Fail("Falha a dar update no agendamento"); */

    /*     return Result.Ok(); */
    /* } */
    /* public async Task<Result> CreateAgendamento( */
    /*     AgendamentoCreateDto request) */
    /* { */
    /*     var results = new List<Result>(); */
    /*     var medico = _medicoRepo.GetMedicoById(request.MedicoId); */
    /*     var paciente = _pacienteRepo.GetPacienteById(request.PacienteId); */
    /*     var convenio = _convenioRepo.GetConvenioById((Guid)request.ConvenioId); */

    /*     results.Add(request.DataHora < DateTime.Now ? */
    /*             Result.Fail("Data e hora inválida") : Result.Ok()); */
    /*     results.Add(medico.Value == null ? */
    /*             Result.Fail("Medico não existe") : Result.Ok()); */
    /*     results.Add(paciente.Value == null ? */
    /*             Result.Fail("Paciente não existe") : Result.Ok()); */

    /*     var mergedResult = results.Merge(); */

    /*     if (mergedResult.IsFailed || convenio.IsFailed) */
    /*         return mergedResult; */

    /*     var CustoFinal = request.Custo; */
    /*     if (convenio.Value != null) */
    /*         CustoFinal -= request.Custo * convenio.Value.Desconto; */

    /*     RetornoAgendamento agendamento = new() */
    /*     { */
    /*         Paciente = paciente.Value, */
    /*         Medico = medico.Value, */
    /*         DataHora = request.DataHora, */
    /*         Criação = DateTime.Now, */
    /*         Tipo = default, */
    /*         TipoId = default, */
    /*         Status = AgendamentoStatus.Agendado, */
    /*         Custo = request.Custo, */
    /*         Convenio = convenio.Value, */
    /*         CustoFinal = CustoFinal, */
    /*         Deletado = false */
    /*     }; */

    /*     var respose = await _repo.CreateAgentamento(agendamento); */
    /*     if (respose.IsFailed) */
    /*         return Result.Fail("Não foi possivel criar o agendamento"); */

    /*     return Result.Ok(); */
    /* } */
    /* public async Task<Result> LinkAtendimento(Retorno entity, Guid id) */
    /* { */
    /*     var resAgendamendo = await GetAgendamentoById(id); */
    /*     if (resAgendamendo.IsFailed) */
    /*         return Result.Fail("Não foi possivel linkar o agendamento"); */

    /*     var agendamento = resAgendamendo.Value; */
    /*     agendamento.Link(entity); */

    /*     var response = await _repo.UpdateAgentamento(agendamento); */
    /*     if (response.IsFailed) */
    /*         return Result.Fail("Falha a dar update no agendamento"); */

    /*     return Result.Ok(); */
    /* } */
    /* public async Task<Result<RetornoAgendamento?>> GetAgendamentoById( */
    /*     Guid id) */
    /* { */
    /*     var respose = await _repo.GetAgendamentoById(id); */
    /*     if (respose.IsFailed) */
    /*         return Result.Fail("Não foi possivel achar o agendamento"); */

    /*     return respose; */
    /* } */
    /* public Result<List<RetornoAgendamento>> GetAgendamentosByDate( */
    /*     DateTime minDate, DateTime maxDate, int limit, int page = 0) */
    /* { */
    /*     var results = new List<Result<List<RetornoAgendamento>>>(); */
    /*     if (page < 0) */
    /*         results.Add(Result.Fail("page é negativo")); */

    /*     if (limit < 0) */
    /*         results.Add(Result.Fail("limit é negativo")); */

    /*     var respose = _repo.GetAgendamentosByDate(minDate, maxDate, limit, page); */
    /*     if (respose.IsFailed) */
    /*         return Result.Fail("Não foi possivel pegar o agendamento"); */

    /*     return respose; */
    /* } */
    /* public async Task<Result<List<RetornoAgendamento>>> GetAgendamentosByMedico( */
    /*     Guid medicoId, int limit, int page = 0) */
    /* { */
    /*     var results = new List<Result<List<RetornoAgendamento>>>(); */
    /*     if (page < 0) */
    /*         results.Add(Result.Fail("page é negativo")); */

    /*     if (limit < 0) */
    /*         results.Add(Result.Fail("limit é negativo")); */

    /*     var respose = await _repo.GetAgendamentosByMedico(medicoId, limit, page); */
    /*     if (respose.IsFailed) */
    /*         return Result.Fail("Não foi possivel pegar os Agendamentos"); */

    /*     return respose; */

    /* } */
    /* public Result<List<RetornoAgendamento>> GetAgendamentosByPaciente( */
    /*     Guid pacienteId, int limit, int page = 0) */
    /* { */
    /*     var results = new List<Result<List<RetornoAgendamento>>>(); */
    /*     if (page < 0) */
    /*         results.Add(Result.Fail("page é negativo")); */

    /*     if (limit < 0) */
    /*         results.Add(Result.Fail("limit é negativo")); */

    /*     var respose = _repo.GetAgendamentosByPaciente(pacienteId, limit, page); */
    /*     if (respose.IsFailed) */
    /*         return Result.Fail("Não foi possivel pegar os Agendamentos"); */

    /*     return respose; */
    /* } */
    /* public async Task<Result> UpdateAgendamento( */
    /*     AgendamentoUpdateDto novo, Guid id) */
    /* { */
    /*     // TODO: Validar data e hora */
    /*     var respose = await GetAgendamentoById(id); */
    /*     if (respose.IsFailed) */
    /*         return Result.Fail("Não foi possivel encontrar o agendamento"); */

    /*     var agendamento = respose.Value; */
    /*     agendamento?.Update(novo); */

    /*     var updateResponse = await _repo.UpdateAgentamento(agendamento); */
    /*     if (updateResponse.IsFailed) */
    /*         return Result.Fail("Não foi possivel atualizar o agendamento"); */

    /*     return Result.Ok(); */

    /* } */
    /* public async Task<Result<List<RetornoAgendamento>>> GetAgendamentosByQuery( */
    /*     AgendamentoGetByQueryDto query) */
    /* { */
    /*     // TODO: Adiconar pesquisar por criação */
    /*     var results = new List<Result<List<Retorno>>>(); */
    /*     if (query.Page < 0) */
    /*         results.Add(Result.Fail("page é negativo")); */

    /*     if (query.Limit < 0) */
    /*         results.Add(Result.Fail("limit é negativo")); */

    /*     if (query.Limit == null) */
    /*         query.Limit = 10; */

    /*     if (query.Page == null) */
    /*         query.Page = 0; */

    /*     var respose = await _repo.GetAgendamentoByQuery(query); */
    /*     if (respose.IsFailed) */
    /*         return Result.Fail("não foi possivel pegar a atividade"); */

    /*     return respose; */
    /* } */
    /* public async Task<Result> EmAndamentoAgendamento(Guid id) */
    /* { */
    /*     var resAgendamendo = await GetAgendamentoById(id); */
    /*     if (resAgendamendo.IsFailed) */
    /*         return Result.Fail("Não foi possivel linkar o agendamento"); */

    /*     var agendamento = resAgendamendo.Value; */
    /*     agendamento.EmAndamento(); */

    /*     var response = await _repo.UpdateAgentamento(agendamento); */
    /*     if (response.IsFailed) */
    /*         return Result.Fail("Falha a dar update no agendamento"); */

    /*     return Result.Ok(); */
    /* } */

    /* public async Task<Result> EmEsperaAgendamento(Guid id) */
    /* { */
    /*     var resAgendamendo = await GetAgendamentoById(id); */
    /*     if (resAgendamendo.IsFailed) */
    /*         return Result.Fail("Não foi possivel linkar o agendamento"); */

    /*     var agendamento = resAgendamendo.Value; */
    /*     agendamento.EmEspera(); */

    /*     var response = await _repo.UpdateAgentamento(agendamento); */
    /*     if (response.IsFailed) */
    /*         return Result.Fail("Falha a dar update no agendamento"); */

    /*     return Result.Ok(); */
    /*     throw new NotImplementedException(); */
    /* } */
}
