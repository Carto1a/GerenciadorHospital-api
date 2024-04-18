using Hospital.Dto.Atendimento.Create;
using Hospital.Dto.Atendimento.Get;
using Hospital.Dto.Atendimento.Update;
using Hospital.Extensions;
using Hospital.Models.Agendamentos;
using Hospital.Service.Atendimentos.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers.Generics;
public abstract class GenericAtendimentoController<
    T,
    TAgendamento,
    TCreation,
    TUpdate>
: ControllerBase
    where T : class
    where TAgendamento : Agendamento<T>
    where TCreation : AtendimentoCreationDto
    where TUpdate : AtendimentoUpdateDto
{
    private readonly IAtendimentoService<
        T,
        TAgendamento,
        TCreation> _service;
    public GenericAtendimentoController(
        IAtendimentoService<
            T,
            TAgendamento,
            TCreation> service)
    {
        _service = service;
    }

    [Authorize(Policy = "OperationalRights")]
    [HttpPost]
    public async Task<IActionResult> Creation(
        [FromForm] TCreation request)
    {
        /* var claimsIdentity = this.User.Identity as ClaimsIdentity; */
        /* var userId = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value; */
        var response = await _service.Create(request);
        var result = response.ToResultDto();
        if (result.IsFailed)
            return BadRequest(result);

        return Ok(result);
    }

    [Authorize(Policy = "StandardRights")]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var response = await _service.GetById(id);
        var result = response.ToResultDto();
        if (result.IsFailed)
            return BadRequest(result);

        return Ok(result);
    }

    [Authorize(Policy = "StandardRights")]
    [HttpGet]
    public IActionResult GetByQuery(
        [FromQuery] AtendimentoGetByQueryDto query)
    {
        var response = _service.GetByQuery(query);
        var result = response.ToResultDto();
        if (result.IsFailed)
            return BadRequest(result);

        return Ok(result);
    }

    [Authorize(Policy = "OperationalRights")]
    [HttpPut("{id}")]
    public IActionResult Update(
        [FromRoute] int id, [FromForm] TUpdate request)
    {
        throw new NotImplementedException();
    }
}
