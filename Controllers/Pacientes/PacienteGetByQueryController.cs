using Hospital.Dtos.Input.Authentications;
using Hospital.Services.Cadastros.Pacientes;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers.Pacientes;
[ApiController]
[Route("api/Paciente")]
[Tags("Paciente")]
public class PacienteGetByQueryController
: ControllerBase
{
    private readonly PacienteGetByQueryService _service;
    public PacienteGetByQueryController(
        PacienteGetByQueryService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult Execute(
        [FromQuery] PacienteGetByQueryDto query)
    {
        var pacientes = _service.Handler(query);
        return Ok(pacientes);
    }
}