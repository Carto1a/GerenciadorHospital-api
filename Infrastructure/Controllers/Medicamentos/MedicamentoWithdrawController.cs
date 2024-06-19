using Hospital.Application.Consts;
using Hospital.Application.Dto.Input.Medicamentos;
using Hospital.Application.UseCases.Medicamentos;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers.Medicamentos;
[ApiController]
[Route("api/Medicamentos")]
[Tags("Medicamentos")]
public class MedicamentoWithdrawController : ControllerBase
{
    [HttpPatch("{id}/Retirar")]
    [Authorize(Policy = PoliciesConsts.Operational)]
    public async Task<IActionResult> Withdraw(
        [FromServices] MedicamentoWithdrawUseCase _service,
        [FromRoute] Guid id,
        [FromBody] MedicamentoWithdrawDto request)
    {
        await _service.Handler(id, request);
        return Ok();
    }
}