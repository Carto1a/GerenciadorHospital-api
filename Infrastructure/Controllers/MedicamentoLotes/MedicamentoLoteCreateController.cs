using Hospital.Application.Consts;
using Hospital.Application.Dto.Input.Medicamentos;
using Hospital.Application.UseCases.Medicamentos;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Infrastructure.Controllers.MedicamentoLotes;
[ApiController]
[Route("api/Medicamento/Lotes")]
[Tags("Medicamentos/Lotes")]
public class MedicamentoLoteCreateController : ControllerBase
{
    [HttpPost]
    [Authorize(Policy = PoliciesConsts.Elevated)]
    public async Task<IActionResult> Post(
        [FromServices] MedicamentoLoteCreateUseCase _service,
        [FromBody] MedicamentoLoteCreateDto request)
    {
        var result = await _service.Handler(request);
        return Created("", result);
    }
}