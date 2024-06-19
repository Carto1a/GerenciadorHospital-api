using Hospital.Application.Dto.Input.Medicamentos;
using Hospital.Application.UseCases.Medicamentos;

using Microsoft.AspNetCore.Mvc;

namespace Hospital.Infrastructure.Controllers.MedicamentoLotes;
[ApiController]
[Route("api/Medicamento/Lotes")]
[Tags("Medicamentos/Lotes")]
public class MedicamentoLoteGetByQueryController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Execute(
        [FromServices] MedicamentoLoteGetByQueryUseCase _service,
        [FromQuery] MedicamentoLoteGetByQueryDto query)
    {
        var medicamentoLotes = await _service.Handler(query);
        return Ok(medicamentoLotes);
    }
}