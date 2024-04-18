using Hospital.Controllers.Generics;
using Hospital.Dto.Auth;
using Hospital.Dto.Result;
using Hospital.Extensions;
using Hospital.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers.Admins;
[ApiController]
[Route("api/[controller]")]
public class AdminsController
: GenericAuthenticationController<RegisterRequestAdminDto>
{
    private readonly IAuthenticationService _authenticationService;
    private readonly ILogger<AdminsController> _logger;
    public AdminsController(
        ILogger<AdminsController> logger,
        IAuthenticationService authenticationService) : base(authenticationService)
    {
        _authenticationService = authenticationService;
        _logger = logger;
        _logger.LogDebug(1, "NLog injected into AdminsController");
    }

    [AllowAnonymous]
    [HttpPost("Login")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultDto<string>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResultDto<string>))]
    public async Task<IActionResult> Login(
        [FromBody] LoginRequestAdminDto request)
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
        [FromBody] RegisterRequestAdminDto request)
    {
        var response = await _authenticationService.Register(request);
        var resultDto = response.ToResultDto();

        if (response.IsFailed)
            return BadRequest(resultDto);

        return Ok(resultDto);
    }
}
