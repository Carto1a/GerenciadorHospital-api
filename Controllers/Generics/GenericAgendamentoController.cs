using Hospital.Dto.Agendamento;
using Hospital.Extensions;
using Hospital.Service.Generics.Interfaces;
using Hospital.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers.Generics;
public abstract class GenericAgendamentoController<T, TAgendamento, TCreation> : ControllerBase
{
    private readonly IGenericAtendimentoService<T, TAgendamento, TCreation> _service;
    public GenericAgendamentoController(IGenericAtendimentoService<T, TAgendamento, TCreation> service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> PostAgendamento([FromForm] AgendamentoCreateDto request)
    {
        var response = await _service.CreateAgendamento(request);
        var result = response.ToResultDto();
        if(result.IsFailed)
            return BadRequest(result);

        return Ok(result);
    }
}
