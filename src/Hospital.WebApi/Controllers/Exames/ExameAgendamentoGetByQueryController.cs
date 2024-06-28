/* using Hospital.Application.Consts; */
/* using Hospital.Application.Dto.Input.Agendamentos; */
/* using Hospital.Application.UseCases.Agendamentos; */

/* using Microsoft.AspNetCore.Authorization; */
/* using Microsoft.AspNetCore.Mvc; */

/* namespace Hospital.WebApi.Controllers.Exames; */
/* [ApiController] */
/* [Route("api/Agendamento/Exame")] */
/* [Tags("Agendamento Exame")] */
/* public class ExameAgendamentoGetByQueryController : ControllerBase */
/* { */
/*     [HttpGet] */
/*     [Authorize(Policy = PoliciesConsts.Operational)] */
/*     public async Task<IActionResult> Execute( */
/*         [FromServices] AgendamentoExameGetByQueryUseCase service, */
/*         [FromQuery] AgendamentoExameGetByQuery query) */
/*     { */
/*         var response = await service.Handler(query); */
/*         return Ok(response); */
/*     } */
/* } */