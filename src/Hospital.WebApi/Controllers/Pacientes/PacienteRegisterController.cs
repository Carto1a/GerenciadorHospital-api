/* using Hospital.Application.Consts; */
/* using Hospital.Application.Dto.Input.Authentications; */
/* using Hospital.Application.UseCases.Cadastros.Pacientes; */
/* using Hospital.WebApi.Filter; */

/* using Microsoft.AspNetCore.Authorization; */
/* using Microsoft.AspNetCore.Mvc; */

/* namespace Hospital.WebApi.Controllers.Pacientes; */
/* [ApiController] */
/* [Route("api/Paciente")] */
/* [Tags("Paciente")] */
/* public class PacienteRegisterController : ControllerBase */
/* { */
/*     [HttpPost("Cadastro")] */
/*     [Authorize(Policy = PoliciesConsts.Operational)] */
/*     public async Task<IActionResult> Execute( */
/*         [FromServices] PacienteRegisterUseCase service, */
/*         [FromForm] RegisterRequestPacienteDto request) */
/*     { */
/*         var uri = await service.Handler(request); */
/*         return Created("", new ResponseDataObject(uri)); */
/*     } */
/* } */