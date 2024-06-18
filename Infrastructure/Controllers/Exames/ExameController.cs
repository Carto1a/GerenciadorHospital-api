/* using Hospital.Application.UseCases.Atendimentos; */
/* using Hospital.Consts; */
/* using Hospital.Dtos.Input.Atendimentos; */
/* using Hospital.Services.Atendimentos; */

/* using Microsoft.AspNetCore.Authorization; */
/* using Microsoft.AspNetCore.Mvc; */

/* namespace Hospital.Controllers.Consultas; */
/* [ApiController] */
/* [Route("api/Atendimentos/Exame")] */
/* public class ExameController : ControllerBase */
/* { */
/*     [HttpPost] */
/*     [Authorize(Policy = PoliciesConsts.Operational)] */
/*     public async Task<IActionResult> Create( */
/*         [FromServices] ExameCreateService service, */
/*         [FromQuery] ExameCreateDto request) */
/*     { */
/*         var result = await service.Handler(request); */
/*         return Ok(result); */
/*     } */
/* } */