/* using Hospital.Application.Consts; */
/* using Hospital.Application.Dto.Input.Medicamentos; */
/* using Hospital.Application.UseCases.Medicamentos; */

/* using Microsoft.AspNetCore.Authorization; */
/* using Microsoft.AspNetCore.Mvc; */

/* namespace Hospital.WebApi.Controllers.Medicamentos; */
/* [ApiController] */
/* [Route("api/Medicamentos")] */
/* [Tags("Medicamentos")] */
/* public class MedicamentoGetByQueryController : ControllerBase */
/* { */
/*     [HttpGet] */
/*     [Authorize(Policy = PoliciesConsts.Standard)] */
/*     public async Task<IActionResult> Execute( */
/*         [FromServices] MedicamentoGetByQueryUseCase service, */
/*         [FromQuery] MedicamentoGetByQueryDto query) */
/*     { */
/*         var medicamentos = await service.Handler(query); */
/*         return Ok(medicamentos); */
/*     } */
/* } */