using System.Security.Claims;
using FluentResults;
using Hospital.Database;
using Hospital.Models.Cadastro;
using Hospital.Service.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Hospital.Service.Cadastros;
public class PacienteService
: IPacienteService
{
    private readonly UserManager<Cadastro> _userManager;
    private readonly AppDbContext _ctx;
    private readonly IConfiguration _configuration;
    public PacienteService(
        AppDbContext ctx,
        IConfiguration configuration,
        UserManager<Cadastro> userManager)
    {
        _configuration = configuration;
        _userManager = userManager;
        _ctx = ctx;
    }
    public Result<string> GetPacienteDocumento(ClaimsPrincipal user, string guid)
    {
        var id = user.Claims.FirstOrDefault(x => x.Type == "ID")?.Value;
        var paciente = _ctx.Pacientes
            .FirstOrDefault(x => x.Id == id);

        if (paciente.ImgCarteiraConvenio != guid && paciente.ImgDocumento != guid)
            return Result.Fail("Arquivo não achado");

        var path = Path.Combine(_configuration["Paths:PacienteDocumentos"], guid);
        if (!File.Exists(path))
            return Result.Fail("Arquivo não achado");

        return Result.Ok(path);
    }
}
