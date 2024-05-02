using Hospital.Services.Medicamentos;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers.MedicamentoLotes;
[ApiController]
[Route("api/Medicamento/Lotes")]
[Tags("Medicamentos/Lotes")]
public class MedicamentoLoteGetByIdController
: ControllerBase
{
    private readonly MedicamentoLoteGetByIdService _service;
    public MedicamentoLoteGetByIdController(
        MedicamentoLoteGetByIdService service)
    {
        _service = service;
    }

    [HttpGet("{id}")]
    public IActionResult Get(
        [FromRoute] Guid id)
    {
        var result = _service.Handler(id);
        return Ok(result);
    }
}