using Hospital.Dtos.Input.Agendamentos;
using Hospital.Exceptions;
using Hospital.Models.Agendamentos;
using Hospital.Models.Cadastro;
using Hospital.Repository.Atendimentos.Interfaces;
using Hospital.Repository.Cadastros.Interfaces;
using Hospital.Repository.Convenios.Ineterfaces;

namespace Hospital.Services.Agendamentos;
public class AgendamentoRetornoCreateService
{
    private readonly IConsultaRepository _consultaRepository;
    private readonly IRetornoAgendamentoRepository _retornoRepository;
    private readonly IMedicoRepository _medicoRepository;
    private readonly IPacienteRepository _pacienteRepository;
    private readonly IConvenioRepository _convenioRepository;

    public AgendamentoRetornoCreateService(
        IConsultaRepository consultaRepository,
        IRetornoAgendamentoRepository retornoRepository,
        IMedicoRepository medicoRepository,
        IPacienteRepository pacienteRepository,
        IConvenioRepository convenioRepository)
    {
        _consultaRepository = consultaRepository;
        _retornoRepository = retornoRepository;
        _medicoRepository = medicoRepository;
        _pacienteRepository = pacienteRepository;
        _convenioRepository = convenioRepository;
    }

    public async Task<string> Handler(AgendamentoRetornoCreateDto request)
    {
        var retorno = new RetornoAgendamento().Create(request);

        var findConsulta = await _consultaRepository
            .GetByIdAsync(request.ConsultaId);
        if (findConsulta == null)
            throw new RequestError(
                $"Consulta não encontrada: {request.ConsultaId}",
                "Consulta não encontrada");

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

        var findAgendamento = await _retornoRepository
            .GetByDataHoraMedicoAsync(request.DataHora, request.MedicoId);
        if (findAgendamento != null)
            throw new RequestError(
                $"Agendamento já existe: {request.DataHora}",
                "Agendamento já existe");

        Convenio? findConvenio = null;
        var Custofinal = request.Custo;
        if (request.ConvenioId != null)
        {
            findConvenio = _convenioRepository
                .GetConvenioByIdAtivo(request.ConvenioId.Value);
            if (findConvenio == null)
                throw new RequestError(
                    $"Convênio não encontrado: {request.ConvenioId}",
                    "Convênio não encontrado");

            if (findConsulta.Fim.AddDays(30) < DateTime.Now)
                Custofinal = request.Custo;
            else
                Custofinal = 0;
        }

        retorno.CustoFinal = Custofinal;

        var id = await _retornoRepository.CreateAsync(retorno);

        return $"/api/Agendamento/Retorno/{id}";
    }
}