using Hospital.Application.Dto.Input.Agendamentos;
using Hospital.Services.Agendamentos;

namespace Hospital.Application.UseCases.Agendamentos;
public class AgendamentoExameCreateUseCase
{
    private ILogger<AgendamentoConsultaCreateService> _logger;
    private readonly UnitOfWork _uow;
    private readonly IMedicoRepository _medicoRepository;
    private readonly IPacienteRepository _pacienteRepository;
    private readonly IConvenioRepository _convenioRepository;
    private readonly IExameAgendamentoRepository _exameAgendamentoRepository;
    private readonly IConsultaRepository _consultaRepository;
    public AgendamentoExameCreateUseCase(
        ILogger<AgendamentoConsultaCreateService> logger,
        UnitOfWork uow,
        IMedicoRepository medicoRepository,
        IPacienteRepository pacienteRepository,
        IConvenioRepository convenioRepository,
        IExameAgendamentoRepository exameAgendamentoRepository,
        IConsultaRepository consultaRepository)
    {
        _logger = logger;
        _uow = uow;
        _medicoRepository = medicoRepository;
        _pacienteRepository = pacienteRepository;
        _convenioRepository = convenioRepository;
        _exameAgendamentoRepository = exameAgendamentoRepository;
        _consultaRepository = consultaRepository;
    }

    public async Task<string> Handler(
        AgendamentoExameCreateDto request)
    {
        _logger.LogInformation($"Criando agendamento: {request.DataHora}");

        // NOTE: não confiar nesse codigo
        var agendamento = (ExameAgendamento)new ExameAgendamento().Create(request);

        var consulta = await _consultaRepository.GetByIdAsync(request.ConsultaId);
        if (consulta == null)
            throw new RequestError(
                $"Consulta não encontrada: {request.ConsultaId}",
                "Consulta não encontrada");

        var repo = _exameAgendamentoRepository;
        var findMedico = _medicoRepository
            .GetMedicoByIdAtivo(request.MedicoId);
        if (findMedico == null)
            throw new RequestError(
                $"Médico não encontrado: {request.MedicoId}",
                "Médico não encontrado");

        var findPaciente = _pacienteRepository
            .GetPacienteByIdAtivo(request.PacienteId);
        if (findPaciente == null)
            throw new RequestError(
                $"Paciente não encontrado: {request.PacienteId}",
                "Paciente não encontrado");

        // TODO: pegar em todos os tipos de agendamento
        var findAgendamentos = await repo
            .GetByDataHoraMedicoAsync(request.DataHora, request.MedicoId);
        if (findAgendamentos.Count > 0)
            throw new RequestError(
                $"Horario ocupado para agendamento: {request.DataHora}",
                "Horario ocupado para agendamento");

        Convenio? findConvenio = null;
        if (request.ConvenioId != null)
        {
            findConvenio = _convenioRepository
                .GetConvenioByIdAtivo((Guid)request.ConvenioId);
            if (findConvenio == null)
                throw new RequestError(
                    $"Convênio não encontrado: {request.ConvenioId}",
                    "Convênio não encontrado");
        }
        agendamento.CalcularDesconto(findConvenio);

        var entity = await repo.CreateAsync(agendamento);

        _logger.LogInformation($"Agendamento criado: {request.DataHora}");
        return $"/api/agendamentos/{entity}";
    }
}