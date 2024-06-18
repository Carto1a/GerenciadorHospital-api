using Hospital.Application.UseCases.Cadastros.Pacientes;
using Hospital.Consts;
using Hospital.Filter;
using Hospital.Repository;
using Hospital.Services.Cadastros.Pacientes;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers.Pacientes;
[ApiController]
[Route("api/Paciente")]
[Tags("Paciente")]
public class PacienteGetIDDocController
: ControllerBase
{
    private readonly PacienteGetByIdService _service;
    private UnitOfWork _uow;
    public PacienteGetIDDocController(
        PacienteGetByIdService service,
        UnitOfWork uow)
    {
        _service = service;
        _uow = uow;
    }

    [HttpGet("Documentos/IDDoc/{id}")]
    [Authorize(Policy = PoliciesConsts.Elevated)]
    public async Task<IActionResult> Execute(
        [FromServices] PacienteGetIDDocService _service,
        [FromRoute] Guid id)
    {
        var imagePath = await _service.Handler(id);

        return File(System.IO.File.ReadAllBytes(imagePath), "image/png");
    }
}