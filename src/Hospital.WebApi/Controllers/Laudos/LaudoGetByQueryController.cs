using Hospital.Application.Consts;
using Hospital.Application.Dto.Input.Laudos;
using Hospital.Application.UseCases.Laudos;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Infrastructure.Controllers.Laudos;
[ApiController]
[Route("api/Laudo")]
[Tags("Laudo")]
public class LaudoGetByQueryController : ControllerBase
{
    [HttpGet]
    [Authorize(Policy = PoliciesConsts.Operational)]
    public async Task<IActionResult> Execute(
        [FromServices] LaudoGetByQueryUseCase _service,
        [FromQuery] LaudoGetByQueryDto query)
    {
        var result = await _service.Handler(query);
        return Ok(result);
    }
}