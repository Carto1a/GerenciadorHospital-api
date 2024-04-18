using Hospital.Controllers.Generics;
using Hospital.Dto.Auth;
using Hospital.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers.Pacientes;
[ApiController]
[Route("api/[controller]")]
public class PacienteController
: GenericAuthenticationController<RegisterRequestPacienteDto>
{
    private readonly IPacienteService _pacienteService;
    private readonly IAuthenticationService _authenticationService;
    public PacienteController(
        IConfiguration configuration,
        IPacienteService pacienteService,
        IAuthenticationService authenticationService)
        : base(authenticationService)
    {
        _pacienteService = pacienteService;
        _authenticationService = authenticationService;
    }

    [Authorize]
    [HttpGet("Documentos/Mostrar/{guid}")]
    public async Task<IActionResult> GetDocumento([FromRoute] string guid)
    {
        var result = _pacienteService.GetPacienteDocumento(User, guid);
        if (result.IsFailed)
            return NotFound();

        var path = result.Value;
        if (!System.IO.File.Exists(path))
            return NotFound();

        // NOTE: não existe uma biblioteca de mimetypes, obrigrado microsoft
        return File(System.IO.File.ReadAllBytes(path), "image/png");
    }
}
