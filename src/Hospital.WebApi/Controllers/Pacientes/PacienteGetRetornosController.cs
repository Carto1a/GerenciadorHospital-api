/* using Hospital.Application.Dto.Input.Atendimentos; */
/* using Hospital.Application.UseCases.Atendimentos; */

/* using Microsoft.AspNetCore.Authorization; */
/* using Microsoft.AspNetCore.Mvc; */

/* namespace Hospital.WebApi.Controllers.Pacientes; */
/* [ApiController] */
/* [Route("api/Paciente")] */
/* [Tags("Paciente")] */
/* public class PacienteGetRetornosController : ControllerBase */
/* { */
/*     [HttpGet("Retornos")] */
/*     [Authorize(Roles = "PACIENTE")] */
/*     public async Task<IActionResult> Execute( */
/*         [FromServices] RetornoGetByQueryUseCase service, */
/*         [FromQuery] RetornoGetByQueryDto query) */
/*     { */
/*         var id = User.Claims.FirstOrDefault(c => c.Type == "ID")?.Value; */
/*         if (id == null) */
/*             return Unauthorized(); */

/*         var newQuery = new RetornoGetByQueryDto */
/*         { */
/*             ConsultaId = query.ConsultaId, */
/*             PacienteId = Guid.Parse(id), */
/*             MedicoId = query.MedicoId, */
/*             Status = query.Status, */
/*             ConvenioId = query.ConvenioId, */

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