using Hospital.Application.Consts;
using Hospital.Application.UseCases.Agendamentos;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Infrastructure.Controllers.Retornos;
[ApiController]
[Route("api/Agendamento/Retorno")]
[Tags("Agendamento Retorno")]
public class RetornoAgendamentoEmEsperaController : ControllerBase
{
    [HttpPatch("EmEspera/{id}")]
    [Authorize(Policy = PoliciesConsts.Operational)]
    public async Task<IActionResult> Execute(
        [FromServices] AgendamentoRetornoEmEsperaUseCase _service,
        [FromRoute] Guid id)
    {
        await _service.Handler(id);
        return Ok();
    }
}