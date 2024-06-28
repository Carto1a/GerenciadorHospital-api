/* using Hospital.Application.Dto.Input.Atendimentos; */
/* using Hospital.Application.UseCases.Atendimentos; */

/* using Microsoft.AspNetCore.Authorization; */
/* using Microsoft.AspNetCore.Mvc; */

/* namespace Hospital.WebApi.Controllers.Pacientes; */
/* [ApiController] */
/* [Route("api/Paciente")] */
/* [Tags("Paciente")] */
/* public class PacienteGetConsutasController : ControllerBase */
/* { */
/*     [HttpGet("Consultas")] */
/*     [Authorize(Roles = "PACIENTE")] */
/*     public async Task<IActionResult> Execute( */
/*         [FromServices] ConsultaGetByQueryUseCase service, */
/*         [FromQuery] ConsultaGetByQueryDto query) */
/*     { */
/*         var id = User.Claims.FirstOrDefault(c => c.Type == "ID")?.Value; */
/*         if (id == null) */
/*             return Unauthorized(); */

/*         var newQuery = new ConsultaGetByQueryDto */
/*         { */
/*             PacienteId = Guid.Parse(id), */
/*             ConvenioId = query.ConvenioId, */
/*             MedicoId = query.MedicoId, */
/*             Status = query.Status, */

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