using Hospital.Application.Dto.Input.Authentications;
using Hospital.Application.UseCases.Cadastros.Medicos;
using Hospital.Infrastructure.Filter;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Infrastructure.Controllers.Medicos;
[ApiController]
[Route("api/Medico")]
[Tags("Medico")]
public class MedicoLoginController
: ControllerBase
{
    [HttpPost("Login")]
    [AllowAnonymous]
    public async Task<IActionResult> Execute(
        [FromServices] MedicoLoginUseCase _service,
        [FromBody] LoginRequestMedicoDto request)
    {
        var token = await _service.Handler(request);
        return Ok(new ResponseDataObject(token));
    }
}