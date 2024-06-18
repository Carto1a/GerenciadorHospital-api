/* using Hospital.Dtos.Input.Agendamentos; */
/* using Hospital.Models.Agendamentos; */
/* using Hospital.Models.Atendimento; */
/* using Hospital.Services.Agendamentos; */
/* using Microsoft.AspNetCore.Mvc; */

/* namespace Hospital.Controllers.Generics.Agendamentos; */
/* public class GenericAgendamentoGetByQueryController< */
/*     T, */
/*     TAgendamento, */
/*     TQuery> */
/* : ControllerBase */
/* where T : Atendimento, new() */
/* where TAgendamento : Agendamento, new() */
/* where TQuery : AgendamentoGetByQueryDto */
/* { */
/*     private readonly AgendamentoConsultaGetByQueryService< */
/*         T, */
/*         TAgendamento, */
/*         TQuery> _service; */
/*     public GenericAgendamentoGetByQueryController( */
/*         AgendamentoConsultaGetByQueryService< */
/*             T, */
/*             TAgendamento, */
/*             TQuery> service) */
/*     { */
/*         _service = service; */
/*     } */

/*     [HttpGet] */
/*     public async Task<IActionResult> Execute( */
/*         [FromQuery] TQuery query) */
/*     { */
/*         var result = await _service.Handler(query); */
/*         return Ok(result); */
/*     } */
/* } */