using Hospital.Dtos.Input.Agendamentos;
using Hospital.Exceptions;
using Hospital.Models.Agendamentos;
using Hospital.Models.Atendimento;
using Hospital.Models.Cadastro;
using Hospital.Repository;

namespace Hospital.Services.Agendamentos;
public class AgendamentoCreateService<T, TAgendamento, TCreate>
where T : Atendimento, new()
where TAgendamento : Agendamento, new()
{
    private ILogger<AgendamentoCreateService<T, TAgendamento, TCreate>> _logger;
    private readonly UnitOfWork _uow;
    public AgendamentoCreateService(
        ILogger<AgendamentoCreateService<T, TAgendamento, TCreate>> logger,
        UnitOfWork uow)
    {
        _logger = logger;
        _uow = uow;
    }

    public async Task<string> Handler(
        AgendamentoCreateDto request)
    {
        _logger.LogInformation($"Criando agendamento: {request.DataHora}");
        // NOTE: não confiar nesse codigo
        var agendamento =
            (TAgendamento)new TAgendamento().Create(request);

        var repo = _uow.SetAgendamento<T, TAgendamento>()!;
        var findMedico = _uow.MedicoRepository
            .GetMedicoByIdAtivo(request.MedicoId);
        if (findMedico == null)
            throw new RequestError(
                $"Médico não encontrado: {request.MedicoId}",
                "Médico não encontrado");

        var findPaciente = _uow.PacienteRepository
            .GetPacienteByIdAtivo(request.PacienteId);
        if (findPaciente == null)
            throw new RequestError(
                $"Paciente não encontrado: {request.PacienteId}",
                "Paciente não encontrado");

        var findAgendamentos = await repo
            .GetByDataHoraMedicoAsync(request.DataHora, request.MedicoId);
        if (findAgendamentos.Count > 0)
            throw new RequestError(
                $"Horario ocupado para agendamento: {request.DataHora}",
                "Horario ocupado para agendamento");

        Convenio? findConvenio = null;
        var CustoFinal = request.Custo;

        if (request.ConvenioId != null)
        {
            findConvenio = _uow.ConvenioRepository
                .GetConvenioByIdAtivo((Guid)request.ConvenioId);
            if (findConvenio == null)
                throw new RequestError(
                    $"Convênio não encontrado: {request.ConvenioId}",
                    "Convênio não encontrado");
            CustoFinal -= request.Custo * findConvenio.Desconto;

        }
        agendamento.CustoFinal = CustoFinal;

        var entity = await repo.CreateAsync(agendamento);

        _logger.LogInformation($"Agendamento criado: {request.DataHora}");
        return $"/api/agendamentos/{entity}";
    }
}