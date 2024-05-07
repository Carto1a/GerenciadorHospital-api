using Hospital.Dtos.Input.Agendamentos;
using Hospital.Exceptions;
using Hospital.Models.Agendamentos;
using Hospital.Models.Cadastro;
using Hospital.Repository;

namespace Hospital.Services.Agendamentos.Exames;
public class ExameAgendamentoCreateService
{
    private ILogger<ExameAgendamentoCreateService> _logger;
    private readonly UnitOfWork _uow;
    public ExameAgendamentoCreateService(
        ILogger<ExameAgendamentoCreateService> logger,
        UnitOfWork uow)
    {
        _logger = logger;
        _uow = uow;
    }

    public async Task<Guid> Handler(
        ExameAgendamentoCreateDto request)
    {
        _logger.LogInformation($"Criando agendamento de consulta: {request.DataHora}");
        // NOTE: não confiar nesse codigo
        var agendamento = new ExameAgendamento(request);

        var repo = _uow.ExameAgendamentoRepository;
        var findConsulta = await _uow.ConsultaRepository
            .GetByIdAsync(request.ConsultaId);
        if (findConsulta == null)
            throw new RequestError(
                $"Consulta não encontrada: {request.ConsultaId}",
                "Consulta não encontrada");

        var findMedico = _uow.MedicoRepository
            .GetMedicoByIdAtivo(request.MedicoId);
        if (findMedico == null)
            throw new RequestError(
                $"Médico não encontrado: {request.MedicoId}",
                "Médico não encontrado");

        var findPaciente = _uow.PacienteRepository
            .GetPacienteByIdAtivo((Guid)findConsulta.PacienteId!);
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
        agendamento.PacienteId = findPaciente.Id;

        var entity = await repo.CreateAsync(agendamento);

        _logger.LogInformation($"Agendamento criado: {request.DataHora}");
        return entity;
    }
}