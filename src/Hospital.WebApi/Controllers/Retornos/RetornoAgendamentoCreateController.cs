/* using Hospital.Application.Consts; */
/* using Hospital.Application.Dto.Input.Agendamentos; */
/* using Hospital.Application.UseCases.Agendamentos; */

/* using Microsoft.AspNetCore.Authorization; */
/* using Microsoft.AspNetCore.Mvc; */

/* namespace Hospital.WebApi.Controllers.Retornos; */
/* [ApiController] */
/* [Route("api/Agendamento/Retorno")] */
/* [Tags("Agendamento Retorno")] */
/* public class RetornoAgendamentoCreateController : ControllerBase */
/* { */
/*     [HttpPost] */
/*     [Authorize(Policy = PoliciesConsts.Operational)] */
/*     public async Task<IActionResult> Execute( */
/*         [FromServices] AgendamentoRetornoCreateUseCase service, */
/*         [FromBody] AgendamentoRetornoCreateDto request) */
/*     { */
/*         var response = await service.Handler(request); */
/*         return Ok(response); */
/*     } */
/* } */