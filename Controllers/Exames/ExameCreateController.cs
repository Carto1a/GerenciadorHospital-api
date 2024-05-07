using Hospital.Dtos.Input.Atendimentos;
using Hospital.Services.Atendimentos.Exames;

using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers.Exames;
[ApiController]
[Route("api/Atendimentos/Exames")]
[Tags("Exames")]
public class ExameCreateController
: ControllerBase
{
    private readonly ExameCreateService _service;
    public ExameCreateController(
        ExameCreateService service)
    {
        _service = service;
    }

    [HttpPost]
    public IActionResult Execute(
        [FromForm] ExameCreateDto request)
    {
        var result = _service.Handler(request);
        return Ok(result);
    }
}