/* using Hospital.Application.Consts; */
/* using Hospital.Application.UseCases.Agendamentos; */

/* using Microsoft.AspNetCore.Authorization; */
/* using Microsoft.AspNetCore.Mvc; */

/* namespace Hospital.WebApi.Controllers.Exames; */
/* [ApiController] */
/* [Route("api/Agendamento/Exame")] */
/* [Tags("Agendamento Exame")] */
/* public class ExameAgendamentoEmEsperaController : ControllerBase */
/* { */
/*     [HttpPatch("EmEspera/{id}")] */
/*     [Authorize(Policy = PoliciesConsts.Operational)] */
/*     public async Task<IActionResult> Execute( */
/*         [FromServices] AgendamentoExameEmEsperaUseCase service, */
/*         [FromRoute] Guid id) */
/*     { */
/*         await service.Handler(id); */
/*         return Ok(); */
/*     } */
/* } */