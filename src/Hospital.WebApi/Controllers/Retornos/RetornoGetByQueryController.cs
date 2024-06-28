/* using Hospital.Application.Consts; */
/* using Hospital.Application.Dto.Input.Atendimentos; */
/* using Hospital.Application.UseCases.Atendimentos; */

/* using Microsoft.AspNetCore.Authorization; */
/* using Microsoft.AspNetCore.Mvc; */

/* namespace Hospital.WebApi.Controllers.Retornos; */
/* [ApiController] */
/* [Route("api/Atendimentos/Retorno")] */
/* [Tags("Retorno")] */
/* public class RetornoGetByQueryController : ControllerBase */
/* { */
/*     [HttpGet] */
/*     [Authorize(Policy = PoliciesConsts.Operational)] */
/*     public async Task<IActionResult> Execute( */
/*         [FromServices] RetornoGetByQueryUseCase service, */
/*         [FromQuery] RetornoGetByQueryDto query) */
/*     { */
/*         var result = await service.Handler(query); */
/*         return Ok(result); */
/*     } */
/* } */