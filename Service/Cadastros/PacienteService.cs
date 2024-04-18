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
        var response = _pacienteRepository.GetPacienteById(pacienteId);
        var result = response.ToResultDto();
        if (response.IsFailed)
            return Result.Fail("Não foi possivel achar o paciente");

        return Result.Ok(response.Value);
    }

    public Result<string> GetPacienteDocumento(
        ClaimsPrincipal user, Guid guid)
    {
        var id = user.Claims.FirstOrDefault(x => x.Type == "ID")?.Value;
        if (id == null)
            return Result.Fail("Paciente não encontrado");

        var response = _pacienteRepository.GetPacienteById(new Guid(id));
        if (response.IsFailed)
            return Result.Fail("Paciente não encontrado");

        var paciente = response.Value;

        if (
            !guid.Equals(paciente.ImgCarteiraConvenio)
            && !guid.Equals(paciente.ImgDocumento))
            return Result.Fail("Não foi possivel achar o arquivo");

        var path = Path.Combine(
            _configuration["Paths:PacienteDocumentos"], guid.ToString());
        if (!File.Exists(path))
            return Result.Fail("Arquivo não achado");

        return Result.Ok(path);
    }

    public Result<List<Paciente>> GetPacientes(int limit, int page = 0)
    {
        var respose = _pacienteRepository.GetPacientes(limit, page);
        if (respose.IsFailed)
            return Result.Fail("Erro ao buscar pacientes");

        return Result.Ok(respose.Value);
    }
}
