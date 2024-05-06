using Hospital.Dtos.Input.Agendamentos;
using Hospital.Services.Agendamentos.Consultas;

using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers.Consultas;
[ApiController]
[Route("api/Agendamentos/Consultas")]
[Tags("Agendamentos/Consultas")]
public class ConsultaAgendamentoCreateController
: ControllerBase
{
    private readonly ConsultaAgendamentoCreateService _service;
    public ConsultaAgendamentoCreateController(
        ConsultaAgendamentoCreateService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Execute(
        [FromBody] AgendamentoCreateDto dto)
    {
        var result = await _service.Handler(dto);
        return Ok(result);
    }
}