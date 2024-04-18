using FluentResults;
using Hospital.Database;
using Hospital.Dto.Agendamento.Create;
using Hospital.Dto.Agendamento.Get;
using Hospital.Dto.Agendamento.Update;
using Hospital.Models.Agendamentos;
using Hospital.Models.Atendimento;
using Hospital.Repository.Atendimentos.Interfaces;
using Hospital.Repository.Cadastros.Interfaces;
using Hospital.Service.Agendamentos.Interfaces;

namespace Hospital.Service.Agendamentos;
public class ExameAgendamentoService
: IExameAgendamentoService
{
    private readonly IExameAgendamentoRepository _repo;
    private readonly IMedicoRepository _medicoRepo;
    private readonly IPacienteRepository _pacienteRepo;
    private readonly AppDbContext _ctx;
    public ExameAgendamentoService(
        IPacienteRepository paciente,
        IMedicoRepository medico,
        IExameAgendamentoRepository repository,
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
    public async Task<Result> CreateAgendamento(
        AgendamentoCreateDto request)
    {
        var results = new List<Result>();
        var medico = _medicoRepo.GetMedicoById(request.MedicoId);
        var paciente = _pacienteRepo.GetPacienteById(request.PacienteId);

        results.Add(medico == null ? Result.Fail("Medico não existe") : Result.Ok());
        results.Add(paciente == null ? Result.Fail("Paciente não existe") : Result.Ok());

        var mergedResult = results.Merge();

        if (mergedResult.IsFailed)
            return mergedResult;

        ExameAgendamento agendamento = new()
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
    public async Task<Result> LinkAtendimento(Exame entity, int id)
    {
        var resAgendamendo = await GetAgendamentoById(id);
        if (resAgendamendo.IsFailed)
            return Result.Fail("Não foi possivel linkar o agendamento");

        var agendamento = resAgendamendo.Value;
        agendamento.Link(entity);

        var response = await _repo.UpdateAgentamento(agendamento);
        if (response.IsFailed)
            return Result.Fail("Falha a dar update no agendamento");

        return Result.Ok();
    }
    public async Task<Result<ExameAgendamento?>> GetAgendamentoById(int id)
    {
        var respose = await _repo.GetAgendamentoById(id);
        if (respose.IsFailed)
            return Result.Fail("Não foi possivel achar o agendamento");

        return respose;
    }
    public Result<List<ExameAgendamento>> GetAgendamentosByDate(
        DateTime minDate, DateTime maxDate, int limit, int page = 0)
    {
        var results = new List<Result<List<ExameAgendamento>>>();
        if (page < 0)
            results.Add(Result.Fail("page é negativo"));

        if (limit < 0)
            results.Add(Result.Fail("limit é negativo"));

        var respose = _repo.GetAgendamentosByDate(minDate, maxDate, limit, page);
        if (respose.IsFailed)
            return Result.Fail("Não foi possivel pegar o agendamento");

        return respose;
    }
    public Result<List<ExameAgendamento>> GetAgendamentosByMedico(
        string medicoId, int limit, int page = 0)
    {
        var results = new List<Result<List<ExameAgendamento>>>();
        if (page < 0)
            results.Add(Result.Fail("page é negativo"));

        if (limit < 0)
            results.Add(Result.Fail("limit é negativo"));

        var respose = _repo.GetAgendamentosByMedico(medicoId, limit, page);
        if (respose.IsFailed)
            return Result.Fail("Não foi possivel pegar os Agendamentos");

        return respose;

    }
    public Result<List<ExameAgendamento>> GetAgendamentosByPaciente(
        string pacienteId, int limit, int page = 0)
    {
        var results = new List<Result<List<ExameAgendamento>>>();
        if (page < 0)
            results.Add(Result.Fail("page é negativo"));

        if (limit < 0)
            results.Add(Result.Fail("limit é negativo"));

        var respose = _repo.GetAgendamentosByPaciente(pacienteId, limit, page);
        if (respose.IsFailed)
            return Result.Fail("Não foi possivel pegar os Agendamentos");

        return respose;
    }
    public async Task<Result> UpdateAgendamento(
        AgendamentoUpdateDto novo, int id)
    {
        // TODO: Validar data e hora
        var respose = await GetAgendamentoById(id);
        if (respose.IsFailed)
            return Result.Fail("Não foi possivel encontrar o agendamento");

        var agendamento = respose.Value;
        agendamento?.Update(novo);

        var updateResponse = await _repo.UpdateAgentamento(agendamento);
        if (updateResponse.IsFailed)
            return Result.Fail("Não foi possivel atualizar o agendamento");

        return Result.Ok();

    }
    public Result<List<ExameAgendamento>> GetAgendamentosByQuery(AgendamentoGetByQueryDto query)
    {
        // TODO: Adiconar pesquisar por criação
        var results = new List<Result<List<Exame>>>();
        if (query.Page < 0)
            results.Add(Result.Fail("page é negativo"));

        if (query.Limit < 0)
            results.Add(Result.Fail("limit é negativo"));

        if (query.Limit == null)
            query.Limit = 10;

        if (query.Page == null)
            query.Page = 0;

        var respose = _repo.GetAgendamentoByQuery(query);
        if (respose.IsFailed)
            return Result.Fail("não foi possivel pegar a atividade");

        return respose;
    }
}
