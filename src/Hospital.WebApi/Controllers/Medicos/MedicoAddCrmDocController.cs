using Hospital.Application.Consts;
using Hospital.Application.UseCases.Cadastros.Medicos;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Infrastructure.Controllers.Medicos;
[ApiController]
[Route("api/Medico")]
[Tags("Medico")]
public class MedicoAddCrmDocController : ControllerBase
{
    [HttpPost("CrmDoc/{id}")]
    [Authorize(Policy = PoliciesConsts.Operational)]
    public async Task<IActionResult> Execute(
        [FromServices] MedicoGetDocCrmUseCase _service,
        [FromRoute] Guid id)
    {
        var medicos = await _service.Handler(id);
        return File(medicos, "image/png");
    }
}