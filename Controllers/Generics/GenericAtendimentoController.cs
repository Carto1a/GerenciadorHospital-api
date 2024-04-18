using Hospital.Dto.Atividades;
using Hospital.Extensions;
using Hospital.Service.Interfaces;
using Hospital.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Hospital.Models;
using Hospital.Models.Agendamentos;
using Hospital.Service.Generics.Interfaces;
using Hospital.Repository.Generics.Interfaces;

namespace Hospital.Controllers;
public abstract class GenericAtendimentoController<T, TAgendamento, TCreation> : ControllerBase
    where T : class
    where TAgendamento : Agendamento<T>
    where TCreation : GenericAtividadesCreationDto
{
    private readonly IGenericAtendimentoService<T, TAgendamento, TCreation> _service;
    private readonly IGenericAtendimentoRepository<T, TAgendamento> _repo;
    public GenericAtendimentoController(
        IGenericAtendimentoService<T, TAgendamento, TCreation> service,
        IGenericAtendimentoRepository<T, TAgendamento> repository)
    {
        _service = service;
        _repo = repository;
    }

    [HttpPost]
    public async Task<IActionResult> Creation([FromForm] TCreation request)
    {
        var response = await _service.Create(request);
        var result = response.ToResultDto();
        if (result.IsFailed)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var response = await _service.GetById(id);
        var result = response.ToResultDto();
        if (result.IsFailed)
            return BadRequest(result);

        return Ok(result);
    }
    [HttpGet]
    public IActionResult GetAll([FromQuery] AtendimentoGetQueryDto query)
    {
        var response = _service.GetByQuery(query);
        var result = response.ToResultDto();
        if (result.IsFailed)
            return BadRequest(result);

        return Ok(result);
    }
}
