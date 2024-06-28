/* using Hospital.Application.Consts; */
/* using Hospital.Application.Dto.Input.Authentications; */
/* using Hospital.Application.UseCases.Cadastros.Pacientes; */

/* using Microsoft.AspNetCore.Authorization; */
/* using Microsoft.AspNetCore.Mvc; */

/* namespace Hospital.WebApi.Controllers.Pacientes; */
/* [ApiController] */
/* [Route("api/Paciente")] */
/* [Tags("Paciente")] */
/* public class PacienteGetByQueryController : ControllerBase */
/* { */
/*     [HttpGet] */
/*     [Authorize(Policy = PoliciesConsts.Elevated)] */
/*     public async Task<IActionResult> Execute( */
/*         [FromServices] PacienteGetByQueryUseCase service, */
/*         [FromQuery] PacienteGetByQueryDto query) */
/*     { */
/*         var pacientes = await service.Handler(query); */
/*         return Ok(pacientes); */
/*     } */
/* } */