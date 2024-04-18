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
    private readonly UserManager<Cadastro> _userManager;
    private readonly AppDbContext _ctx;
    private readonly IPacienteRepository _pacienteRepository;
    private readonly IConfiguration _configuration;
    public PacienteService(
        AppDbContext ctx,
        IPacienteRepository pacienteService,
        IConfiguration configuration,
        UserManager<Cadastro> userManager)
    {
        _configuration = configuration;
        _userManager = userManager;
        _pacienteRepository = pacienteService;
        _ctx = ctx;
    }

    public Result<Paciente?> GetPacienteById(string pacienteId)
    {
        var response = _pacienteRepository.GetPacienteById(pacienteId);
        var result = response.ToResultDto();
        if (response.IsFailed)
            return Result.Fail("Não foi possivel achar o paciente");

        return Result.Ok(response.Value);
    }

    public Result<string> GetPacienteDocumento(
        ClaimsPrincipal user, string guid)
    {
        var id = user.Claims.FirstOrDefault(x => x.Type == "ID")?.Value;
        if (id == null)
            return Result.Fail("Paciente não encontrado");

        var response = _pacienteRepository.GetPacienteById(id);
        if (response.IsFailed)
            return Result.Fail("Paciente não encontrado");

        var paciente = response.Value;

        if (paciente.ImgCarteiraConvenio != guid && paciente.ImgDocumento != guid)
            return Result.Fail("Arquivo não achado");

        var path = Path.Combine(
            _configuration["Paths:PacienteDocumentos"], guid);
        if (!File.Exists(path))
            return Result.Fail("Arquivo não achado");

        return Result.Ok(path);
    }

    public Result<List<Paciente>> GetPacientes(int limit, int page = 0)
    {
        var respose = _pacienteRepository.GetPacientes(limit, page);
        if(respose.IsFailed)
            return Result.Fail("Erro ao buscar pacientes");

        return Result.Ok(respose.Value);
    }
}
