using FluentResults;

using Hospital.Database;
using Hospital.Dto.Agendamento.Create;
using Hospital.Dto.Agendamento.Get;
using Hospital.Dto.Agendamento.Update;
using Hospital.Dto.Atendimento.Create;
using Hospital.Logs.Agendamentos.Success;
using Hospital.Models.Agendamentos;
using Hospital.Models.Atendimento;
using Hospital.Repository.Agendamentos.Interfaces;
using Hospital.Repository.Cadastros.Interfaces;
using Hospital.Repository.Convenios.Ineterfaces;
using Hospital.Service.Agendamentos.Interfaces;

namespace Hospital.Service.Agendamentos;
public class AgendamentoService<T, TAgendamento, TCreation>
: IAgendamentoService<T, TAgendamento, TCreation>
    where T : Atendimento, new()
    where TAgendamento : Agendamento<T>, new()
    where TCreation : AtendimentoCreationDto
{
    private readonly ILogger<AgendamentoService<T, TAgendamento, TCreation>> _logger;
    private readonly IAgendamentoRepository<T, TAgendamento> _repo;
    private readonly IMedicoRepository _medicoRepo;
    private readonly IPacienteRepository _pacienteRepo;
    private readonly IConvenioRepository _convenioRepo;
    private readonly AppDbContext _ctx;

    public AgendamentoService(
        IPacienteRepository paciente,
        IMedicoRepository medico,
        IConvenioRepository convenio,
        IAgendamentoRepository<T, TAgendamento> repository,
        AppDbContext context,
        ILogger<AgendamentoService<T, TAgendamento, TCreation>> logger)
    {
        _pacienteRepo = paciente;
        _medicoRepo = medico;
        _convenioRepo = convenio;
        _ctx = context;
        _repo = repository;
        _logger = logger;
        _logger.LogDebug(1, $"NLog injected into AgendamentoService {typeof(T).Name}");
    }

    public async Task<Result> CancelAgendamento(Guid id)
    {
        _logger.LogInformation($"Cancelando agendamento {id} - {typeof(T).Name}");
        var resAgendamendo = await GetAgendamentoById(id);
        if (resAgendamendo.IsFailed)
        {
            _logger.LogError($"Agendamento {id} não encontrado - {typeof(T).Name}");
            return Result.Fail($"Não foi possivel linkar o agendamento - {typeof(T).Name}");
        }

        var agendamento = resAgendamendo.Value;
        agendamento.Cancelar();

        var response = await _repo.UpdateAgentamento(agendamento);
        if (response.IsFailed)
        {
            _logger.LogError($"Falha a dar update no agendamento {id} - {typeof(T).Name}");
            return Result.Fail($"Falha a dar update no agendamento - {typeof(T).Name}");
        }

        _logger.LogInformation($"Agendamento {id} cancelado - {typeof(T).Name}");
        return Result.Ok();
    }
    public async Task<Result> CreateAgendamento(
        AgendamentoCreateDto request)
    {
        _logger.LogInformation($"Criando agendamento - {typeof(T).Name}");
        var results = new List<Result>();
        var medico = _medicoRepo.GetMedicoById(request.MedicoId);
        var paciente = _pacienteRepo.GetPacienteById(request.PacienteId);
        var convenio = _convenioRepo.GetConvenioById((Guid)request.ConvenioId);

        if (request.DataHora < DateTime.Now)
        {
            _logger.LogError($"Data e hora inválida da requisição de agendamento - {typeof(T).Name}");
            results.Add(Result.Fail("Data e hora inválida"));
        }
        if (medico.Value == null)
        {
            _logger.LogError($"Medico não existe da requisição de agendamento - {typeof(T).Name}");
            results.Add(Result.Fail("Medico não existe"));
        }
        if (paciente.Value == null)
        {
            _logger.LogError($"Paciente não existe da requisição de agendamento - {typeof(T).Name}");
            results.Add(Result.Fail("Paciente não existe"));
        }

        var mergedResult = results.Merge();

        if (mergedResult.IsFailed || convenio.IsFailed)
        {
            _logger.LogError($"Falha na requisição de agendamento - {typeof(T).Name}");
            return mergedResult;
        }

        var CustoFinal = request.Custo;
        if (convenio.Value != null)
            CustoFinal -= request.Custo * convenio.Value.Desconto;

        TAgendamento agendamento = new()
        {
            Paciente = paciente.Value,
            Medico = medico.Value,
            DataHora = request.DataHora,
            Criação = DateTime.Now,
            Tipo = default,
            TipoId = default,
            Status = AgendamentoStatus.Agendado,
            Custo = request.Custo,
            Convenio = convenio.Value,
            CustoFinal = CustoFinal,
            Deletado = false
        };

        var respose = await _repo.CreateAgentamento(agendamento);
        if (respose.IsFailed)
        {
            _logger.LogError($"Não foi possivel criar o agendamento - {typeof(T).Name}");
            return Result.Fail("Não foi possivel criar o agendamento");
        }

        var id = respose.Value.Entity.Id;
        _logger.LogInformation($"Agendamento criado: {id} - {typeof(T).Name}");
        return Result.Ok();
    }
    public async Task<Result> LinkAtendimento(
        T entity, Guid id)
    {
        _logger.LogInformation($"Linkando atendimento ao agendamento {id} - {typeof(T).Name}");
        var resAgendamendo = await GetAgendamentoById(id);
        if (resAgendamendo.IsFailed)
        {
            _logger.LogError($"Não foi possivel achar o agendamento {id} - {typeof(T).Name}");
            return Result.Fail("Não foi possivel linkar o agendamento");
        }

        var agendamento = resAgendamendo.Value;
        agendamento.Link(entity);
        agendamento.Realizar();

        var response = await _repo.UpdateAgentamento(agendamento);
        if (response.IsFailed)
        {
            _logger.LogError($"Falha a dar update no agendamento {id} - {typeof(T).Name}");
            return Result.Fail("Falha a dar update no agendamento");
        }

        _logger.LogInformation($"Atendimento linkado ao agendamento {id} - {typeof(T).Name}");
        return Result.Ok();
    }
    public async Task<Result<TAgendamento?>> GetAgendamentoById(
        Guid id)
    {
        _logger.LogInformation($"Pegando agendamento {id} - {typeof(T).Name}");
        var respose = await _repo.GetAgendamentoById(id);
        if (respose.IsFailed)
        {
            _logger.LogError($"Não foi possivel achar o agendamento {id} - {typeof(T).Name}");
            return Result.Fail("Não foi possivel achar o agendamento");
        }

        _logger.LogInformation($"Agendamento {id} encontrado - {typeof(T).Name}");
        return respose;
    }
    public Result<List<TAgendamento>> GetAgendamentosByDate(
        DateTime minDate, DateTime maxDate, int limit, int page = 0)
    {
        _logger.LogInformation($"Pegando agendamentos por data - {typeof(T).Name}");
        var results = new List<Result<List<TAgendamento>>>();
        if (page < 0)
            results.Add(Result.Fail("page é negativo"));

        if (limit < 0)
            results.Add(Result.Fail("limit é negativo"));

        var respose = _repo.GetAgendamentosByDate(minDate, maxDate, limit, page);
        if (respose.IsFailed)
        {
            _logger.LogError($"Não foi possivel pegar os agendamentos - {typeof(T).Name}");
            return Result.Fail("Não foi possivel pegar o agendamento");
        }

        _logger.LogInformation($"Agendamentos por data encontrado: {respose.Value.Count} - {typeof(T).Name}");
        return respose;
    }
    public async Task<Result<List<TAgendamento>>> GetAgendamentosByMedico(
        Guid medicoId, int limit, int page = 0)
    {
        _logger.LogInformation($"Pegando agendamentos por medico - {typeof(T).Name}");
        var results = new List<Result<List<TAgendamento>>>();
        if (page < 0)
            results.Add(Result.Fail("page é negativo"));

        if (limit < 0)
            results.Add(Result.Fail("limit é negativo"));

        var respose = await _repo.GetAgendamentosByMedico(medicoId, limit, page);
        if (respose.IsFailed)
        {
            _logger.LogError($"Não foi possivel pegar os agendamentos - {typeof(T).Name}");
            return Result.Fail("Não foi possivel pegar os Agendamentos");
        }

        _logger.LogInformation($"Agendamentos por medico encontrado: {respose.Value.Count} - {typeof(T).Name}");
        return respose;
    }
    public Result<List<TAgendamento>> GetAgendamentosByPaciente(
        Guid pacienteId, int limit, int page = 0)
    {
        _logger.LogInformation($"Pegando agendamentos por paciente - {typeof(T).Name}");
        var results = new List<Result<List<TAgendamento>>>();
        if (page < 0)
            results.Add(Result.Fail("page é negativo"));

        if (limit < 0)
            results.Add(Result.Fail("limit é negativo"));

        var respose = _repo.GetAgendamentosByPaciente(pacienteId, limit, page);
        if (respose.IsFailed)
        {
            _logger.LogError($"Não foi possivel pegar os agendamentos - {typeof(T).Name}");
            return Result.Fail("Não foi possivel pegar os Agendamentos");
        }

        _logger.LogInformation($"Agendamentos por paciente encontrado: {respose.Value.Count} - {typeof(T).Name}");
        return respose;
    }
    public async Task<Result> UpdateAgendamento(
        AgendamentoUpdateDto novo, Guid id)
    {
        _logger.LogInformation($"Atualizando agendamento {id} - {typeof(T).Name}");
        // TODO: Validar data e hora
        var respose = await GetAgendamentoById(id);
        if (respose.IsFailed)
        {
            _logger.LogError($"Não foi possivel encontrar o agendamento {id} - {typeof(T).Name}");
            return Result.Fail("Não foi possivel encontrar o agendamento");
        }

        var agendamento = respose.Value;
        agendamento?.Update(novo);

        var updateResponse = await _repo.UpdateAgentamento(agendamento);
        if (updateResponse.IsFailed)
        {
            _logger.LogError($"Não foi possivel atualizar o agendamento {id} - {typeof(T).Name}");
            return Result.Fail("Não foi possivel atualizar o agendamento");
        }

        _logger.LogInformation($"Agendamento {id} atualizado - {typeof(T).Name}");
        return Result.Ok();

    }
    public async Task<Result<List<TAgendamento>>> GetAgendamentosByQuery(
        AgendamentoGetByQueryDto query)
    {
        _logger.LogInformation($"Pegando agendamentos por query: {query.Serialize()} - {typeof(T).Name}");
        // TODO: Adiconar pesquisar por criação
        var results = new List<Result<List<T>>>();
        if (query.Page < 0)
            results.Add(Result.Fail("page é negativo"));

        if (query.Limit < 0)
            results.Add(Result.Fail("limit é negativo"));

        if (query.Limit == null)
            query.Limit = 10;

        if (query.Page == null)
            query.Page = 0;

        var respose = await _repo.GetAgendamentoByQuery(query);
        if (respose.IsFailed)
        {
            _logger.LogError($"Não foi possivel pegar os agendamentos: {query} - {typeof(T).Name}");
            return Result.Fail("não foi possivel pegar a atividade");
        }

        var successCode = AgendamentoServiceEnumSucess.SAGDS010;
        var successInfo = $"{respose.Value.Count} - {query.Serialize()}";
        _logger.LogInformation(AgendamentoServiceServiceSuccess
            .ConstructSuccess(successCode, typeof(T).Name, successInfo));
        return respose;
    }

    public async Task<Result> EmAndamentoAgendamento(Guid id)
    {
        _logger.LogInformation($"Agendamento em andamento {id} - {typeof(T).Name}");
        var resAgendamendo = await GetAgendamentoById(id);
        if (resAgendamendo.IsFailed)
        {
            _logger.LogError($"Não foi possivel linkar o agendamento {id} - {typeof(T).Name}");
            return Result.Fail("Não foi possivel linkar o agendamento");
        }

        var agendamento = resAgendamendo.Value;
        agendamento.EmAndamento();

        var response = await _repo.UpdateAgentamento(agendamento);
        if (response.IsFailed)
        {
            _logger.LogError($"Falha a dar update no agendamento {id} - {typeof(T).Name}");
            return Result.Fail("Falha a dar update no agendamento");
        }

        _logger.LogInformation($"Agendamento em andamento {id} - {typeof(T).Name}");
        return Result.Ok();
    }

    public async Task<Result> EmEsperaAgendamento(Guid id)
    {
        _logger.LogInformation($"Agendamento em espera {id} - {typeof(T).Name}");
        var resAgendamendo = await GetAgendamentoById(id);
        if (resAgendamendo.IsFailed)
            return Result.Fail("Não foi possivel linkar o agendamento");

        var agendamento = resAgendamendo.Value;
        agendamento.EmEspera();

        var response = await _repo.UpdateAgentamento(agendamento);
        if (response.IsFailed)
        {
            _logger.LogError($"Falha a dar update no agendamento {id} - {typeof(T).Name}");
            return Result.Fail("Falha a dar update no agendamento");
        }

        _logger.LogInformation($"Agendamento em espera {id} - {typeof(T).Name}");
        return Result.Ok();
    }
}