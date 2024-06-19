using Hospital.Application.Consts;
using Hospital.Application.UseCases.Laudos;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Infrastructure.Controllers.Laudos;
[ApiController]
[Route("api/Laudo")]
[Tags("Laudo")]
public class LaudoGetDocImageController : ControllerBase
{
    [HttpGet("Imagem/{id}")]
    [Authorize(Policy = PoliciesConsts.Operational)]
    public async Task<IActionResult> Execute(
        [FromServices] LaudoGetDocImageUseCase _service,
        [FromRoute] Guid id)
    {
        var result = await _service.Handler(id);
        return File(result, "image/jpeg");
    }
}