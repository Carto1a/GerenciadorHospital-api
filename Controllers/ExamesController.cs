using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hospital.Dto.Agendamento;
using Hospital.Dto.Atividades;
using Hospital.Models;
using Hospital.Models.Agendamentos;
using Hospital.Repository.Interfaces;
using Hospital.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Hospital.Extensions;

namespace Hospital.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExamesController : ControllerBase
{
    private readonly IExameService _exameService;
    public ExamesController(IExameService exameService)
    {
       _exameService = exameService;
    }

    [HttpPost]
    [Route("Agendamento")]
    public async Task<IActionResult> PostAgendamento([FromForm] AgendamentoCreateDto request)
    {
        var response = await _exameService.CreateAgendamento(request);
        var result = response.ToResultDto();
        if(result.IsFailed)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> PostExame([FromForm] ExameCreationDto request)
    {
        var result = await _exameService.Create(request);
        if(result.IsFailed)
            return BadRequest(result);

        return Ok();
    }
    [HttpGet("Mostrar/{id}")]
    public async Task<IActionResult> GetExameById([FromRoute]int id)
    {
        var result = await _exameService.GetExameById(id);
        if(result.IsFailed)
            return BadRequest(result);

        return Ok(result);
    }
    [HttpGet("Mostrar")]
    public async Task<IActionResult> GetExames([FromQuery] ExameGetQueryDto request)
    {
        var result = await _exameService.GetExamesByQuery(request);
        if(result.IsFailed)
            return BadRequest(result);
        
        return Ok(result);
    }
    // public async Task<IActionResult> GetAgendamento([FromForm] string request)
    // {
    //     return Ok();
    // }

}
