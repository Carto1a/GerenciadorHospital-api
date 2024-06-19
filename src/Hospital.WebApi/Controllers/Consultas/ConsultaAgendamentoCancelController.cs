using Hospital.Application.Consts;
using Hospital.Application.UseCases.Agendamentos;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Infrastructure.Controllers.Consultas;
[ApiController]
[Route("api/Agendamento/Consulta")]
[Tags("Agendamento Consulta")]
public class ConsultaAgendamentoCancelController : ControllerBase
{
    [HttpPatch("Cancelar/{Id}")]
    [Authorize(Policy = PoliciesConsts.Operational)]
    public async Task<IActionResult> Execute(
        [FromServices] AgendamentoConsultaCancelUseCase _service,
        [FromRoute] Guid Id)
    {
        await _service.Handler(Id);
        return Ok();
    }
}