using Hospital.Dtos.Input.Laudos;
using Hospital.Exceptions;
using Hospital.Models;
using Hospital.Repository;
using Hospital.Repository.Atendimentos.Interfaces;
using Hospital.Repository.Cadastros.Interfaces;
using Hospital.Repository.Images.Interfaces;

namespace Hospital.Services.Laudos;
public class LaudoCreateService
{
    private readonly UnitOfWork _uow;
    private readonly IExameRepository _exameRepository;
    private readonly IConsultaRepository _consultaRepository;
    private readonly ILaudoRepository _laudoRepository;
    private readonly IPacienteRepository _pacienteRepository;
    private readonly IMedicoRepository _medicoRepository;
    private readonly IImageRepository _imageRepository;
    public LaudoCreateService(
        UnitOfWork uow,
        IExameRepository exameRepository,
        IConsultaRepository consultaRepository,
        ILaudoRepository laudoRepository,
        IPacienteRepository pacienteRepository,
        IMedicoRepository medicoRepository,
        IImageRepository imageRepository)
    {
        _uow = uow;
        _exameRepository = exameRepository;
        _consultaRepository = consultaRepository;
        _laudoRepository = laudoRepository;
        _pacienteRepository = pacienteRepository;
        _medicoRepository = medicoRepository;
        _imageRepository = imageRepository;
    }

    public async Task<string> Handler(LaudoCreateDto request)
    {
        var laudo = new Laudo(request);

        var findPaciente = _pacienteRepository
            .GetPacienteById(request.PacienteId);
        if (findPaciente == null)
            throw new RequestError(
                $"Paciente não encontrado: {request.PacienteId}",
                "Paciente não encontrado");

        var findMedico = _medicoRepository
            .GetMedicoById(request.MedicoId);
        if (findMedico == null)
            throw new RequestError(
                $"Médico não encontrado: {request.MedicoId}",
                "Médico não encontrado");

        var findExames = await _exameRepository
            .GetExamesByIdsAsync(request.ExameIds);
        if (request.ExameIds.Count() != findExames.Count)
        {
            var examesNotFound = request.ExameIds
                .Except(findExames.Select(e => e.Id));
            throw new RequestError(
                $"Exames não encontrados: {string.Join(", ", examesNotFound)}",
                "Exames não encontrados");
        }

        laudo.Exames = findExames;

        var findConsulta = await _consultaRepository
            .GetByIdAsync(request.ConsultaId);
        if (findConsulta == null)
            throw new RequestError(
                $"Consulta não encontrada: {request.ConsultaId}",
                "Consulta não encontrada");

        if (request.DocImg != null)
            laudo.DocPath = _imageRepository
                .SaveLaudoImage(request.DocImg);

        await _laudoRepository.Create(laudo);

        return $"/api/Laudo/{laudo.Id}";
    }
}