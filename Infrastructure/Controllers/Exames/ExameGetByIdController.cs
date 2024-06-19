using Hospital.Application.Consts;
using Hospital.Application.UseCases.Atendimentos;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Infrastructure.Controllers.Exames;
[ApiController]
[Route("api/Atendimentos/Exame")]
[Tags("Exame")]
public class ExameGetByIdController : ControllerBase
{
    [HttpGet("{id}")]
    [Authorize(Policy = PoliciesConsts.Operational)]
    public async Task<IActionResult> Create(
        [FromServices] ExameGetByIdUseCase service,
        [FromRoute] Guid id)
    {
        var result = await service.Handler(id);
        return Ok(result);
    }
}