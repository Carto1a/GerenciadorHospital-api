/* using Hospital.Dtos.Input.Medicamentos; */
/* using Hospital.Services.Medicamentos; */
/* using Microsoft.AspNetCore.Mvc; */

/* namespace Hospital.Controllers.Medicamentos; */
/* [ApiController] */
/* [Route("api/Medicamentos")] */
/* [Tags("Medicamentos")] */
/* public class MedicamentoCreateController */
/* : ControllerBase */
/* { */
/*     private readonly MedicamentoCreateService _service; */
/*     public MedicamentoCreateController( */
/*         MedicamentoCreateService service) */
/*     { */
/*         _service = service; */
/*     } */

/*     [HttpPost] */
/*     public async Task<IActionResult> Post( */
/*         [FromBody] MedicamentoCreateDto request) */
/*     { */
/*         var result = await _service.Handler(request); */
/*         return Created("", result); */
/*     } */
/* } */