/* using Hospital.Consts; */
/* using Hospital.Dtos.Input.Authentications; */
/* using Hospital.Services.Cadastros.Medicos; */

/* using Microsoft.AspNetCore.Authorization; */
/* using Microsoft.AspNetCore.Mvc; */

/* namespace Hospital.Controllers.Medicos; */
/* [ApiController] */
/* [Route("api/Medico")] */
/* [Tags("Medico")] */
/* public class MedicoGetByQueryController */
/* : ControllerBase */
/* { */
/*     private readonly MedicoGetByQueryService _service; */
/*     public MedicoGetByQueryController( */
/*         MedicoGetByQueryService service) */
/*     { */
/*         _service = service; */
/*     } */

/*     [HttpGet] */
/*     [Authorize(Policy = PoliciesConsts.Elevated)] */
/*     public IActionResult Execute( */
/*         [FromQuery] MedicoGetByQueryDto query) */
/*     { */
/*         var medicos = _service.Handler(query); */
/*         return Ok(medicos); */
/*     } */
/* } */