using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hospital.Dto;
using Hospital.Extensions;
using Hospital.Models;
using Hospital.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers;
[ApiController]
[Route("api/[controller]")]
public class PacienteController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly IPacienteService _pacienteService;
    private readonly IAuthenticationService _authenticationService;
    public PacienteController(
        IConfiguration configuration,
        IPacienteService pacienteService,
        IAuthenticationService authenticationService) 
    {
        _configuration = configuration;
        _pacienteService = pacienteService;
        _authenticationService = authenticationService;
    }

    [Authorize]
    [HttpGet("Documentos/Mostrar/{guid}")]
    public async Task<IActionResult> GetDocumento([FromRoute] string guid)
    {
        var result = await _pacienteService.GetPacienteDocumento(User, guid);
        if(result.IsFailed)
            return NotFound();

        var path = result.Value;
        if(!System.IO.File.Exists(path))
            return NotFound();

        // não existe uma biblioteca de mimetypes, obrigrado microsoft
        return File(System.IO.File.ReadAllBytes(path), "image/png");
    }
    [AllowAnonymous]
    [HttpPost("Login")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultDto<string>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResultDto<string>))]
    public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
    {
        var response = await _authenticationService.Login(request);
        var resultDto = response.ToResultDto();

        if(response.IsFailed)
            return BadRequest(resultDto);
        
        return Ok(resultDto);
    }

    [AllowAnonymous]
    [HttpPost("Cadastro")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultDto<string>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResultDto<string>))]
    public async Task<IActionResult> Register([FromForm] RegisterRequestPacienteDto request)
    {
        var response = await _authenticationService.Register(request);
        var resultDto = response.ToResultDto();
        if(response.IsFailed)
            return BadRequest(resultDto); 

        return Ok(resultDto);
    }
}
