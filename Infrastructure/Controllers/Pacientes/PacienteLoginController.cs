/* using Hospital.Dtos.Input.Authentications; */
/* using Hospital.Filter; */
/* using Hospital.Services.Cadastros.Pacientes; */

/* using Microsoft.AspNetCore.Authorization; */
/* using Microsoft.AspNetCore.Mvc; */

/* namespace Hospital.Controllers.Pacientes; */
/* [ApiController] */
/* [Route("api/Paciente")] */
/* [Tags("Paciente")] */
/* public class PacienteLoginController */
/* : ControllerBase */
/* { */
/*     private readonly PacienteLoginService _service; */
/*     public PacienteLoginController( */
/*         PacienteLoginService service) */
/*     { */
/*         _service = service; */
/*     } */

/*     [HttpPost("Login")] */
/*     [AllowAnonymous] */
/*     public async Task<IActionResult> Execute( */
/*         [FromBody] LoginRequestPacienteDto request) */
/*     { */
/*         var token = await _service.Handler(request); */
/*         return Ok(new ResponseDataObject(token)); */
/*     } */
/* } */