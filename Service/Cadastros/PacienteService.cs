using System.Security.Claims;

using FluentResults;

using Hospital.Database;
using Hospital.Extensions;
using Hospital.Models.Cadastro;
using Hospital.Repository.Cadastros.Interfaces;
using Hospital.Service.Interfaces;

using Microsoft.AspNetCore.Identity;

namespace Hospital.Service.Cadastros;
public class PacienteService
: IPacienteService
{
    private readonly ILogger<PacienteService> _logger;
    private readonly UserManager<Cadastro> _userManager;
    private readonly AppDbContext _ctx;
    private readonly IPacienteRepository _pacienteRepository;
    private readonly IConfiguration _configuration;
    public PacienteService(
        AppDbContext ctx,
        IPacienteRepository pacienteService,
        IConfiguration configuration,
        UserManager<Cadastro> userManager,
        ILogger<PacienteService> logger)
    {
        _configuration = configuration;
        _userManager = userManager;
        _pacienteRepository = pacienteService;
        _ctx = ctx;
        _logger = logger;
        _logger.LogDebug(1, "NLog injected into PacienteService");
    }

    public Result<Paciente?> GetPacienteById(Guid pacienteId)
    {
        _logger.LogInformation($"Buscando paciente por id: {pacienteId}");
        var response = _pacienteRepository.GetPacienteById(pacienteId);
        var result = response.ToResultDto();
        if (response.IsFailed)
        {
            _logger.LogError($"Não foi possivel achar o paciente: {pacienteId}");
            return Result.Fail("Não foi possivel achar o paciente");
        }

        _logger.LogInformation($"Paciente encontrado: {pacienteId}");
        return Result.Ok(response.Value);
    }

    public Result<string> GetPacienteDocumento(
        ClaimsPrincipal user, Guid guid)
    {
        _logger.LogInformation($"Buscando documento do paciente: {guid}");
        var id = user.Claims.FirstOrDefault(x => x.Type == "ID")?.Value;
        if (id == null)
        {
            _logger.LogError("Id do token do paciente não encontrado");
            return Result.Fail("Paciente não encontrado");
        }

        var response = _pacienteRepository.GetPacienteById(new Guid(id));
        if (response.IsFailed)
        {
            _logger.LogError("Paciente não encontrado");
            return Result.Fail("Paciente não encontrado");
        }

        var paciente = response.Value;

        if (!guid.Equals(paciente.ImgCarteiraConvenio)
            && !guid.Equals(paciente.ImgDocumento))
        {
            _logger.LogError($"Não foi possivel achar o arquivo de: {id}");
            return Result.Fail("Não foi possivel achar o arquivo");
        }

        var rootPath = _configuration["Paths:PacienteDocumentos"];
        var path = Path.Combine(
            _configuration["Paths:PacienteDocumentos"], guid.ToString());
        if (!File.Exists(path))
        {
            _logger.LogError($"Arquivo não achado de nome: {guid.ToString()}");
            return Result.Fail("Arquivo não achado");
        }

        _logger.LogInformation($"Arquivo achado de nome: {guid}");
        return Result.Ok(path);
    }

    public Result<List<Paciente>> GetPacientes(int limit, int page = 0)
    {
        _logger.LogInformation($"Buscando pacientes: {limit} - {page}");
        var respose = _pacienteRepository.GetPacientes(limit, page);
        if (respose.IsFailed)
        {
            _logger.LogError("Erro ao buscar pacientes");
            return Result.Fail("Erro ao buscar pacientes");
        }

        _logger.LogInformation($"Pacientes encontrados: {respose.Value.Count}");
        return Result.Ok(respose.Value);
    }
}