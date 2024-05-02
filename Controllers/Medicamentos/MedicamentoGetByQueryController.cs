using Hospital.Dtos.Input.Medicamentos;
using Hospital.Services.Medicamentos;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers.Medicamentos;
[ApiController]
[Route("api/Medicamentos")]
[Tags("Medicamentos")]
public class MedicamentoGetByQueryController
: ControllerBase
{
    private readonly MedicamentoGetByQueryService _service;
    public MedicamentoGetByQueryController(
        MedicamentoGetByQueryService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult Execute(
        [FromQuery] MedicamentoGetByQueryDto query)
    {
        var medicamentos = _service.Handler(query);
        return Ok(medicamentos);
    }
}
