using Hospital.Dto.Convenios;
using Hospital.Extensions;
using Hospital.Service.Convenios.Interfaces;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers.Convenios;

[ApiController]
[Route("api/[controller]")]
public class ConvenioController
: ControllerBase
{
    private readonly IConvenioService _service;
    private readonly ILogger<ConvenioController> _logger;
    public ConvenioController(
        ILogger<ConvenioController> logger,
        IConvenioService service)
    {
        _service = service;
        _logger = logger;
        _logger.LogDebug(1, "NLog injected into ConvenioController");
    }

    [Authorize(Policy = "OperationalRights")]
    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] ConvenioCreateDto request)
    {
        var response = await _service.Create(request);
        var result = response.ToResultDto();
        if (result.IsFailed)
            return BadRequest(result);

        return Ok(result);
    }

    [Authorize(Policy = "StandardRights")]
    [HttpGet("{id}")]
    public IActionResult GetById(
        [FromRoute] Guid id)
    {
        var response = _service.GetById(id);
        var result = response.ToResultDto();
        if (response.IsFailed)
            return BadRequest(result);

        return Ok(result);
    }

    [Authorize(Policy = "StandardRights")]
    [HttpGet]
    public async Task<IActionResult> GetByQuery(
        [FromQuery] ConvenioGetByQueryDto request)
    {
        var response = await _service.GetByQuery(request);
        var result = response.ToResultDto();
        if (response.IsFailed)
            return BadRequest(result);

        return Ok(result);
    }

    [Authorize(Policy = "OperationalRights")]
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
        [FromBody] ConvenioUpdateDto request,
        [FromRoute] Guid id)
    {
        var response = await _service.Update(request, id);
        var result = response.ToResultDto();
        if (response.IsFailed)
            return BadRequest(result);

        return Ok(result);
    }

    [Authorize(Policy = "OperationalRights")]
    [HttpDelete("{id}")]
    public IActionResult Delete(
        [FromRoute] Guid id)
    {
        var response = _service.Delete(id);
        var result = response.ToResultDto();
        if (response.IsFailed)
            return BadRequest(result);

        return Ok(result);
    }
}