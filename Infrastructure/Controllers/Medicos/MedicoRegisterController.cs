/* using Hospital.Application.UseCases.Cadastros.Medicos; */
/* using Hospital.Consts; */
/* using Hospital.Dtos.Input.Authentications; */
/* using Hospital.Filter; */
/* using Hospital.Services.Cadastros.Medicos; */

/* using Microsoft.AspNetCore.Authorization; */
/* using Microsoft.AspNetCore.Mvc; */

/* namespace Hospital.Controllers.Medicos; */
/* [ApiController] */
/* [Route("api/Medico")] */
/* [Tags("Medico")] */
/* public class MedicoRegisterController */
/* : ControllerBase */
/* { */
/*     private readonly MedicoRegisterService _service; */
/*     public MedicoRegisterController( */
/*         MedicoRegisterService service) */
/*     { */
/*         _service = service; */
/*     } */

/*     [HttpPost("Cadastro")] */
/*     [Authorize(Policy = PoliciesConsts.Elevated)] */
/*     public async Task<IActionResult> Execute( */
/*         [FromForm] RegisterRequestMedicoDto request) */
/*     { */
/*         var token = await _service.Handler(request); */
/*         return Ok(new ResponseDataObject(token)); */
/*     } */
/* } */