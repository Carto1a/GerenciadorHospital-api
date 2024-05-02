using Hospital.Dtos.Input.Convenios;
using Hospital.Services.Convenios;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers.Convenios;
[ApiController]
[Route("api/Convenio")]
[Tags("Convenio")]
public class ConvenioGetByQueryController
: ControllerBase
{
    private readonly ConvenioGetByQueryService _service;
    public ConvenioGetByQueryController(
        ConvenioGetByQueryService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult Execute(
        [FromQuery] ConvenioGetByQueryDto query)
    {
        var convenios = _service.Handler(query);
        return Ok(convenios);
    }
}