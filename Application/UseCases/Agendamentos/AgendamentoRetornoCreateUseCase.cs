using Hospital.Application.Dto.Input.Agendamentos;
using Hospital.Domain.Entities;
using Hospital.Domain.Entities.Agendamentos;
using Hospital.Domain.Exceptions;
using Hospital.Domain.Repositories;
using Hospital.Domain.Repositories.Agendamentos;
using Hospital.Domain.Repositories.Atendimentos;
using Hospital.Domain.Repositories.Cadastros;

namespace Hospital.Application.UseCases.Agendamentos;
public class AgendamentoRetornoCreateUseCase
{
    private readonly IConsultaRepository _consultaRepository;
    private readonly IRetornoAgendamentoRepository _retornoRepository;
    private readonly IMedicoRepository _medicoRepository;
    private readonly IPacienteRepository _pacienteRepository;
    private readonly IConvenioRepository _convenioRepository;
    private readonly IUnitOfWork _uow;

    public AgendamentoRetornoCreateUseCase(
        IConsultaRepository consultaRepository,
        IRetornoAgendamentoRepository retornoRepository,
        IMedicoRepository medicoRepository,
        IPacienteRepository pacienteRepository,
        IConvenioRepository convenioRepository,
        IUnitOfWork uow)
    {
        _consultaRepository = consultaRepository;
        _retornoRepository = retornoRepository;
        _medicoRepository = medicoRepository;
        _pacienteRepository = pacienteRepository;
        _convenioRepository = convenioRepository;
        _uow = uow;
    }

    public async Task<Guid> Handler(AgendamentoRetornoCreateDto request)
    {
        var retorno = new RetornoAgendamento().Create(request);

        var findConsulta = await _consultaRepository
            .GetByIdAsync(request.ConsultaId);
        if (findConsulta == null)
            throw new DomainException(
                $"Consulta não encontrada: {request.ConsultaId}",
                "Consulta não encontrada");

        var findMedico = await _medicoRepository
            .GetByIdAtivoAsync(request.MedicoId);
        if (findMedico == null)
            throw new DomainException(
                $"Médico não encontrado: {request.MedicoId}",
                "Médico não encontrado");

        var findPaciente = _pacienteRepository
            .GetByIdAtivoAsync(request.PacienteId);
        if (findPaciente == null)
            throw new DomainException(
                $"Paciente não encontrado: {request.PacienteId}",
                "Paciente não encontrado");

        var findAgendamento = await _retornoRepository
            .GetByDataHoraMedicoAsync(request.DataHora, request.MedicoId);
        if (findAgendamento != null)
            throw new DomainException(
                $"Agendamento já existe: {request.DataHora}",
                "Agendamento já existe");

        Convenio? findConvenio = null;
        if (request.ConvenioId != null)
        {
            findConvenio = await _convenioRepository
                .GetByIdAtivoAsync(request.ConvenioId.Value);
            if (findConvenio == null)
                throw new DomainException(
                    $"Convênio não encontrado: {request.ConvenioId}",
                    "Convênio não encontrado");
        }

        retorno.GratuidadeRetorno(findConsulta.Fim, findConvenio);

        var id = await _retornoRepository.CreateAsync(retorno);
        await _uow.SaveAsync();

        return id;
    }
}