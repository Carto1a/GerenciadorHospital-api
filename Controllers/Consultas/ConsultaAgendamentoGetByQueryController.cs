using Hospital.Dtos.Input.Agendamentos;
using Hospital.Services.Agendamentos.Consultas;

using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers.Generics.Agendamentos;
[ApiController]
[Route("api/Agendamentos/Consultas")]
[Tags("Agendamentos/Consultas")]
public class ConsultaAgendamentoGetByQueryController
: ControllerBase
{
    private readonly ConsultaAgendamentoGetByQueryService _service;
    public ConsultaAgendamentoGetByQueryController(
        ConsultaAgendamentoGetByQueryService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Execute(
        [FromQuery] AgendamentoGetByQueryDto query)
    {
        var result = await _service.Handler(query);
        return Ok(result);
    }
}