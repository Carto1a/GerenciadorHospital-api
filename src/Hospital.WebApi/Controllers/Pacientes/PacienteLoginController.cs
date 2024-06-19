using Hospital.Application.Dto.Input.Authentications;
using Hospital.Application.UseCases.Cadastros.Pacientes;
using Hospital.Infrastructure.Filter;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Infrastructure.Controllers.Pacientes;
[ApiController]
[Route("api/Paciente")]
[Tags("Paciente")]
public class PacienteLoginController : ControllerBase
{
    [HttpPost("Login")]
    [AllowAnonymous]
    public async Task<IActionResult> Execute(
        [FromServices] PacienteLoginUseCase _service,
        [FromBody] LoginRequestPacienteDto request)
    {
        var token = await _service.Handler(request);
        return Ok(new ResponseDataObject(token));
    }
}