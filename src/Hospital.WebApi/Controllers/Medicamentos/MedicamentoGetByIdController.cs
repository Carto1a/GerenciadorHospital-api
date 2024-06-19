using Hospital.Application.Consts;
using Hospital.Application.UseCases.Medicamentos;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Infrastructure.Controllers.Medicamentos;
[ApiController]
[Route("api/Medicamentos")]
[Tags("Medicamentos")]
public class MedicamentoGetByIdController : ControllerBase
{
    [HttpGet("{id}")]
    [Authorize(Policy = PoliciesConsts.Standard)]
    public async Task<IActionResult> Get(
        [FromServices] MedicamentoGetByIdUseCase _service,
        [FromRoute] Guid id)
    {
        var result = await _service.Handler(id);
        return Ok(result);
    }
}