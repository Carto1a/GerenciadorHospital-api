using Hospital.Application.Dto.Input.Authentications;
using Hospital.Application.UseCases.Cadastros.Admins;
using Hospital.Infrastructure.Filter;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Infrastructure.Controllers.Admins;
[ApiController]
[Route("api/Admin")]
[Tags("Admin")]
public class AdminLoginController : ControllerBase
{
    [HttpPost("Login")]
    [AllowAnonymous]
    public async Task<IActionResult> ExecuteAsync(
        [FromServices] AdminLoginUseCase _service,
        [FromBody] LoginRequestAdminDto request)
    {
        var token = await _service.Handler(request);
        return Ok(new ResponseDataObject(token));
    }
}