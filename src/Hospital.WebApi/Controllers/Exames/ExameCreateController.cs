/* using Hospital.Application.Consts; */
/* using Hospital.Application.Dto.Input.Atendimentos; */
/* using Hospital.Application.UseCases.Atendimentos; */

/* using Microsoft.AspNetCore.Authorization; */
/* using Microsoft.AspNetCore.Mvc; */

/* namespace Hospital.WebApi.Controllers.Exames; */
/* [ApiController] */
/* [Route("api/Atendimentos/Exame")] */
/* [Tags("Exame")] */
/* public class ExameCreateController : ControllerBase */
/* { */
/*     [HttpPost] */
/*     [Authorize(Policy = PoliciesConsts.Operational)] */
/*     public async Task<IActionResult> Create( */
/*         [FromServices] ExameCreateUseCase service, */
/*         [FromQuery] ExameCreateDto request) */
/*     { */
/*         var result = await service.Handler(request); */
/*         return Ok(result); */
/*     } */
/* } */