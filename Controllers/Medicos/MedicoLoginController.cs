using Hospital.Dtos.Input.Authentications;
using Hospital.Filter;
using Hospital.Services.Cadastros.Medicos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers.Medicos;
[ApiController]
[Route("api/Medico")]
[Tags("Medico")]
public class MedicoLoginController
: ControllerBase
{
    private readonly MedicoLoginService _service;
    public MedicoLoginController(
        [FromBody] MedicoLoginService service)
    {
        _service = service;
    }

    [HttpPost("Login")]
    [AllowAnonymous]
    /*  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultDto<string>))] */
    /*  [ProducesResponseType(StatusCodes.Status500InternalServerError)] */
    /*  [ProducesResponseType(StatusCodes.Status400BadRequest)] */
    /*  [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResultDto<string>))] */
    public async Task<IActionResult> Execute(
        [FromBody] LoginRequestMedicoDto request)
    {
        var token = await _service.Handler(request);
        return Ok(new ResponseDataObject(token));
    }
}