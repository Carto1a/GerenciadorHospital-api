/* using Hospital.Application.Consts; */
/* using Hospital.Application.UseCases.Cadastros.Pacientes; */

/* using Microsoft.AspNetCore.Authorization; */
/* using Microsoft.AspNetCore.Mvc; */

/* namespace Hospital.WebApi.Controllers.Pacientes; */
/* [ApiController] */
/* [Route("api/Paciente")] */
/* [Tags("Paciente")] */
/* public class PacienteAddDocConvenioController : ControllerBase */
/* { */
/*     [HttpPost("Documentos/Convenio/{id}")] */
/*     [Authorize(Policy = PoliciesConsts.Elevated)] */
/*     public async Task<IActionResult> Execute( */
/*         [FromServices] PacienteAddDocConvenioUseCase service, */
/*         [FromRoute] Guid id, */
/*         [FromForm] IFormFile file) */
/*     { */
/*         var imageId = await service.Handler(id, file.OpenReadStream()); */
/*         return Ok(imageId); */
/*     } */
/* } */