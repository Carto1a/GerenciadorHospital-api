using Hospital.Consts;
using Hospital.Dtos.Input.Authentications;
using Hospital.Filter;
using Hospital.Services.Cadastros;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers.Admins;
[ApiController]
[Route("api/Admin")]
[Tags("Admin")]
public class AdminRegisterController
: ControllerBase
{
    private readonly AuthAdminRegisterService _service;
    public AdminRegisterController(
        AuthAdminRegisterService service)
    {
        _service = service;
    }

    [HttpPost("Cadastro")]
    [Authorize(Policy = PoliciesConsts.Elevated)]
    public async Task<IActionResult> Execute(
        [FromBody] RegisterRequestAdminDto request)
    {
        var uri = await _service.Handler(request);
        return Ok(new ResponseDataObject(uri));
    }
}