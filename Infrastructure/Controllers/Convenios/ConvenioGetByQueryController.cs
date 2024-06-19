using Hospital.Application.Consts;
using Hospital.Application.Dto.Input.Convenios;
using Hospital.Application.UseCases.Convenios;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Infrastructure.Controllers.Convenios;
[ApiController]
[Route("api/Convenio")]
[Tags("Convenio")]
public class ConvenioGetByQueryController : ControllerBase
{
    [HttpGet]
    [Authorize(Policy = PoliciesConsts.Standard)]
    public async Task<IActionResult> Execute(
        [FromServices] ConvenioGetByQueryUseCase _service,
        [FromQuery] ConvenioGetByQueryDto query)
    {
        var convenios = await _service.Handler(query);
        return Ok(convenios);
    }
}