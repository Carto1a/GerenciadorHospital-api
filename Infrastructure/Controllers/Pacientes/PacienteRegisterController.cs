using Hospital.Application.Consts;
using Hospital.Application.Dto.Input.Authentications;
using Hospital.Application.UseCases.Cadastros.Pacientes;
using Hospital.Infrastructure.Filter;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Infrastructure.Controllers.Pacientes;
[ApiController]
[Route("api/Paciente")]
[Tags("Paciente")]
public class PacienteRegisterController : ControllerBase
{
    [HttpPost("Cadastro")]
    [Authorize(Policy = PoliciesConsts.Elevated)]
    public async Task<IActionResult> Execute(
        [FromServices] PacienteRegisterUseCase _service,
        [FromForm] RegisterRequestPacienteDto request)
    {
        var uri = await _service.Handler(request);
        return Created("", new ResponseDataObject(uri));
    }
}