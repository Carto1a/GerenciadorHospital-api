/* using Hospital.Service.Interfaces; */

/* using Microsoft.AspNetCore.Mvc; */

/* namespace Hospital.Controllers.Generics; */
/* public abstract class GenericAuthenticationController<T> */
/* : ControllerBase */
/* { */
/*     private readonly IAuthenticationService _authenticationService; */
/*     public GenericAuthenticationController( */
/*         IAuthenticationService authenticationService) */
/*     { */
/*         _authenticationService = authenticationService; */
/*     } */

/*     /1* [AllowAnonymous] *1/ */
/*     /1* [HttpPost("Login")] *1/ */
/*     /1* [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultDto<string>))] *1/ */
/*     /1* [ProducesResponseType(StatusCodes.Status500InternalServerError)] *1/ */
/*     /1* [ProducesResponseType(StatusCodes.Status400BadRequest)] *1/ */
/*     /1* [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResultDto<string>))] *1/ */
/*     /1* public async Task<IActionResult> Login( *1/ */
/*     /1*     [FromBody] LoginRequestDto request) *1/ */
/*     /1* { *1/ */
/*     /1*     var response = await _authenticationService.Login(request); *1/ */
/*     /1*     var resultDto = response.ToResultDto(); *1/ */

/*     /1*     if (response.IsFailed) *1/ */
/*     /1*         return BadRequest(resultDto); *1/ */

/*     /1*     return Ok(resultDto); *1/ */
/*     /1* } *1/ */

/*     /1* [Authorize(Policy = "ElevatedRights")] *1/ */
/*     /1* [HttpPost("Cadastro")] *1/ */
/*     /1* [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultDto<string>))] *1/ */
/*     /1* [ProducesResponseType(StatusCodes.Status500InternalServerError)] *1/ */
/*     /1* [ProducesResponseType(StatusCodes.Status400BadRequest)] *1/ */
/*     /1* [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResultDto<string>))] *1/ */
/*     /1* public async Task<IActionResult> Register( *1/ */
/*     /1*     [FromForm] T request) *1/ */
/*     /1* { *1/ */
/*     /1*     var method = _authenticationService *1/ */
/*     /1*         .GetType() *1/ */
/*     /1*         .GetMethod("Register", new[] { request.GetType() }); *1/ */

/*     /1*     if (method == null) *1/ */
/*     /1*         throw new NotImplementedException(); *1/ */

/*     /1*     /2* var response = await _authenticationService.Register((RegisterRequestMedicoDto)request); *2/ *1/ */
/*     /1*     var response = await (Task<Result<string>>)method? *1/ */
/*     /1*         .Invoke(_authenticationService, new object[] { request }); *1/ */
/*     /1*     var resultDto = response.ToResultDto(); *1/ */
/*     /1*     if (response.IsFailed) *1/ */
/*     /1*         return BadRequest(resultDto); *1/ */

/*     /1*     return Ok(resultDto); *1/ */
/*     /1* } *1/ */
/* } */