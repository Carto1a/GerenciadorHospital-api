using Hospital.Dto.Atividades;
using Hospital.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
    public async Task<IActionResult> PostExame([FromForm] ExameCreationDto request)
    {
        var result = await _exameService.Create(request);
        if(result.IsFailed)
            return BadRequest(result);

        return Ok();
    }
    [HttpGet("{id}")]
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
