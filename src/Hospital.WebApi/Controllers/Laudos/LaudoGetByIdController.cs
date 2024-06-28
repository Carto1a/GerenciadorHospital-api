/* using Hospital.Application.Consts; */
/* using Hospital.Application.UseCases.Laudos; */

/* using Microsoft.AspNetCore.Authorization; */
/* using Microsoft.AspNetCore.Mvc; */

/* namespace Hospital.WebApi.Controllers.Laudos; */
/* [ApiController] */
/* [Route("api/Laudo")] */
/* [Tags("Laudo")] */
/* public class LaudoGetByIdController : ControllerBase */
/* { */
/*     [HttpGet("{id}")] */
/*     [Authorize(Policy = PoliciesConsts.Operational)] */
/*     public async Task<IActionResult> Execute( */
/*         [FromServices] LaudoGetByIdUseCase service, */
/*         [FromRoute] Guid id) */
/*     { */
/*         var result = await service.Handler(id); */
/*         return Ok(result); */
/*     } */
/* } */