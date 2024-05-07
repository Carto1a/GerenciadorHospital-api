using Hospital.Dtos.Input.Agendamentos;
using Hospital.Services.Agendamentos.Exames;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers.Exames;
public class ExameAgendamentoGetByQueryController
: ControllerBase
{
    private readonly ExameAgendamentoGetByQueryService _service;
    public ExameAgendamentoGetByQueryController(
        ExameAgendamentoGetByQueryService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult Execute(
        ExameAgendamentoGetByQueryDto request)
    {
        var result = _service.Handler(request);
        return Ok(result);
    }
}