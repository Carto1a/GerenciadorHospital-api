/* using Hospital.Application.Consts; */
/* using Hospital.Application.Dto.Input.Atendimentos; */
/* using Hospital.Application.UseCases.Atendimentos; */

/* using Microsoft.AspNetCore.Authorization; */
/* using Microsoft.AspNetCore.Mvc; */

/* namespace Hospital.WebApi.Controllers.Consultas; */
/* [ApiController] */
/* [Route("api/Atendimentos/Consulta")] */
/* [Tags("Consulta")] */
/* public class ConsultaCreateController : ControllerBase */
/* { */
/*     [HttpPost] */
/*     [Authorize(Policy = PoliciesConsts.Operational)] */
/*     public async Task<IActionResult> Execute( */
/*         [FromServices] ConsultaCreateUseCase service, */
/*         [FromBody] ConsultaCreateDto request) */
/*     { */
/*         var response = await service.Handler(request); */
/*         return Ok(response); */
/*     } */
/* } */