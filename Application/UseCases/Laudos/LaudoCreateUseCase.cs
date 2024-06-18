using Hospital.Application.Dto.Input.Laudos;
using Hospital.Application.Services;
using Hospital.Domain.Entities;
using Hospital.Domain.Exceptions;
using Hospital.Domain.Repositories;
using Hospital.Domain.Repositories.Atendimentos;
using Hospital.Domain.Repositories.Cadastros;

namespace Hospital.Application.UseCases.Laudos;
public class LaudoCreateUseCase
{
    private readonly IUnitOfWork _uow;
    private readonly IExameRepository _exameRepository;
    private readonly IConsultaRepository _consultaRepository;
    private readonly ILaudoRepository _laudoRepository;
    private readonly IPacienteRepository _pacienteRepository;
    private readonly IMedicoRepository _medicoRepository;
    private readonly IImageService _imageService;
    public LaudoCreateUseCase(
        IUnitOfWork uow,
        IExameRepository exameRepository,
        IConsultaRepository consultaRepository,
        ILaudoRepository laudoRepository,
        IPacienteRepository pacienteRepository,
        IMedicoRepository medicoRepository,
        IImageService imageService)
    {
        _uow = uow;
        _exameRepository = exameRepository;
        _consultaRepository = consultaRepository;
        _laudoRepository = laudoRepository;
        _pacienteRepository = pacienteRepository;
        _medicoRepository = medicoRepository;
        _imageService = imageService;
    }

    public async Task<Guid> Handler(LaudoCreateDto request)
    {
        var laudo = new Laudo(request);

        var findPaciente = await _pacienteRepository
            .GetByIdAsync(request.PacienteId);
        if (findPaciente == null)
            throw new DomainException(
                $"Paciente não encontrado: {request.PacienteId}",
                "Paciente não encontrado");

        var findMedico = await _medicoRepository
            .GetByIdAsync(request.MedicoId);
        if (findMedico == null)
            throw new DomainException(
                $"Médico não encontrado: {request.MedicoId}",
                "Médico não encontrado");

        var findExames = await _exameRepository
            .GetExamesByIdsAsync(request.ExameIds);
        if (request.ExameIds.Count() != findExames.Count)
        {
            var examesNotFound = request.ExameIds
                .Except(findExames.Select(e => e.Id));
            throw new DomainException(
                $"Exames não encontrados: {string.Join(", ", examesNotFound)}",
                "Exames não encontrados");
        }

        laudo.Exames = findExames;

        var findConsulta = await _consultaRepository
            .GetByIdAsync(request.ConsultaId);
        if (findConsulta == null)
            throw new DomainException(
                $"Consulta não encontrada: {request.ConsultaId}",
                "Consulta não encontrada");

        if (request.DocImg != null)
            laudo.DocPath = _imageService
                .SaveLaudoImage(request.DocImg);

        var id = await _laudoRepository.CreateAsync(laudo);
        await _uow.SaveAsync();

        return id;
    }
}