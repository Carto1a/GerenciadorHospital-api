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
    private readonly ILogger<MedicosController> _logger;
    private readonly IAuthenticationService _authenticationService;
    private readonly IConsultaAgendamentoService _consultaAgendamentoService;
    private readonly IExameAgendamentoService _exameAgendamentoService;
    private readonly IMedicoService _medicoService;
    public MedicosController(
        ILogger<MedicosController> logger,
        IConsultaAgendamentoService consultaAgendamentoService,
        IExameAgendamentoService exameAgendamentoService,
        IMedicoService medicoService,
        IAuthenticationService authenticationService)
        : base(authenticationService)
    {
        _medicoService = medicoService;
        _authenticationService = authenticationService;
        _consultaAgendamentoService = consultaAgendamentoService;
        _exameAgendamentoService = exameAgendamentoService;
        _logger = logger;
        _logger.LogDebug(1, "NLog injected into MedicosController");
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
        [FromQuery] int limit, int page, Guid? pacienteId,
        DateTime? MinDate, DateTime? MaxDate)
    {
        var medico = User.Claims
            .FirstOrDefault(x => x.Type == "ID")?.Value;
        if (medico == null)
            return Unauthorized();

        var response = await _consultaAgendamentoService
            .GetAgendamentosByQuery(new AgendamentoGetByQueryDto
            {
                MedicoId = new Guid(medico),
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
        [FromQuery] int limit, int page, Guid? pacienteId,
        DateTime? MinDate, DateTime? MaxDate)
    {
        var medico = User.Claims
            .FirstOrDefault(x => x.Type == "ID")?.Value;
        if (medico == null)
            return Unauthorized();

        var response = await _exameAgendamentoService
            .GetAgendamentosByQuery(new AgendamentoGetByQueryDto
            {
                MedicoId = new Guid(medico),
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
        [FromRoute] Guid medicoId,
        [FromQuery] int limit, int page, Guid? pacienteId,
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
        [FromRoute] Guid medicoId,
        [FromQuery] int limit, int page, Guid? pacienteId,
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
    // TODO: fazer um dto para esses dois
    [Authorize(Policy = "ElevatedRights")]
    [HttpGet("{medicoId}")]
    public IActionResult GetMedicoById(
        [FromRoute] Guid medicoId)
    {
        var response = _medicoService.GetMedicoById(medicoId);
        var result = response.ToResultDto();
        if (response.IsFailed)
            return NotFound();

        return Ok(result);
    }
    [Authorize(Policy = "ElevatedRights")]
    [HttpGet]
    public IActionResult GetPacientes(
        [FromQuery] int limit, int page = 0)
    {
        var response = _medicoService.GetMedicos(limit, page);
        var result = response.ToResultDto();
        if (response.IsFailed)
            return NotFound();

        return Ok(result);
    }
}
