/* using Hospital.Application.Consts; */
/* using Hospital.Application.Dto.Input.Authentications; */
/* using Hospital.Application.UseCases.Cadastros.Medicos; */
/* using Hospital.WebApi.Filter; */

/* using Microsoft.AspNetCore.Authorization; */
/* using Microsoft.AspNetCore.Mvc; */

/* namespace Hospital.WebApi.Controllers.Medicos; */
/* [ApiController] */
/* [Route("api/Medico")] */
/* [Tags("Medico")] */
/* public class MedicoRegisterController */
/* : ControllerBase */
/* { */
/*     [HttpPost("Cadastro")] */
/*     [Authorize(Policy = PoliciesConsts.Elevated)] */
/*     public async Task<IActionResult> Execute( */
/*         [FromServices] MedicoRegisterUseCase service, */
/*         [FromForm] RegisterRequestMedicoDto request) */
/*     { */
/*         var token = await service.Handler(request); */
/*         return Ok(new ResponseDataObject(token)); */
/*     } */
/* } */