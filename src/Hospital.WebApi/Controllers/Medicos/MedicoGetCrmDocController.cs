/* using Hospital.Application.UseCases.Cadastros.Medicos; */

/* using Microsoft.AspNetCore.Authorization; */
/* using Microsoft.AspNetCore.Mvc; */

/* namespace Hospital.WebApi.Controllers.Medicos; */
/* [ApiController] */
/* [Route("api/Medico")] */
/* [Tags("Medico")] */
/* public class MedicoGetCrmDocController : ControllerBase */
/* { */
/*     [HttpGet("CrmDoc")] */
/*     [Authorize(Roles = "MEDICO")] */
/*     public async Task<IActionResult> Execute( */
/*         [FromServices] MedicoGetDocCrmUseCase service) */
/*     { */
/*         var id = User.Claims.FirstOrDefault(c => c.Type == "ID")?.Value; */
/*         if (id == null) */
/*             return Unauthorized(); */

/*         var medicos = await service.Handler(Guid.Parse(id)); */
/*         return File(medicos, "image/png"); */
/*     } */
/* } */