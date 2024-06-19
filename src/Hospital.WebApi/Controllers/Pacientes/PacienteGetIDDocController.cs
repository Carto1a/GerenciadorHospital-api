using Hospital.Application.UseCases.Cadastros.Pacientes;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Infrastructure.Controllers.Pacientes;
[ApiController]
[Route("api/Paciente")]
[Tags("Paciente")]
public class PacienteGetIDDocController : ControllerBase
{
    [HttpGet("Documentos/IdDoc")]
    [Authorize(Roles = "PACIENTE")]
    public async Task<IActionResult> Execute(
        [FromServices] PacienteGetDocIdUseCase _service)
    {
        var id = User.Claims.FirstOrDefault(c => c.Type == "ID")?.Value;
        if (id == null)
            return Unauthorized();

        var imagePath = await _service.Handler(Guid.Parse(id));
        return File(imagePath, "image/png");
    }
}