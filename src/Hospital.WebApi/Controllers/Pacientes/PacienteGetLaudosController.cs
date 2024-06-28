/* using Hospital.Application.Dto.Input.Laudos; */
/* using Hospital.Application.UseCases.Laudos; */

/* using Microsoft.AspNetCore.Authorization; */
/* using Microsoft.AspNetCore.Mvc; */

/* namespace Hospital.WebApi.Controllers.Pacientes; */
/* [ApiController] */
/* [Route("api/Paciente")] */
/* [Tags("Paciente")] */
/* public class PacienteGetLaudosController : ControllerBase */
/* { */
/*     [HttpGet("Laudos")] */
/*     [Authorize(Roles = "PACIENTE")] */
/*     public async Task<IActionResult> Execute( */
/*         [FromServices] LaudoGetByQueryUseCase service, */
/*         [FromQuery] LaudoGetByQueryDto query) */
/*     { */
/*         var id = User.Claims.FirstOrDefault(c => c.Type == "ID")?.Value; */
/*         if (id == null) */
/*             return Unauthorized(); */

/*         var newQuery = new LaudoGetByQueryDto */
/*         { */
/*             ExameId = query.ExameId, */
/*             ConsultaId = query.ConsultaId, */
/*             PacienteId = Guid.Parse(id), */
/*             MedicoId = query.MedicoId, */

/*             Page = query.Page, */
/*             Limit = query.Limit, */
/*             MaxDateCriado = query.MaxDateCriado, */
/*             MinDateCriado = query.MinDateCriado, */
/*             Ativo = query.Ativo, */
/*         }; */

/*         var pacientes = await service.Handler(newQuery); */
/*         return Ok(pacientes); */
/*     } */
/* } */