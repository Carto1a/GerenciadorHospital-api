using Hospital.Filter;
using Hospital.Repository;
using Hospital.Services.Pacientes;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers.Pacientes;
[ApiController]
[Route("api/Paciente")]
[Tags("Paciente")]
public class PacienteGetByIdController
: ControllerBase
{
    private readonly PacienteGetByIdService _service;
    private UnitOfWork _uow;
    public PacienteGetByIdController(
        PacienteGetByIdService service,
        UnitOfWork uow)
    {
        _service = service;
        _uow = uow;
    }

    [HttpGet("{id}")]
    public IActionResult Execute(
        [FromRoute] Guid id)
    {
        /* var paciente = _uow.PacienteRepository.GetPacienteById(id); */
        var paciente = _service.Handler(id);
        var response = new ResponseDataObject(paciente);
        return Ok(response);
    }
}