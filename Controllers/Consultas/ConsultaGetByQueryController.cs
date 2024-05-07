using Hospital.Dtos.Input.Atendimentos;
using Hospital.Services.Atendimentos.Consultas;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers.Consultas;
[ApiController]
[Route("api/Atendimentos/Consultas")]
[Tags("Consultas")]
public class ConsultaGetByQueryController
: ControllerBase
{
    private readonly ConsultaGetByQueryService _service;
    public ConsultaGetByQueryController(
        ConsultaGetByQueryService service)
    {
        _service = service;
    }

    [HttpGet]
    public ActionResult Get(
        [FromQuery] AtendimentoGetByQueryDto query)
    {
        var result = _service.Handler(query);
        return Ok(result);
    }
}