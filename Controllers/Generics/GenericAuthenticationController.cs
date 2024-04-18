using FluentResults;
using Hospital.Dto;
using Hospital.Extensions;
using Hospital.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers.Generics;
public abstract class GenericAuthenticationController<T> : ControllerBase
/* where T : RegisterRequestPacienteDto */
{
    private readonly IAuthenticationService _authenticationService;
    public GenericAuthenticationController(
        IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
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

        if (response.IsFailed)
            return BadRequest(resultDto);

        return Ok(resultDto);
    }

    [AllowAnonymous]
    [HttpPost("Cadastro")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultDto<string>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResultDto<string>))]
    public async Task<IActionResult> Register([FromForm] T request)
    {
        var requestType = request.GetType();
        var method = _authenticationService
            .GetType()
            .GetMethod("Register", new[] { requestType });

        if (method == null)
            throw new NotImplementedException();

        /* var response = await _authenticationService.Register((RegisterRequestMedicoDto)request); */
        var response = await (Task<Result<string>>)method?
            .Invoke(_authenticationService, new object[] { request });
        var resultDto = response.ToResultDto();
        if (response.IsFailed)
            return BadRequest(resultDto);

        return Ok(resultDto);
    }
}
