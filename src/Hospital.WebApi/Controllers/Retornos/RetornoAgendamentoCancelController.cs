/* using Hospital.Application.Consts; */
/* using Hospital.Application.UseCases.Agendamentos; */

/* using Microsoft.AspNetCore.Authorization; */
/* using Microsoft.AspNetCore.Mvc; */

/* namespace Hospital.WebApi.Controllers.Retornos; */
/* [ApiController] */
/* [Route("api/Agendamento/Retorno")] */
/* [Tags("Agendamento Retorno")] */
/* public class RetornoAgendamentoCancelController : ControllerBase */
/* { */
/*     [HttpPatch("Cancelar/{Id}")] */
/*     [Authorize(Policy = PoliciesConsts.Operational)] */
/*     public async Task<IActionResult> Execute( */
/*         [FromServices] AgendamentoRetornoCancelUseCase service, */
/*         [FromRoute] Guid id) */
/*     { */
/*         await service.Handler(id); */
/*         return Ok(); */
/*     } */
/* } */