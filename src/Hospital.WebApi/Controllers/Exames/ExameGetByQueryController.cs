using Hospital.Application.Consts;
using Hospital.Application.Dto.Input.Atendimentos;
using Hospital.Application.UseCases.Atendimentos;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Infrastructure.Controllers.Exames;
[ApiController]
[Route("api/Atendimentos/Exame")]
[Tags("Exame")]
public class ExameGetByQueryController : ControllerBase
{
    [HttpGet]
    [Authorize(Policy = PoliciesConsts.Operational)]
    public async Task<IActionResult> Execute(
        [FromServices] ExameGetByQueryUseCase service,
        [FromQuery] ExameGetByQueryDto query)
    {
        var result = await service.Handler(query);
        return Ok(result);
    }
}