/* using Hospital.Application.Consts; */
/* using Hospital.Application.UseCases.Cadastros.Medicos; */

/* using Microsoft.AspNetCore.Authorization; */
/* using Microsoft.AspNetCore.Mvc; */

/* namespace Hospital.WebApi.Controllers.Medicos; */
/* [ApiController] */
/* [Route("api/Medico")] */
/* [Tags("Medico")] */
/* public class MedicoAddCrmDocController : ControllerBase */
/* { */
/*     [HttpPost("CrmDoc/{id}")] */
/*     [Authorize(Policy = PoliciesConsts.Operational)] */
/*     public async Task<IActionResult> Execute( */
/*         [FromServices] MedicoGetDocCrmUseCase service, */
/*         [FromRoute] Guid id) */
/*     { */
/*         var medicos = await service.Handler(id); */
/*         return File(medicos, "image/png"); */
/*     } */
/* } */