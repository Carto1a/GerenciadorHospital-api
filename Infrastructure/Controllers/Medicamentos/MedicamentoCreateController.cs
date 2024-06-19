using Hospital.Application.Consts;
using Hospital.Application.Dto.Input.Medicamentos;
using Hospital.Application.UseCases.Medicamentos;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Infrastructure.Controllers.Medicamentos;
[ApiController]
[Route("api/Medicamentos")]
[Tags("Medicamentos")]
public class MedicamentoCreateController : ControllerBase
{
    [HttpPost]
    [Authorize(Policy = PoliciesConsts.Operational)]
    public async Task<IActionResult> Post(
        [FromServices] MedicamentoCreateUseCase _service,
        [FromBody] MedicamentoCreateDto request)
    {
        var result = await _service.Handler(request);
        return Created("", result);
    }
}