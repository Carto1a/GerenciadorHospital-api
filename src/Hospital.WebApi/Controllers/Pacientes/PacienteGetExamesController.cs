using Hospital.Application.Dto.Input.Atendimentos;
using Hospital.Application.UseCases.Atendimentos;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Infrastructure.Controllers.Pacientes;
[ApiController]
[Route("api/Paciente")]
[Tags("Paciente")]
public class PacienteGetExamesController : ControllerBase
{
    [HttpGet("Exames")]
    [Authorize(Roles = "PACIENTE")]
    public async Task<IActionResult> Execute(
        [FromServices] ExameGetByQueryUseCase _service,
        [FromQuery] ExameGetByQueryDto query)
    {
        var id = User.Claims.FirstOrDefault(c => c.Type == "ID")?.Value;
        if (id == null)
            return Unauthorized();

        var newQuery = new ExameGetByQueryDto
        {
            PacienteId = Guid.Parse(id),
            ConvenioId = query.ConvenioId,
            MedicoId = query.MedicoId,
            ConsultaId = query.ConsultaId,
            Status = query.Status,

            Page = query.Page,
            Limit = query.Limit,
            MaxDateCriado = query.MaxDateCriado,
            MinDateCriado = query.MinDateCriado,
            Ativo = query.Ativo,
        };

        var pacientes = await _service.Handler(newQuery);
        return Ok(pacientes);
    }
}