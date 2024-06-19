using Hospital.Application.Consts;
using Hospital.Application.Dto.Input.Agendamentos;
using Hospital.Application.UseCases.Agendamentos;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Infrastructure.Controllers.Consultas;
[ApiController]
[Route("api/Agendamento/Exame")]
[Tags("Agendamento Exame")]
public class ExameAgendamentoCreateController : ControllerBase
{
    [HttpPost]
    [Authorize(Policy = PoliciesConsts.Operational)]
    public async Task<IActionResult> Execute(
        [FromServices] AgendamentoExameCreateUseCase _service,
        [FromBody] AgendamentoExameCreateDto request)
    {
        var response = await _service.Handler(request);
        return Ok(response);
    }
}