/* using Hospital.Application.Consts; */
/* using Hospital.Application.UseCases.Agendamentos; */

/* using Microsoft.AspNetCore.Authorization; */
/* using Microsoft.AspNetCore.Mvc; */

/* namespace Hospital.WebApi.Controllers.Exames; */
/* [ApiController] */
/* [Route("api/Agendamento/Exame")] */
/* [Tags("Agendamento Exame")] */
/* public class ExameAgendamentoGetByIdController : ControllerBase */
/* { */
/*     [HttpGet("{id}")] */
/*     [Authorize(Policy = PoliciesConsts.Operational)] */
/*     public async Task<IActionResult> Execute( */
/*         [FromServices] AgendamentoExameGetByIdUseCase service, */
/*         [FromRoute] Guid id) */
/*     { */
/*         var response = await service.Handler(id); */
/*         return Ok(response); */
/*     } */
/* } */