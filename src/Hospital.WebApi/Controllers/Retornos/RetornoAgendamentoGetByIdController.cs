/* using Hospital.Application.Consts; */
/* using Hospital.Application.UseCases.Agendamentos; */

/* using Microsoft.AspNetCore.Authorization; */
/* using Microsoft.AspNetCore.Mvc; */

/* namespace Hospital.WebApi.Controllers.Retornos; */
/* [ApiController] */
/* [Route("api/Agendamento/Retorno")] */
/* [Tags("Agendamento Retorno")] */
/* public class RetornoAgendamentoGetByIdController : ControllerBase */
/* { */
/*     [HttpGet("{id}")] */
/*     [Authorize(Policy = PoliciesConsts.Operational)] */
/*     public async Task<IActionResult> Execute( */
/*         [FromServices] AgendamentoRetornoGetByIdUseCase service, */
/*         [FromRoute] Guid id) */
/*     { */
/*         var response = await service.Handler(id); */
/*         return Ok(response); */
/*     } */
/* } */