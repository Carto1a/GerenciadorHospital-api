using Hospital.Application.Consts;
using Hospital.Application.Dto.Input.Agendamentos;
using Hospital.Application.UseCases.Agendamentos;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Infrastructure.Controllers.Retornos;
[ApiController]
[Route("api/Agendamento/Retorno")]
[Tags("Agendamento Retorno")]
public class RetornoAgendamentoGetByQueryController : ControllerBase
{
    [HttpGet]
    [Authorize(Policy = PoliciesConsts.Operational)]
    public async Task<IActionResult> Execute(
        [FromServices] AgendamentoRetornoGetByQueryUseCase _service,
        [FromQuery] AgendamentoRetornoGetByQuery query)

    {
        var response = await _service.Handler(query);
        return Ok(response);
    }
}