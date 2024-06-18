using Hospital.Application.UseCases.Agendamentos;
using Hospital.Consts;
using Hospital.Dtos.Input.Agendamentos;
using Hospital.Services.Agendamentos;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers.Consultas;

[ApiController]
[Route("api/Agendamento/Retorno")]
public class RetornoAgendamentoController : ControllerBase
{
    [HttpPost]
    [Authorize(Policy = PoliciesConsts.Operational)]
    public async Task<IActionResult> PostAgendamento(
        [FromServices] AgendamentoRetornoCreateService _service,
        [FromBody] AgendamentoRetornoCreateDto request)
    {
        var response = await _service.Handler(request);
        return Ok(response);
    }

    [HttpPost("EmEspera/{id}")]
    [Authorize(Policy = PoliciesConsts.Operational)]
    public async Task<IActionResult> EmEspera(
        [FromServices] AgendamentoExameEmEsperaService _service,
        [FromRoute] Guid id)
    {
        await _service.Handler(id);
        return Ok();
    }

    [HttpGet]
    [Authorize(Policy = PoliciesConsts.Elevated)]
    public async Task<IActionResult> GetByQuery(
        [FromServices] AgendamentoRetornoGetByQueryService _service,
        [FromQuery] AgendamentoGetByQueryDto request)
    {
        var response = await _service.Handler(request);
        return Ok(response);
    }

    /* [HttpGet("{id}")] */
    /* [Authorize(Policy = PoliciesConsts.Operational)] */
    /* public async Task<IActionResult> GetById( */
    /*     [FromRoute] Guid id) */
    /* { */
    /*     var response = await _service.Handler(id); */
    /*     return Ok(response); */
    /* } */

    /* [HttpPut("{id}")] */
    /* [Authorize(Policy = PoliciesConsts.Operational)] */
    /* public async Task<IActionResult> Update( */
    /*     [FromRoute] Guid id, */
    /*     [FromForm] AgendamentoUpdateDto request) */
    /* { */
    /*     var response = await _service.Handler(request, id); */
    /*     return Ok(response); */
    /* } */

    /* [HttpDelete("{id}")] */
    /* [Authorize(Policy = PoliciesConsts.Operational)] */
    /* public async Task<IActionResult> CancelAgendamento( */
    /*     [FromRoute] Guid id) */
    /* { */
    /*     var response = await _service.Handler(id); */
    /*     return Ok(result); */
    /* } */
}