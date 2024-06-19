using Hospital.Application.Consts;
using Hospital.Application.Dto.Input.Agendamentos;
using Hospital.Application.UseCases.Agendamentos;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Infrastructure.Controllers.Retornos;
[ApiController]
[Route("api/Agendamento/Retorno")]
[Tags("Agendamento Retorno")]
public class RetornoAgendamentoCreateController : ControllerBase
{
    [HttpPost]
    [Authorize(Policy = PoliciesConsts.Operational)]
    public async Task<IActionResult> Execute(
        [FromServices] AgendamentoRetornoCreateUseCase _service,
        [FromBody] AgendamentoRetornoCreateDto request)
    {
        var response = await _service.Handler(request);
        return Ok(response);
    }
}