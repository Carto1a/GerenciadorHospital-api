/* using Hospital.Application.Consts; */
/* using Hospital.Application.UseCases.Medicamentos; */

/* using Microsoft.AspNetCore.Authorization; */
/* using Microsoft.AspNetCore.Mvc; */

/* namespace Hospital.WebApi.Controllers.MedicamentoLotes; */
/* [ApiController] */
/* [Route("api/Medicamento/Lotes")] */
/* [Tags("Medicamentos/Lotes")] */
/* public class MedicamentoLoteGetByIdController : ControllerBase */
/* { */
/*     [HttpGet("{id}")] */
/*     [Authorize(Policy = PoliciesConsts.Elevated)] */
/*     public async Task<IActionResult> Get( */
/*         [FromServices] MedicamentoLoteGetByIdUseCase service, */
/*         [FromRoute] Guid id) */
/*     { */
/*         var result = await service.Handler(id); */
/*         return Ok(result); */
/*     } */
/* } */