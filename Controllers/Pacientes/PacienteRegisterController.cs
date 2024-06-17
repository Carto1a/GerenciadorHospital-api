using Hospital.Consts;
using Hospital.Dtos.Input.Authentications;
using Hospital.Filter;
using Hospital.Services.Cadastros.Pacientes;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers.Pacientes;
[ApiController]
[Route("api/Paciente")]
[Tags("Paciente")]
public class PacienteRegisterController
: ControllerBase
{
    private readonly PacienteRegisterService _service;
    public PacienteRegisterController(
        PacienteRegisterService service)
    {
        _service = service;
    }

    [HttpPost("Cadastro")]
    [Authorize(Policy = PoliciesConsts.Elevated)]
    public async Task<IActionResult> Execute(
        [FromForm] RegisterRequestPacienteDto request)
    {
        var uri = await _service.Handler(request);
        return Created("", new ResponseDataObject(uri));
    }
}