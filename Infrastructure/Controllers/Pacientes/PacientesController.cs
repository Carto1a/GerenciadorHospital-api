/*     [Authorize(Roles = "Paciente")] */
/*     [HttpGet("Consultas")] */
/*     public async Task<IActionResult> GetConsultas( */
/*         [FromQuery] int limit, int page, Guid? medicoId, */
/*         DateTime? MinDate, DateTime? MaxDate) */
/*     { */
/*         var paciente = User.Claims */
/*             .FirstOrDefault(x => x.Type == "ID")?.Value; */
/*         if (paciente == null) */
/*             return Unauthorized(); */

/*         var response = await _consultaAgendamentoService */
/*             .GetAgendamentosByQuery(new AgendamentoGetByQueryDto */
/*             { */
/*                 PacienteId = new Guid(paciente), */
/*                 MedicoId = medicoId, */
/*                 MinDate = MinDate, */
/*                 MaxDate = MaxDate, */
/*                 Limit = limit, */
/*                 Page = page */
/*             }); */
/*         var result = response.ToResultDto(); */
/*         if (response.IsFailed) */
/*             return NotFound(); */

/*         return Ok(result); */
/*     } */
/*     [Authorize(Roles = "Paciente")] */
/*     [HttpGet("Exames")] */
/*     public async Task<IActionResult> GetExames( */
/*         [FromQuery] int limit, int page, Guid? medicoId, */
/*         DateTime? MinDate, DateTime? MaxDate) */
/*     { */
/*         // TODO: limpar os dados desse negocio ai */
/*         var paciente = User.Claims */
/*             .FirstOrDefault(x => x.Type == "ID")?.Value; */
/*         if (paciente == null) */
/*             return Unauthorized(); */

/*         var response = await _exameAgendamentoService */
/*             .GetAgendamentosByQuery(new AgendamentoGetByQueryDto */
/*             { */
/*                 PacienteId = new Guid(paciente), */
/*                 MedicoId = medicoId, */
/*                 MinDate = MinDate, */
/*                 MaxDate = MaxDate, */
/*                 Limit = limit, */
/*                 Page = page */
/*             }); */
/*         var result = response.ToResultDto(); */
/*         if (response.IsFailed) */
/*             return NotFound(); */

/*         return Ok(result); */
/*     } */
/*     [Authorize(Policy = "ElevatedRights")] */
/*     [HttpGet("Consultas/{pacienteId}")] */
/*     public async Task<IActionResult> GetConsultaById( */
/*         [FromRoute] Guid pacienteId, */
/*         [FromQuery] int? limit, int? page, Guid? medicoId, */
/*         DateTime? MinDate, DateTime? MaxDate) */
/*     { */
/*         var response = await _consultaAgendamentoService */
/*             .GetAgendamentosByQuery(new AgendamentoGetByQueryDto */
/*             { */
/*                 PacienteId = pacienteId, */
/*                 MedicoId = medicoId, */
/*                 MinDate = MinDate, */
/*                 MaxDate = MaxDate, */
/*                 Limit = limit ?? 10, */
/*                 Page = page ?? 0 */
/*             }); */
/*         var result = response.ToResultDto(); */
/*         if (response.IsFailed) */
/*             return NotFound(); */

/*         return Ok(result); */
/*     } */
/*     [Authorize(Policy = "ElevatedRights")] */
/*     [HttpGet("Exames/{pacienteId}")] */
/*     public async Task<IActionResult> GetExameById( */
/*         [FromRoute] Guid pacienteId, */
/*         [FromQuery] int? limit, int? page, Guid? medicoId, */
/*         DateTime? MinDate, DateTime? MaxDate) */
/*     { */
/*         var response = await _exameAgendamentoService */
/*             .GetAgendamentosByQuery(new AgendamentoGetByQueryDto */
/*             { */
/*                 PacienteId = pacienteId, */
/*                 MedicoId = medicoId, */
/*                 MinDate = MinDate, */
/*                 MaxDate = MaxDate, */
/*                 Limit = limit ?? 10, */
/*                 Page = page ?? 0 */
/*             }); */
/*         var result = response.ToResultDto(); */
/*         if (response.IsFailed) */
/*             return NotFound(); */

/*         return Ok(result); */
/*     } */
/* } */