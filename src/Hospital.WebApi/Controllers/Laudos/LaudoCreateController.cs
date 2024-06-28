/* using Hospital.Application.Dto.Input.Laudos; */
/* using Hospital.Application.UseCases.Laudos; */

/* using Microsoft.AspNetCore.Authorization; */
/* using Microsoft.AspNetCore.Mvc; */

/* namespace Hospital.WebApi.Controllers.Laudos; */
/* [ApiController] */
/* [Route("api/Laudo")] */
/* [Tags("Laudo")] */
/* public class LaudoCreateController : ControllerBase */
/* { */
/*     [HttpPost] */
/*     [Authorize(Roles = "MEDICO")] */
/*     public async Task<IActionResult> Execute( */
/*         [FromServices] LaudoCreateUseCase service, */
/*         [FromBody] LaudoCreateDto request) */
/*     { */
/*         var id = User.Claims.FirstOrDefault(c => c.Type == "ID")?.Value; */
/*         if (id == null) */
/*             return Unauthorized(); */

/*         var result = await service.Handler(request, Guid.Parse(id)); */
/*         return Ok(result); */
/*     } */
/* } */