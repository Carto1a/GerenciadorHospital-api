/* using Hospital.Application.Consts; */
/* using Hospital.Application.Dto.Input.Agendamentos; */
/* using Hospital.Application.UseCases.Agendamentos; */

/* using Microsoft.AspNetCore.Authorization; */
/* using Microsoft.AspNetCore.Mvc; */

/* namespace Hospital.WebApi.Controllers.Consultas; */
/* [ApiController] */
/* [Route("api/Agendamento/Consulta")] */
/* [Tags("Agendamento Consulta")] */
/* public class ConsultaAgendamentoGetByQueryController : ControllerBase */
/* { */
/*     [HttpGet] */
/*     [Authorize(Policy = PoliciesConsts.Operational)] */
/*     public async Task<IActionResult> Execute( */
/*         [FromServices] AgendamentoConsultaGetByQueryUseCase service, */
/*         [FromQuery] AgendamentoConsultaGetByQuery query) */
/*     { */
/*         var result = await service.Handler(query); */
/*         return Ok(result); */
/*     } */
/* } */