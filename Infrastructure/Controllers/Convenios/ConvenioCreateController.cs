/* using Hospital.Dtos.Input.Convenios; */
/* using Hospital.Filter; */
/* using Hospital.Services.Convenios; */
/* using Microsoft.AspNetCore.Mvc; */

/* namespace Hospital.Controllers.Cadastros; */
/* [ApiController] */
/* [Route("api/Convenio")] */
/* [Tags("Convenio")] */
/* public class ConvenioCreateController */
/* : ControllerBase */
/* { */
/*     private readonly ConvenioCreateService _service; */
/*     public ConvenioCreateController( */
/*         ConvenioCreateService service) */
/*     { */
/*         _service = service; */
/*     } */

/*     [HttpPost("Cadastro")] */
/*     public async Task<IActionResult> Execute( */
/*         [FromBody] ConvenioCreateDto request) */
/*     { */
/*         var uri = await _service.Handler(request); */
/*         return Created("", new ResponseDataObject(uri)); */
/*     } */
/* } */