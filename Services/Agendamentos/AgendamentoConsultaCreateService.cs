using Hospital.Dtos.Input.Agendamentos;
using Hospital.Exceptions;
using Hospital.Models.Agendamentos;
using Hospital.Models.Cadastro;
using Hospital.Repository;
using Hospital.Repository.Atendimentos.Interfaces;
using Hospital.Repository.Cadastros.Interfaces;
using Hospital.Repository.Convenios.Ineterfaces;

namespace Hospital.Services.Agendamentos;
public class AgendamentoConsultaCreateService
{
    private ILogger<AgendamentoConsultaCreateService> _logger;
    private readonly UnitOfWork _uow;
    private readonly IMedicoRepository _medicoRepository;
    private readonly IPacienteRepository _pacienteRepository;
    private readonly IConvenioRepository _convenioRepository;
    private readonly IConsultaAgendamentoRepository _consultaAgendamentoRepository;
    public AgendamentoConsultaCreateService(
        ILogger<AgendamentoConsultaCreateService> logger,
        UnitOfWork uow,
        IMedicoRepository medicoRepository,
        IPacienteRepository pacienteRepository,
        IConvenioRepository convenioRepository,
        IConsultaAgendamentoRepository consultaAgendamentoRepository)
    {
        _logger = logger;
        _uow = uow;
        _medicoRepository = medicoRepository;
        _pacienteRepository = pacienteRepository;
        _convenioRepository = convenioRepository;
        _consultaAgendamentoRepository = consultaAgendamentoRepository;
    }

    public async Task<string> Handler(
        AgendamentoCreateDto request)
    {
        _logger.LogInformation($"Criando agendamento: {request.DataHora}");
        // NOTE: não confiar nesse codigo
        var agendamento = (ConsultaAgendamento)
            new ConsultaAgendamento().Create(request);

        var repo = _consultaAgendamentoRepository;
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