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
    [HttpPost]
    [Authorize(Policy = PoliciesConsts.Operational)]
    public async Task<IActionResult> Create(
        [FromServices] RetornoCreateService service,
        [FromQuery] RetornoCreateDto request)
    {
        var result = await service.Handler(request);
        return Ok(result);
    }
}