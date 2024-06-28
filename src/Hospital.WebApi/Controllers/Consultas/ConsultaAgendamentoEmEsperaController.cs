/* using Hospital.Application.Consts; */
/* using Hospital.Application.UseCases.Agendamentos; */

/* using Microsoft.AspNetCore.Authorization; */
/* using Microsoft.AspNetCore.Mvc; */

/* namespace Hospital.WebApi.Controllers.Consultas; */
/* [ApiController] */
/* [Route("api/Agendamento/Consulta")] */
/* [Tags("Agendamento Consulta")] */
/* public class ConsultaAgendamentoEmEsperaController : ControllerBase */
/* { */
/*     [HttpPatch("EmEspera/{id}")] */
/*     [Authorize(Policy = PoliciesConsts.Operational)] */
/*     public async Task<IActionResult> Execute( */
/*         [FromServices] AgendamentoConsultaEmEsperaUseCase service, */
/*         [FromRoute] Guid id) */
/*     { */
/*         await service.Handler(id); */
/*         return Ok(); */
/*     } */
/* } */