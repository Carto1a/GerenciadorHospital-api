using Hospital.Controllers.Generics;
using Hospital.Dto.Agendamento.Get;
using Hospital.Dto.Auth;
using Hospital.Dto.Result;
using Hospital.Extensions;
using Hospital.Service.Agendamentos.Interfaces;
using Hospital.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers.Medicos;
[ApiController]
[Route("api/[controller]")]
public class MedicosController
: GenericAuthenticationController<RegisterRequestMedicoDto>
{
    private readonly IAuthenticationService _authenticationService;
    private readonly IConsultaAgendamentoService _consultaAgendamentoService;
    private readonly IExameAgendamentoService _exameAgendamentoService;
    public MedicosController(
        IConsultaAgendamentoService consultaAgendamentoService,
        IExameAgendamentoService exameAgendamentoService,
        IAuthenticationService authenticationService)
        : base(authenticationService)
    {
        _authenticationService = authenticationService;
        _consultaAgendamentoService = consultaAgendamentoService;
        _exameAgendamentoService = exameAgendamentoService;
    }

    [AllowAnonymous]
    [HttpPost("Login")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultDto<string>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResultDto<string>))]
    public async Task<IActionResult> Login(
        [FromBody] LoginRequestMedicoDto request)
    {
        var response = await _authenticationService.Login(request);
        var resultDto = response.ToResultDto();

        if (response.IsFailed)
            return BadRequest(resultDto);

        return Ok(resultDto);
    }

    [Authorize(Policy = "ElevatedRights")]
    [HttpPost("Cadastro")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultDto<string>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResultDto<string>))]
    public async Task<IActionResult> Register(
        [FromBody] RegisterRequestMedicoDto request)
    {
        var response = await _authenticationService.Register(request);
        var resultDto = response.ToResultDto();

        if (response.IsFailed)
            return BadRequest(resultDto);

        return Ok(resultDto);
    }

    [Authorize(Roles = "Medico")]
    [HttpGet("Consultas")]
    public async Task<IActionResult> GetConsultas(
        [FromQuery] int limit, int page, string? pacienteId,
        DateTime? MinDate, DateTime? MaxDate)
    {
        var medico = User.Claims
            .FirstOrDefault(x => x.Type == "ID")?.Value;
        var response = await _consultaAgendamentoService
            .GetAgendamentosByQuery(new AgendamentoGetByQueryDto
            {
                MedicoId = medico,
                PacienteId = pacienteId,
                MinDate = MinDate,
                MaxDate = MaxDate,
                Limit = limit,
                Page = page
            });
        var resultDto = response.ToResultDto();
        if (response.IsFailed)
            return BadRequest(resultDto);

        return Ok(resultDto);
    }
    [Authorize(Roles = "Medico")]
    [HttpGet("Exames")]
    public async Task<IActionResult> GetExames(
        [FromQuery] int limit, int page, string? pacienteId,
        DateTime? MinDate, DateTime? MaxDate)
    {
        var medico = User.Claims
            .FirstOrDefault(x => x.Type == "ID")?.Value;
        var response = await _exameAgendamentoService
            .GetAgendamentosByQuery(new AgendamentoGetByQueryDto
            {
                MedicoId = medico,
                PacienteId = pacienteId,
                MinDate = MinDate,
                MaxDate = MaxDate,
                Limit = limit,
                Page = page
            });
        var resultDto = response.ToResultDto();
        if (response.IsFailed)
            return BadRequest(resultDto);

        return Ok(resultDto);
    }
    [Authorize(Policy = "ElevatedRights")]
    [HttpGet("Consultas/{medicoId}")]
    public async Task<IActionResult> GetConsultaById(
        [FromRoute] string medicoId,
        [FromQuery] int limit, int page, string? pacienteId,
        DateTime? MinDate, DateTime? MaxDate)
    {
        var response = await _consultaAgendamentoService
            .GetAgendamentosByQuery(new AgendamentoGetByQueryDto
            {
                MedicoId = medicoId,
                PacienteId = pacienteId,
                MinDate = MinDate,
                MaxDate = MaxDate,
                Limit = limit,
                Page = page
            });
        var resultDto = response.ToResultDto();
        if (response.IsFailed)
            return BadRequest(resultDto);

        return Ok(resultDto);
    }
    [Authorize(Policy = "ElevatedRights")]
    [HttpGet("Exames/{medicoId}")]
    public async Task<IActionResult> GetExameById(
        [FromRoute] string medicoId,
        [FromQuery] int limit, int page, string? pacienteId,
        DateTime? MinDate, DateTime? MaxDate)
    {
        var response = await _exameAgendamentoService
            .GetAgendamentosByQuery(new AgendamentoGetByQueryDto
            {
                MedicoId = medicoId,
                PacienteId = pacienteId,
                MinDate = MinDate,
                MaxDate = MaxDate,
                Limit = limit,
                Page = page
            });
        var resultDto = response.ToResultDto();
        if (response.IsFailed)
            return BadRequest(resultDto);

        return Ok(resultDto);
    }
}
