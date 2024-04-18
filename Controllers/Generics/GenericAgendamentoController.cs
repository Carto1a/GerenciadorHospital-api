using Hospital.Dto.Agendamento.Create;
using Hospital.Dto.Agendamento.Get;
using Hospital.Dto.Agendamento.Update;
using Hospital.Extensions;
using Hospital.Service.Agendamentos.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers.Generics;
public abstract class GenericAgendamentoController<
    T,
    TAgendamento,
    TCreation,
    TUpdate>
: ControllerBase
{
    private readonly ILogger<GenericAgendamentoController<T, TAgendamento, TCreation, TUpdate>> _logger;
    private readonly IAgendamentoService<T, TAgendamento, TCreation> _service;
    public GenericAgendamentoController(
        IAgendamentoService<T, TAgendamento, TCreation> service,
        ILogger<GenericAgendamentoController<T, TAgendamento, TCreation, TUpdate>> logger)
    {
        _service = service;
        _logger = logger;
        _logger.LogDebug(1, $"NLog injected into GenericAgendamentoController {nameof(T)}");
    }

    [Authorize(Policy = "OperationalRights")]
    [HttpPost]
    public async Task<IActionResult> PostAgendamento(
        [FromBody] AgendamentoCreateDto request)
    {
        var response = await _service.CreateAgendamento(request);
        var result = response.ToResultDto();
        if (result.IsFailed)
            return BadRequest(result);

        return Ok(result);
    }
    [Authorize(Policy = "StandardRights")]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var response = await _service.GetAgendamentoById(id);
        var result = response.ToResultDto();
        if (response.IsFailed)
            return BadRequest(result);

        return Ok(result);
    }
    [Authorize(Policy = "StandardRights")]
    [HttpGet]
    public async Task<IActionResult> GetByQuery(
        [FromQuery] AgendamentoGetByQueryDto request)
    {
        var response = await _service.GetAgendamentosByQuery(request);
        var result = response.ToResultDto();
        if (response.IsFailed)
            return BadRequest(result);

        return Ok(result);
    }
    [Authorize(Policy = "OperationalRights")]
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
        [FromRoute] Guid id, [FromForm] AgendamentoUpdateDto request)
    {
        var response = await _service.UpdateAgendamento(request, id);
        var result = response.ToResultDto();
        if (response.IsFailed)
            return BadRequest(result);

        return Ok(result);
    }
    [Authorize(Policy = "OperationalRights")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> CancelAgendamento([FromRoute] Guid id)
    {
        var response = await _service.CancelAgendamento(id);
        var result = response.ToResultDto();
        if (response.IsFailed)
            return BadRequest(result);

        return Ok(result);
    }
}
