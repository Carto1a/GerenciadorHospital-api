/* using Hospital.Application.Consts; */
/* using Hospital.Application.Dto.Input.Atendimentos; */
/* using Hospital.Application.UseCases.Atendimentos; */

/* using Microsoft.AspNetCore.Authorization; */
/* using Microsoft.AspNetCore.Mvc; */

/* namespace Hospital.WebApi.Controllers.Retornos; */
/* [ApiController] */
/* [Route("api/Atendimentos/Retorno")] */
/* [Tags("Retorno")] */
/* public class RetornoCreateController : ControllerBase */
/* { */
/*     [HttpPost] */
/*     [Authorize(Policy = PoliciesConsts.Operational)] */
/*     public async Task<IActionResult> Execute( */
/*         [FromServices] RetornoCreateUseCase service, */
/*         [FromQuery] RetornoCreateDto request) */
/*     { */
/*         var result = await service.Handler(request); */
/*         return Ok(result); */
/*     } */
/* } */