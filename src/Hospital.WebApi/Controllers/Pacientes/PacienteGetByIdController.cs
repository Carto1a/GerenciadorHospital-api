/* using Hospital.Application.Consts; */
/* using Hospital.Application.UseCases.Cadastros.Pacientes; */
/* using Hospital.WebApi.Filter; */

/* using Microsoft.AspNetCore.Authorization; */
/* using Microsoft.AspNetCore.Mvc; */

/* namespace Hospital.WebApi.Controllers.Pacientes; */
/* [ApiController] */
/* [Route("api/Paciente")] */
/* [Tags("Paciente")] */
/* public class PacienteGetByIdController */
/* : ControllerBase */
/* { */
/*     [HttpGet("{id}")] */
/*     [Authorize(Policy = PoliciesConsts.Operational)] */
/*     public async Task<IActionResult> Execute( */
/*         [FromServices] PacienteGetByIdUseCase service, */
/*         [FromRoute] Guid id) */
/*     { */
/*         var paciente = await service.Handler(id); */
/*         var response = new ResponseDataObject(paciente); */
/*         return Ok(response); */
/*     } */
/* } */