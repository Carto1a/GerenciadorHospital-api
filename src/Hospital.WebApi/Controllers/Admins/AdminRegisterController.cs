/* using Hospital.Application.Consts; */
/* using Hospital.Application.Dto.Input.Authentications; */
/* using Hospital.Application.UseCases.Cadastros.Admins; */
/* using Hospital.WebApi.Filter; */

/* using Microsoft.AspNetCore.Authorization; */
/* using Microsoft.AspNetCore.Mvc; */

/* namespace Hospital.WebApi.Controllers.Admins; */
/* [ApiController] */
/* [Route("api/Admin")] */
/* [Tags("Admin")] */
/* public class AdminRegisterController */
/* : ControllerBase */
/* { */
/*     [HttpPost("Cadastro")] */
/*     [Authorize(Policy = PoliciesConsts.Elevated)] */
/*     public async Task<IActionResult> Execute( */
/*         [FromServices] AdminRegisterUseCase service, */
/*         [FromBody] RegisterRequestAdminDto request) */
/*     { */
/*         var uri = await service.Handler(request); */
/*         return Ok(new ResponseDataObject(uri)); */
/*     } */
/* } */