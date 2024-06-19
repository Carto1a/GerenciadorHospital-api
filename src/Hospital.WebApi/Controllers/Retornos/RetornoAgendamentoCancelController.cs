using Hospital.Application.Consts;
using Hospital.Application.UseCases.Agendamentos;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Infrastructure.Controllers.Retornos;
[ApiController]
[Route("api/Agendamento/Retorno")]
[Tags("Agendamento Retorno")]
public class RetornoAgendamentoCancelController : ControllerBase
{
    [HttpPatch("Cancelar/{Id}")]
    [Authorize(Policy = PoliciesConsts.Operational)]
    public async Task<IActionResult> Execute(
        [FromServices] AgendamentoRetornoCancelUseCase _service,
        [FromRoute] Guid Id)
    {
        await _service.Handler(Id);
        return Ok();
    }
}