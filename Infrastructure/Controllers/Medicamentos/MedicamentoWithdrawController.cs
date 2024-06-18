/* using Hospital.Dtos.Input.Medicamentos; */
/* using Hospital.Services.Medicamentos; */
/* using Microsoft.AspNetCore.Mvc; */

/* namespace Hospital.Controllers.Medicamentos; */
/* [ApiController] */
/* [Route("api/Medicamentos")] */
/* [Tags("Medicamentos")] */
/* public class MedicamentoWithdrawController */
/* : ControllerBase */
/* { */
/*     private readonly MedicamentoWithdrawService _service; */
/*     public MedicamentoWithdrawController( */
/*         MedicamentoWithdrawService service) */
/*     { */
/*         _service = service; */
/*     } */

/*     [HttpPatch("{id}/Retirar")] */
/*     public IActionResult Withdraw( */
/*         [FromRoute] Guid id, */
/*         [FromBody] MedicamentoWithdrawDto request) */
/*     { */
/*         _service.Handler(id, request); */
/*         return Ok(); */
/*     } */
/* } */