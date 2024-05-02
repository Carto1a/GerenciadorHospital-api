using Hospital.Dtos.Input.Medicamentos;
using Hospital.Services.Medicamentos;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers.MedicamentoLotes;
[ApiController]
[Route("api/Medicamento/Lotes")]
[Tags("Medicamentos/Lotes")]
public class MedicamentoLoteGetByQueryController
: ControllerBase
{
    private readonly MedicamentoLoteGetByQueryService _service;
    public MedicamentoLoteGetByQueryController(
        MedicamentoLoteGetByQueryService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult Execute(
        [FromQuery] MedicamentoLoteGetByQueryDto query)
    {
        var medicamentoLotes = _service.Handler(query);
        return Ok(medicamentoLotes);
    }
}