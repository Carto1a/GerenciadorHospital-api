using Hospital.Dtos.Input.Agendamentos;
using Hospital.Exceptions;
using Hospital.Infrastructure.Database.Repositories;
using Hospital.Models.Agendamentos;
using Hospital.Models.Cadastro;
using Hospital.Repository.Atendimentos.Interfaces;
using Hospital.Repository.Cadastros.Interfaces;
using Hospital.Repository.Convenios.Ineterfaces;

namespace Hospital.Services.Agendamentos;
public class AgendamentoExameCreateService
{
    private ILogger<AgendamentoConsultaCreateService> _logger;
    private readonly UnitOfWork _uow;
    private readonly IMedicoRepository _medicoRepository;
    private readonly IPacienteRepository _pacienteRepository;
    private readonly IConvenioRepository _convenioRepository;
    private readonly IExameAgendamentoRepository _exameAgendamentoRepository;
    private readonly IConsultaRepository _consultaRepository;
    public AgendamentoExameCreateService(
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
        var CustoFinal = request.Custo;

        if (request.ConvenioId != null)
        {
            findConvenio = _convenioRepository
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