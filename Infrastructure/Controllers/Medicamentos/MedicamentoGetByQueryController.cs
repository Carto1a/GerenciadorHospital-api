using Hospital.Application.Consts;
using Hospital.Application.Dto.Input.Medicamentos;
using Hospital.Application.UseCases.Medicamentos;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Infrastructure.Controllers.Medicamentos;
[ApiController]
[Route("api/Medicamentos")]
[Tags("Medicamentos")]
public class MedicamentoGetByQueryController : ControllerBase
{
    [HttpGet]
    [Authorize(Policy = PoliciesConsts.Standard)]
    public async Task<IActionResult> Execute(
        [FromServices] MedicamentoGetByQueryUseCase _service,
        [FromQuery] MedicamentoGetByQueryDto query)
    {
        var medicamentos = await _service.Handler(query);
        return Ok(medicamentos);
    }
}