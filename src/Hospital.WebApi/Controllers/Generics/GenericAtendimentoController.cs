/* using Hospital.Dto.Atendimento.Create; */
/* using Hospital.Dto.Atendimento.Get; */
/* using Hospital.Dto.Atendimento.Update; */
/* using Hospital.Extensions; */
/* using Hospital.Models.Agendamentos; */
/* using Hospital.Service.Atendimentos.Interfaces; */

/* using Microsoft.AspNetCore.Authorization; */
/* using Microsoft.AspNetCore.Mvc; */

/* namespace Hospital.Controllers.Generics; */
/* public abstract class GenericAtendimentoController< */
/*     T, */
/*     TAgendamento, */
/*     TCreation, */
/*     TUpdate> */
/* : ControllerBase */
/*     where T : class */
/*     where TAgendamento : Agendamento<T> */
/*     where TCreation : AtendimentoCreationDto */
/*     where TUpdate : AtendimentoUpdateDto */
/* { */
/*     private readonly ILogger<GenericAtendimentoController<T, TAgendamento, TCreation, TUpdate>> _logger; */
/*     private readonly IAtendimentoService< */
/*         T, */
/*         TAgendamento, */
/*         TCreation, */
/*         TUpdate> service; */
/*     public GenericAtendimentoController( */
/*         IAtendimentoService< */
/*             T, */
/*             TAgendamento, */
/*             TCreation, */
/*             TUpdate> service, */
/*         ILogger<GenericAtendimentoController<T, TAgendamento, TCreation, TUpdate>> logger) */
/*     { */
/*         service = service; */
/*         _logger = logger; */
/*         _logger.LogDebug(1, $"NLog injected into GenericAtendimentoController {nameof(T)}"); */
/*     } */

/*     [Authorize(Policy = "OperationalRights")] */
/*     [HttpPost] */
/*     public async Task<IActionResult> Creation( */
/*         [FromForm] TCreation request) */
/*     { */
/*         var response = await service.Create(request); */
/*         var result = response.ToResultDto(); */
/*         if (result.IsFailed) */
/*             return BadRequest(result); */

/*         return Ok(result); */
/*     } */

/*     [Authorize(Policy = "StandardRights")] */
/*     [HttpGet("{id}")] */
/*     public async Task<IActionResult> GetById([FromRoute] Guid id) */
/*     { */
/*         var response = await service.GetById(id); */
/*         var result = response.ToResultDto(); */
/*         if (result.IsFailed) */
/*             return BadRequest(result); */

/*         return Ok(result); */
/*     } */

/*     [Authorize(Policy = "StandardRights")] */
/*     [HttpGet] */
/*     public IActionResult GetByQuery( */
/*         [FromQuery] AtendimentoGetByQueryDto query) */
/*     { */
/*         var response = service.GetByQuery(query); */
/*         var result = response.ToResultDto(); */
/*         if (result.IsFailed) */
/*             return BadRequest(result); */

/*         return Ok(result); */
/*     } */

/*     [Authorize(Policy = "OperationalRights")] */
/*     [HttpPut("{id}")] */
/*     public async Task<IActionResult> Update( */
/*         [FromRoute] Guid id, [FromForm] TUpdate request) */
/*     { */
/*         var response = await service.Update(request, id); */
/*         var result = response.ToResultDto(); */
/*         if (result.IsFailed) */
/*             return BadRequest(result); */

/*         return Ok(result); */
/*     } */
/* } */