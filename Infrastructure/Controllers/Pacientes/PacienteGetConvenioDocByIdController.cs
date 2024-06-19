using Hospital.Application.Consts;
using Hospital.Application.UseCases.Cadastros.Pacientes;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Infrastructure.Controllers.Pacientes;
[ApiController]
[Route("api/Paciente")]
[Tags("Paciente")]
public class PacienteGetConvenioDocByGuidController : ControllerBase
{
    [HttpGet("Documentos/Convenio/{id}")]
    [Authorize(Policy = PoliciesConsts.Elevated)]
    public async Task<IActionResult> Execute(
        [FromServices] PacienteGetDocConvenioUseCase _service,
        [FromRoute] Guid id)
    {
        var imagePath = await _service.Handler(id);
        return File(imagePath, "image/png");
    }
}