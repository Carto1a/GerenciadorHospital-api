using Hospital.Application.Consts;
using Hospital.Application.UseCases.Atendimentos;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Infrastructure.Controllers.Retornos;
[ApiController]
[Route("api/Atendimentos/Retorno")]
[Tags("Retorno")]
public class RetornoGetByIdController : ControllerBase
{
    [HttpGet("{id}")]
    [Authorize(Policy = PoliciesConsts.Operational)]
    public async Task<IActionResult> Execute(
        [FromServices] RetornoGetByIdUseCase service,
        [FromRoute] Guid id)
    {
        var result = await service.Handler(id);
        return Ok(result);
    }
}