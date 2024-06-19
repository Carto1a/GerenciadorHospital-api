using Hospital.Application.Consts;
using Hospital.Application.UseCases.Cadastros.Pacientes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Infrastructure.Controllers.Pacientes;
[ApiController]
[Route("api/Paciente")]
[Tags("Paciente")]
public class PacienteAddDocIdController : ControllerBase
{
    [HttpPost("Documentos/IdDoc/{id}")]
    [Authorize(Policy = PoliciesConsts.Elevated)]
    public async Task<IActionResult> Execute(
        [FromServices] PacienteAddDocIdUseCase _service,
        [FromRoute] Guid id,
        [FromForm] IFormFile file)
    {
        var imageId = await _service.Handler(id, file);
        return Ok(imageId);
    }
}