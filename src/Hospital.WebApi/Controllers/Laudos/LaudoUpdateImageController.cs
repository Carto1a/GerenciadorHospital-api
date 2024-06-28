/* using Hospital.Application.Consts; */
/* using Hospital.Application.UseCases.Laudos; */

/* using Microsoft.AspNetCore.Authorization; */
/* using Microsoft.AspNetCore.Mvc; */

/* namespace Hospital.WebApi.Controllers.Laudos; */
/* [ApiController] */
/* [Route("api/Laudo")] */
/* [Tags("Laudo")] */
/* public class LaudoUpdateImageController : ControllerBase */
/* { */
/*     [HttpPatch("Imagem/{id}")] */
/*     [Authorize(Policy = PoliciesConsts.Operational)] */
/*     public async Task<IActionResult> Execute( */
/*         [FromServices] LaudoAddImageUseCase service, */
/*         [FromRoute] Guid id, */
/*         [FromForm] IFormFile file) */
/*     { */
/*         await service.Handler(id, file); */
/*         return Ok(); */
/*     } */
/* } */