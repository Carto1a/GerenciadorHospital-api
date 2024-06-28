/* using Hospital.Application.Consts; */
/* using Hospital.Application.Dto.Input.Authentications; */
/* using Hospital.Application.UseCases.Cadastros.Medicos; */

/* using Microsoft.AspNetCore.Authorization; */
/* using Microsoft.AspNetCore.Mvc; */

/* namespace Hospital.WebApi.Controllers.Medicos; */
/* [ApiController] */
/* [Route("api/Medico")] */
/* [Tags("Medico")] */
/* public class MedicoGetByQueryController : ControllerBase */
/* { */
/*     [HttpGet] */
/*     [Authorize(Policy = PoliciesConsts.Elevated)] */
/*     public async Task<IActionResult> Execute( */
/*         [FromServices] MedicoGetByQueryUseCase service, */
/*         [FromQuery] MedicoGetByQueryDto query) */
/*     { */
/*         var medicos = await service.Handler(query); */
/*         return Ok(medicos); */
/*     } */
/* } */