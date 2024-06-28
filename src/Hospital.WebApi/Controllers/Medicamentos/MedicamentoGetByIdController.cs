/* using Hospital.Application.Consts; */
/* using Hospital.Application.UseCases.Medicamentos; */

/* using Microsoft.AspNetCore.Authorization; */
/* using Microsoft.AspNetCore.Mvc; */

/* namespace Hospital.WebApi.Controllers.Medicamentos; */
/* [ApiController] */
/* [Route("api/Medicamentos")] */
/* [Tags("Medicamentos")] */
/* public class MedicamentoGetByIdController : ControllerBase */
/* { */
/*     [HttpGet("{id}")] */
/*     [Authorize(Policy = PoliciesConsts.Standard)] */
/*     public async Task<IActionResult> Get( */
/*         [FromServices] MedicamentoGetByIdUseCase service, */
/*         [FromRoute] Guid id) */
/*     { */
/*         var result = await service.Handler(id); */
/*         return Ok(result); */
/*     } */
/* } */