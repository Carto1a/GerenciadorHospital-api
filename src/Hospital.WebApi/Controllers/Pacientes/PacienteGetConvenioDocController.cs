/* using Hospital.Application.UseCases.Cadastros.Pacientes; */

/* using Microsoft.AspNetCore.Authorization; */
/* using Microsoft.AspNetCore.Mvc; */

/* namespace Hospital.WebApi.Controllers.Pacientes; */
/* [ApiController] */
/* [Route("api/Paciente")] */
/* [Tags("Paciente")] */
/* public class PacienteGetConvenioDocController : ControllerBase */
/* { */
/*     [HttpGet("Documentos/Convenio")] */
/*     [Authorize(Roles = "PACIENTE")] */
/*     public async Task<IActionResult> Execute( */
/*         [FromServices] PacienteGetDocConvenioUseCase service) */
/*     { */
/*         var id = User.Claims.FirstOrDefault(c => c.Type == "ID")?.Value; */
/*         if (id == null) */
/*             return Unauthorized(); */

/*         var imagePath = await service.Handler(Guid.Parse(id)); */
/*         return File(imagePath, "image/png"); */
/*     } */
/* } */