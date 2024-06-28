/* using Hospital.Application.Dto.Input.Authentications; */
/* using Hospital.Application.UseCases.Cadastros.Pacientes; */
/* using Hospital.WebApi.Filter; */

/* using Microsoft.AspNetCore.Authorization; */
/* using Microsoft.AspNetCore.Mvc; */

/* namespace Hospital.WebApi.Controllers.Pacientes; */
/* [ApiController] */
/* [Route("api/Paciente")] */
/* [Tags("Paciente")] */
/* public class PacienteLoginController : ControllerBase */
/* { */
/*     [HttpPost("Login")] */
/*     [AllowAnonymous] */
/*     public async Task<IActionResult> Execute( */
/*         [FromServices] PacienteLoginUseCase service, */
/*         [FromBody] LoginRequestPacienteDto request) */
/*     { */
/*         var token = await service.Handler(request); */
/*         return Ok(new ResponseDataObject(token)); */
/*     } */
/* } */