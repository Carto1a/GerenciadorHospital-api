using Hospital.Application.Consts;
using Hospital.Application.Dto.Input.Agendamentos;
using Hospital.Application.UseCases.Agendamentos;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Infrastructure.Controllers.Consultas;
[ApiController]
[Route("api/Agendamento/Consulta")]
[Tags("Agendamento Consulta")]
public class ConsultaAgendamentoCreateController : ControllerBase
{
    [HttpPost]
    [Authorize(Policy = PoliciesConsts.Operational)]
    public async Task<IActionResult> Execute(
        [FromServices] AgendamentoConsultaCreateUseCase _service,
        [FromBody] AgendamentoConsultaCreateDto request)
    {
        var response = await _service.Handler(request);
        return Ok(response);
    }
}