using Hospital.Consts;
using Hospital.Dtos.Input.Atendimentos;
using Hospital.Services.Atendimentos;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers.Consultas;
[ApiController]
[Route("api/Atendimentos/Consulta")]
public class ConsultaController : ControllerBase
{
    [HttpGet]
    [Authorize(Policy = PoliciesConsts.Operational)]
    public IActionResult Create(
        [FromServices] ConsultaCreateService service,
        [FromQuery] ConsultaCreateDto request)
    {
        var result = service.Handler(request);
        return Ok(result);
    }
}