using Hospital.Dtos.Input.Agendamentos;
using Hospital.Models.Agendamentos;
using Hospital.Models.Atendimento;
using Hospital.Services.Agendamentos;

using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers.Generics.Agendamentos;
public abstract class GenericAgendamentoCreateController<
    T,
    TAgendamento,
    TCreateDto>
: ControllerBase
where T : Atendimento, new()
where TAgendamento : Agendamento, new()
where TCreateDto : AgendamentoCreateDto
{
    private readonly AgendamentoCreateService<
        T,
        TAgendamento,
        TCreateDto> _service;
    public GenericAgendamentoCreateController(
        AgendamentoCreateService<
            T,
            TAgendamento,
            TCreateDto> service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Execute(
        [FromBody] TCreateDto dto)
    {
        var result = await _service.Handler(dto);
        return Ok(result);
    }
}