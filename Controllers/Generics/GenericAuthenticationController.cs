using Hospital.Service.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers.Generics;
public abstract class GenericAuthenticationController<T>
: ControllerBase
{
    private readonly IAuthenticationService _authenticationService;
    public GenericAuthenticationController(
        IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    /* [AllowAnonymous] */
    /* [HttpPost("Login")] */
    /* [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultDto<string>))] */
    /* [ProducesResponseType(StatusCodes.Status500InternalServerError)] */
    /* [ProducesResponseType(StatusCodes.Status400BadRequest)] */
    /* [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResultDto<string>))] */
    /* public async Task<IActionResult> Login( */
    /*     [FromBody] LoginRequestDto request) */
    /* { */
    /*     var response = await _authenticationService.Login(request); */
    /*     var resultDto = response.ToResultDto(); */

    /*     if (response.IsFailed) */
    /*         return BadRequest(resultDto); */

    /*     return Ok(resultDto); */
    /* } */

    /* [Authorize(Policy = "ElevatedRights")] */
    /* [HttpPost("Cadastro")] */
    /* [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultDto<string>))] */
    /* [ProducesResponseType(StatusCodes.Status500InternalServerError)] */
    /* [ProducesResponseType(StatusCodes.Status400BadRequest)] */
    /* [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResultDto<string>))] */
    /* public async Task<IActionResult> Register( */
    /*     [FromForm] T request) */
    /* { */
    /*     var method = _authenticationService */
    /*         .GetType() */
    /*         .GetMethod("Register", new[] { request.GetType() }); */

    /*     if (method == null) */
    /*         throw new NotImplementedException(); */

    /*     /1* var response = await _authenticationService.Register((RegisterRequestMedicoDto)request); *1/ */
    /*     var response = await (Task<Result<string>>)method? */
    /*         .Invoke(_authenticationService, new object[] { request }); */
    /*     var resultDto = response.ToResultDto(); */
    /*     if (response.IsFailed) */
    /*         return BadRequest(resultDto); */

    /*     return Ok(resultDto); */
    /* } */
}