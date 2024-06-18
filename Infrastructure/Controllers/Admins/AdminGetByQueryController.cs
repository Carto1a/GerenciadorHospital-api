using Hospital.Application.Consts;
using Hospital.Application.Dto.Input.Authentications;
using Hospital.Application.UseCases.Cadastros.Admins;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Infrastructure.Controllers.Admins;
[ApiController]
[Route("api/Admin")]
[Tags("Admin")]
public class AdminGetByQueryController
: ControllerBase
{
    [HttpGet]
    /* [Authorize(Policy = PoliciesConsts.Elevated)] */
    public async Task<IActionResult> Execute(
        [FromServices] AdminGetByQueryUseCase _service,
        [FromQuery] AdminGetByQueryDto query)
    {
        var admins = await _service.Handler(query);
        return Ok(admins);
    }
}