using Hospital.Dto.Agendamento.Create;
using Hospital.Dto.Agendamento.Get;
using Hospital.Extensions;
using Hospital.Service.Agendamentos.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers.Generics;
public abstract class GenericAgendamentoController<
    T,
    TAgendamento,
    TCreation,
    TUpdate>
: ControllerBase
{
    private readonly IAgendamentoService<T, TAgendamento, TCreation> _service;
    public GenericAgendamentoController(
        IAgendamentoService<T, TAgendamento, TCreation> service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> PostAgendamento(
        [FromForm] AgendamentoCreateDto request)
    {
        var response = await _service.CreateAgendamento(request);
        var result = response.ToResultDto();
        if (result.IsFailed)
            return BadRequest(result);

        return Ok(result);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        throw new NotImplementedException();
    }
    [HttpGet]
    public IActionResult GetByQuery(
        [FromQuery] AgendamentoGetByQueryDto request)
    {
        throw new NotImplementedException();
    }
    [HttpPut("{id}")]
    public IActionResult Update(
        [FromRoute] int id, [FromForm] TUpdate request)
    {
        throw new NotImplementedException();
    }
    [HttpDelete("{id}")]
    public IActionResult CancelAgendamento([FromRoute] int id)
    {
        throw new NotImplementedException();
    }
}
