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
/*  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultDto<string>))] */
/*  [ProducesResponseType(StatusCodes.Status500InternalServerError)] */
/*  [ProducesResponseType(StatusCodes.Status400BadRequest)] */
/*  [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResultDto<string>))] */
    public async Task<IActionResult> Execute(
        [FromBody] RegisterRequestAdminDto request)
    {
        var uri = await _service.Handler(request);
        return Ok(new ResponseDataObject(uri));
    }
}