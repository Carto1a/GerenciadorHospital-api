using Hospital.Consts;
using Hospital.Dtos.Input.Atendimentos;
using Hospital.Services.Atendimentos;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers.Consultas;
[ApiController]
[Route("api/Atendimentos/Retorno")]
public class RetornoController : ControllerBase
{
    [HttpGet]
    [Authorize(Policy = PoliciesConsts.Operational)]
    public IActionResult Create(
        [FromServices] RetornoCreateService service,
        [FromQuery] RetornoCreateDto request)
    {
        var result = service.Handler(request);
        return Ok(result);
    }
}