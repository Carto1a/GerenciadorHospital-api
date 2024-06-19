using Hospital.Application.Consts;
using Hospital.Application.UseCases.Agendamentos;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Infrastructure.Controllers.Consultas;
[ApiController]
[Route("api/Agendamento/Consulta")]
[Tags("Agendamento Consulta")]
public class ConsultaAgendamentoGetByIdController : ControllerBase
{
    [HttpGet("{id}")]
    [Authorize(Policy = PoliciesConsts.Operational)]
    public async Task<IActionResult> Execute(
        [FromServices] AgendamentoConsultaGetByIdUseCase _service,
        [FromRoute] Guid id)
    {
        var response = await _service.Handler(id);
        return Ok(response);
    }
}