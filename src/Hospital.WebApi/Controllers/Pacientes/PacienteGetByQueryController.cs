using Hospital.Application.Consts;
using Hospital.Application.Dto.Input.Authentications;
using Hospital.Application.UseCases.Cadastros.Pacientes;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Infrastructure.Controllers.Pacientes;
[ApiController]
[Route("api/Paciente")]
[Tags("Paciente")]
public class PacienteGetByQueryController : ControllerBase
{
    [HttpGet]
    [Authorize(Policy = PoliciesConsts.Elevated)]
    public async Task<IActionResult> Execute(
        [FromServices] PacienteGetByQueryUseCase _service,
        [FromQuery] PacienteGetByQueryDto query)
    {
        var pacientes = await _service.Handler(query);
        return Ok(pacientes);
    }
}