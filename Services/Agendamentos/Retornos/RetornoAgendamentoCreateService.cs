using Hospital.Dtos.Input.Agendamentos;
using Hospital.Exceptions;
using Hospital.Models.Agendamentos;
using Hospital.Models.Cadastro;
using Hospital.Repository;

namespace Hospital.Services.Agendamentos.Retornos;
public class RetornoAgendamentoCreateService
{
    private ILogger<RetornoAgendamentoCreateService> _logger;
    private readonly UnitOfWork _uow;
    public RetornoAgendamentoCreateService(
        ILogger<RetornoAgendamentoCreateService> logger,
        UnitOfWork uow)
    {
        _logger = logger;
        _uow = uow;
    }

    public async Task<string> Handler(
        RetornoAgendamentoCreateDto request)
    {
        _logger.LogInformation($"Criando agendamento de consulta: {request.DataHora}");
        // NOTE: não confiar nesse codigo
        var agendamento = new RetornoAgendamento(request);

        var repo = _uow.RetornoAgendamentoRepository;
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

        var findConsulta = await _uow.ConsultaAgendamentoRepository
            .GetByIdAsync(request.ConsultaId);
        if (findConsulta == null)
            throw new RequestError(
                $"Consulta não encontrada: {request.ConsultaId}",
                "Consulta não encontrada");

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
        return $"/api/agendamentos/Consultas/{entity}";
    }
}