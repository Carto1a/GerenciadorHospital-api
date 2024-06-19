using Hospital.Application.Consts;
using Hospital.Application.UseCases.Cadastros.Medicos;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Infrastructure.Controllers.Medicos;
[ApiController]
[Route("api/Medico")]
[Tags("Medico")]
public class MedicoGetCrmDocByIdController : ControllerBase
{
    [HttpGet("CrmDoc/{id}")]
    [Authorize(Policy = PoliciesConsts.Elevated)]
    public async Task<IActionResult> Execute(
        [FromServices] MedicoGetDocCrmUseCase _service,
        [FromRoute] Guid id)
    {
        var medicos = await _service.Handler(id);
        return File(medicos, "image/png");
    }
}