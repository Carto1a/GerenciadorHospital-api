using Hospital.Dtos.Input.Authentications;
using Hospital.Filter;
using Hospital.Services.Cadastros.Admins;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers.Admins;
[ApiController]
[Route("api/Admin")]
[Tags("Admin")]
public class AdminLoginController
: ControllerBase
{
    private readonly AuthAdminLoginService _authAdminLoginService;
    public AdminLoginController(
        AuthAdminLoginService authAdminLoginService)
    {
        _authAdminLoginService = authAdminLoginService;
    }

    [HttpPost("Login")]
    [AllowAnonymous]
    public async Task<IActionResult> ExecuteAsync(
        [FromBody] LoginRequestAdminDto request)
    {
        var token = await _authAdminLoginService.Handler(request);
        return Ok(new ResponseDataObject(token));
    }
}