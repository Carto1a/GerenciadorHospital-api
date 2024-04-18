using Hospital.Controllers.Generics;
using Hospital.Dto.Agendamento.Get;
using Hospital.Dto.Auth;
using Hospital.Dto.Result;
using Hospital.Extensions;
using Hospital.Service.Agendamentos.Interfaces;
using Hospital.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers.Pacientes;
[ApiController]
[Route("api/[controller]")]
public class PacienteController
: GenericAuthenticationController<RegisterRequestPacienteDto>
{
    private readonly ILogger<PacienteController> _logger;
    private readonly IPacienteService _pacienteService;
    private readonly IConsultaAgendamentoService _consultaAgendamentoService;
    private readonly IExameAgendamentoService _exameAgendamentoService;
    private readonly IAuthenticationService _authenticationService;
    public PacienteController(
        ILogger<PacienteController> logger,
        IConfiguration configuration,
        IPacienteService pacienteService,
        IConsultaAgendamentoService consultaAgendamentoService,
        IExameAgendamentoService exameAgendamentoService,
        IAuthenticationService authenticationService)
        : base(authenticationService)
    {
        _pacienteService = pacienteService;
        _authenticationService = authenticationService;
        _consultaAgendamentoService = consultaAgendamentoService;
        _exameAgendamentoService = exameAgendamentoService;
        _logger = logger;
        _logger.LogDebug(1, "NLog injected into PacienteController");
    }

    [AllowAnonymous]
    [HttpPost("Login")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultDto<string>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResultDto<string>))]
    public async Task<IActionResult> Login(
        [FromBody] LoginRequestPacienteDto request)
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
        [FromForm] RegisterRequestPacienteDto request)
    {
        var response = await _authenticationService.Register(request);
        var resultDto = response.ToResultDto();

        if (response.IsFailed)
            return BadRequest(resultDto);

        return Ok(resultDto);
    }

    [Authorize(Roles = "Paciente")]
    [HttpGet("Documentos/Mostrar/{guid}")]
    public IActionResult GetDocumento(
        [FromRoute] Guid guid)
    {
        var result = _pacienteService.GetPacienteDocumento(User, guid);
        if (result.IsFailed)
            return NotFound();

        var path = result.Value;
        if (!System.IO.File.Exists(path))
            return NotFound();

        // NOTE: não existe uma biblioteca de mimetypes, obrigrado microsoft
        return File(System.IO.File.ReadAllBytes(path), "image/png");
    }
    [Authorize(Roles = "Paciente")]
    [HttpGet("Consultas")]
    public async Task<IActionResult> GetConsultas(
        [FromQuery] int limit, int page, Guid? medicoId,
        DateTime? MinDate, DateTime? MaxDate)
    {
        var paciente = User.Claims
            .FirstOrDefault(x => x.Type == "ID")?.Value;
        if (paciente == null)
            return Unauthorized();

        var response = await _consultaAgendamentoService
            .GetAgendamentosByQuery(new AgendamentoGetByQueryDto
            {
                PacienteId = new Guid(paciente),
                MedicoId = medicoId,
                MinDate = MinDate,
                MaxDate = MaxDate,
                Limit = limit,
                Page = page
            });
        var result = response.ToResultDto();
        if (response.IsFailed)
            return NotFound();

        return Ok(result);
    }
    [Authorize(Roles = "Paciente")]
    [HttpGet("Exames")]
    public async Task<IActionResult> GetExames(
        [FromQuery] int limit, int page, Guid? medicoId,
        DateTime? MinDate, DateTime? MaxDate)
    {
        // TODO: limpar os dados desse negocio ai
        var paciente = User.Claims
            .FirstOrDefault(x => x.Type == "ID")?.Value;
        if (paciente == null)
            return Unauthorized();

        var response = await _exameAgendamentoService
            .GetAgendamentosByQuery(new AgendamentoGetByQueryDto
            {
                PacienteId = new Guid(paciente),
                MedicoId = medicoId,
                MinDate = MinDate,
                MaxDate = MaxDate,
                Limit = limit,
                Page = page
            });
        var result = response.ToResultDto();
        if (response.IsFailed)
            return NotFound();

        return Ok(result);
    }
    [Authorize(Policy = "ElevatedRights")]
    [HttpGet("Consultas/{pacienteId}")]
    public async Task<IActionResult> GetConsultaById(
        [FromRoute] Guid pacienteId,
        [FromQuery] int? limit, int? page, Guid? medicoId,
        DateTime? MinDate, DateTime? MaxDate)
    {
        var response = await _consultaAgendamentoService
            .GetAgendamentosByQuery(new AgendamentoGetByQueryDto
            {
                PacienteId = pacienteId,
                MedicoId = medicoId,
                MinDate = MinDate,
                MaxDate = MaxDate,
                Limit = limit ?? 10,
                Page = page ?? 0
            });
        var result = response.ToResultDto();
        if (response.IsFailed)
            return NotFound();

        return Ok(result);
    }
    [Authorize(Policy = "ElevatedRights")]
    [HttpGet("Exames/{pacienteId}")]
    public async Task<IActionResult> GetExameById(
        [FromRoute] Guid pacienteId,
        [FromQuery] int? limit, int? page, Guid? medicoId,
        DateTime? MinDate, DateTime? MaxDate)
    {
        var response = await _exameAgendamentoService
            .GetAgendamentosByQuery(new AgendamentoGetByQueryDto
            {
                PacienteId = pacienteId,
                MedicoId = medicoId,
                MinDate = MinDate,
                MaxDate = MaxDate,
                Limit = limit ?? 10,
                Page = page ?? 0
            });
        var result = response.ToResultDto();
        if (response.IsFailed)
            return NotFound();

        return Ok(result);
    }
    // TODO: fazer um dto para esses dois
    [Authorize(Policy = "ElevatedRights")]
    [HttpGet]
    public IActionResult GetPacientes(
        [FromQuery] int limit, int page)
    {
        var response = _pacienteService.GetPacientes(limit, page);
        var result = response.ToResultDto();
        if (response.IsFailed)
            return NotFound();

        return Ok(result);
    }
    [Authorize(Policy = "ElevatedRights")]
    [HttpGet("{pacienteId}")]
    public IActionResult GetPacienteById(
        [FromRoute] Guid pacienteId)
    {
        var response = _pacienteService.GetPacienteById(pacienteId);
        var result = response.ToResultDto();
        if (response.IsFailed)
            return NotFound();

        return Ok(result);
    }
}
