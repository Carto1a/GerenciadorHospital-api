using Hospital.Application.Consts;
using Hospital.Application.UseCases.Cadastros.Pacientes;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Infrastructure.Controllers.Pacientes;
[ApiController]
[Route("api/Paciente")]
[Tags("Paciente")]
public class PacienteGetIDDocByGuidController : ControllerBase
{
    [HttpGet("Documentos/IdDoc/{id}")]
    [Authorize(Policy = PoliciesConsts.Elevated)]
    public async Task<IActionResult> Execute(
        [FromServices] PacienteGetDocIdUseCase _service,
        [FromRoute] Guid id)
    {
        var imagePath = await _service.Handler(id);
        return File(imagePath, "image/png");
    }
}