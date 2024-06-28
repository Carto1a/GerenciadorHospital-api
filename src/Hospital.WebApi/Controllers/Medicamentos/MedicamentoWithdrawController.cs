/* using Hospital.Application.Consts; */
/* using Hospital.Application.Dto.Input.Medicamentos; */
/* using Hospital.Application.UseCases.Medicamentos; */

/* using Microsoft.AspNetCore.Authorization; */
/* using Microsoft.AspNetCore.Mvc; */

/* namespace Hospital.WebApi.Controllers.Medicamentos; */
/* [ApiController] */
/* [Route("api/Medicamentos")] */
/* [Tags("Medicamentos")] */
/* public class MedicamentoWithdrawController : ControllerBase */
/* { */
/*     [HttpPatch("{id}/Retirar")] */
/*     [Authorize(Policy = PoliciesConsts.Operational)] */
/*     public async Task<IActionResult> Withdraw( */
/*         [FromServices] MedicamentoWithdrawUseCase service, */
/*         [FromRoute] Guid id, */
/*         [FromBody] MedicamentoWithdrawDto request) */
/*     { */
/*         await service.Handler(id, request); */
/*         return Ok(); */
/*     } */
/* } */