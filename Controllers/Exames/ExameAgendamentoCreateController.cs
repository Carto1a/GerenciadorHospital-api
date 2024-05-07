using Hospital.Dtos.Input.Agendamentos;
using Hospital.Services.Agendamentos.Exames;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers.Exames;
[ApiController]
[Route("api/Agendamentos/Exames")]
[Tags("Agendamentos/Exames")]
public class ExameAgendamentoCreateController
: ControllerBase
{
    private readonly ExameAgendamentoCreateService _service;
    public ExameAgendamentoCreateController(
        ExameAgendamentoCreateService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Execute(
        ExameAgendamentoCreateDto request)
    {
        var result = await _service.Handler(request);
        return Created($"/api/Agendamento/Exame/{result}", result);
    }
}