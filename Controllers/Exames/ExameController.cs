using Hospital.Consts;
using Hospital.Dtos.Input.Atendimentos;
using Hospital.Services.Atendimentos;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers.Consultas;
[ApiController]
[Route("api/Atendimentos/Exame")]
public class ExameController : ControllerBase
{
    [HttpGet]
    [Authorize(Policy = PoliciesConsts.Operational)]
    public IActionResult Create(
        [FromServices] ExameCreateService service,
        [FromQuery] ExameCreateDto request)
    {
        var result = service.Handler(request);
        return Ok(result);
    }
}