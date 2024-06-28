/* using Hospital.Application.Consts; */
/* using Hospital.Application.UseCases.Atendimentos; */

/* using Microsoft.AspNetCore.Authorization; */
/* using Microsoft.AspNetCore.Mvc; */

/* namespace Hospital.WebApi.Controllers.Consultas; */
/* [ApiController] */
/* [Route("api/Atendimentos/Consulta")] */
/* [Tags("Consulta")] */
/* public class ConsultaGetByIdController : ControllerBase */
/* { */
/*     [HttpGet("{id}")] */
/*     [Authorize(Policy = PoliciesConsts.Operational)] */
/*     public async Task<IActionResult> Execute( */
/*         [FromServices] ConsultaGetByIdUseCase service, */
/*         [FromRoute] Guid id) */
/*     { */
/*         var response = await service.Handler(id); */
/*         return Ok(response); */
/*     } */
/* } */