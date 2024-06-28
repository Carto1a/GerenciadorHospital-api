/* using Hospital.Application.Consts; */
/* using Hospital.Application.UseCases.Agendamentos; */

/* using Microsoft.AspNetCore.Authorization; */
/* using Microsoft.AspNetCore.Mvc; */

/* namespace Hospital.WebApi.Controllers.Retornos; */
/* [ApiController] */
/* [Route("api/Agendamento/Retorno")] */
/* [Tags("Agendamento Retorno")] */
/* public class RetornoAgendamentoEmEsperaController : ControllerBase */
/* { */
/*     [HttpPatch("EmEspera/{id}")] */
/*     [Authorize(Policy = PoliciesConsts.Operational)] */
/*     public async Task<IActionResult> Execute( */
/*         [FromServices] AgendamentoRetornoEmEsperaUseCase service, */
/*         [FromRoute] Guid id) */
/*     { */
/*         await service.Handler(id); */
/*         return Ok(); */
/*     } */
/* } */