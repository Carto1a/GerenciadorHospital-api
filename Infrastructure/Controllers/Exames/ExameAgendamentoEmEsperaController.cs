using Hospital.Application.Consts;
using Hospital.Application.UseCases.Agendamentos;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Infrastructure.Controllers.Consultas;
[ApiController]
[Route("api/Agendamento/Exame")]
[Tags("Agendamento Exame")]
public class ExameAgendamentoEmEsperaController : ControllerBase
{
    [HttpPatch("EmEspera/{id}")]
    [Authorize(Policy = PoliciesConsts.Operational)]
    public async Task<IActionResult> Execute(
        [FromServices] AgendamentoExameEmEsperaUseCase _service,
        [FromRoute] Guid id)
    {
        await _service.Handler(id);
        return Ok();
    }
}