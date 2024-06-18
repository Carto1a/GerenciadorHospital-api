/* using Hospital.Application.UseCases.Agendamentos; */
/* using Hospital.Consts; */
/* using Hospital.Dtos.Input.Agendamentos; */
/* using Hospital.Services.Agendamentos; */

/* using Microsoft.AspNetCore.Authorization; */
/* using Microsoft.AspNetCore.Mvc; */

/* namespace Hospital.Controllers.Consultas; */

/* [ApiController] */
/* [Route("api/Agendamento/Retorno")] */
/* public class RetornoAgendamentoController : ControllerBase */
/* { */
/*     [HttpPost] */
/*     [Authorize(Policy = PoliciesConsts.Operational)] */
/*     public async Task<IActionResult> PostAgendamento( */
/*         [FromServices] AgendamentoRetornoCreateService _service, */
/*         [FromBody] AgendamentoRetornoCreateDto request) */
/*     { */
/*         var response = await _service.Handler(request); */
/*         return Ok(response); */
/*     } */

/*     [HttpPost("EmEspera/{id}")] */
/*     [Authorize(Policy = PoliciesConsts.Operational)] */
/*     public async Task<IActionResult> EmEspera( */
/*         [FromServices] AgendamentoExameEmEsperaService _service, */
/*         [FromRoute] Guid id) */
/*     { */
/*         await _service.Handler(id); */
/*         return Ok(); */
/*     } */

/*     [HttpGet] */
/*     [Authorize(Policy = PoliciesConsts.Elevated)] */
/*     public async Task<IActionResult> GetByQuery( */
/*         [FromServices] AgendamentoRetornoGetByQueryService _service, */
/*         [FromQuery] AgendamentoGetByQueryDto request) */
/*     { */
/*         var response = await _service.Handler(request); */
/*         return Ok(response); */
/*     } */

/*     /1* [HttpGet("{id}")] *1/ */
/*     /1* [Authorize(Policy = PoliciesConsts.Operational)] *1/ */
/*     /1* public async Task<IActionResult> GetById( *1/ */
/*     /1*     [FromRoute] Guid id) *1/ */
/*     /1* { *1/ */
/*     /1*     var response = await _service.Handler(id); *1/ */
/*     /1*     return Ok(response); *1/ */
/*     /1* } *1/ */

/*     /1* [HttpPut("{id}")] *1/ */
/*     /1* [Authorize(Policy = PoliciesConsts.Operational)] *1/ */
/*     /1* public async Task<IActionResult> Update( *1/ */
/*     /1*     [FromRoute] Guid id, *1/ */
/*     /1*     [FromForm] AgendamentoUpdateDto request) *1/ */
/*     /1* { *1/ */
/*     /1*     var response = await _service.Handler(request, id); *1/ */
/*     /1*     return Ok(response); *1/ */
/*     /1* } *1/ */

/*     /1* [HttpDelete("{id}")] *1/ */
/*     /1* [Authorize(Policy = PoliciesConsts.Operational)] *1/ */
/*     /1* public async Task<IActionResult> CancelAgendamento( *1/ */
/*     /1*     [FromRoute] Guid id) *1/ */
/*     /1* { *1/ */
/*     /1*     var response = await _service.Handler(id); *1/ */
/*     /1*     return Ok(result); *1/ */
/*     /1* } *1/ */
/* } */