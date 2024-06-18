using Hospital.Application.Consts;
using Hospital.Application.Dto.Input.Authentications;
using Hospital.Application.UseCases.Cadastros.Admins;
using Hospital.Infrastructure.Filter;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers.Admins;
[ApiController]
[Route("api/Admin")]
[Tags("Admin")]
public class AdminRegisterController
: ControllerBase
{
    [HttpPost("Cadastro")]
    [Authorize(Policy = PoliciesConsts.Elevated)]
    public async Task<IActionResult> Execute(
        [FromServices] AdminRegisterUseCase _service,
        [FromBody] RegisterRequestAdminDto request)
    {
        var uri = await _service.Handler(request);
        return Ok(new ResponseDataObject(uri));
    }
}