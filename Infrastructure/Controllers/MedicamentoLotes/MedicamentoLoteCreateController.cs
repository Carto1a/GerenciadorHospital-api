/* using Hospital.Dtos.Input.Medicamentos; */
/* using Hospital.Services.Medicamentos; */
/* using Microsoft.AspNetCore.Mvc; */

/* namespace Hospital.Controllers.MedicamentoLotes; */
/* [ApiController] */
/* [Route("api/Medicamento/Lotes")] */
/* [Tags("Medicamentos/Lotes")] */
/* public class MedicamentoLoteCreateController */
/* : ControllerBase */
/* { */
/*     private readonly MedicamentoLoteCreateService _service; */
/*     public MedicamentoLoteCreateController( */
/*         MedicamentoLoteCreateService service) */
/*     { */
/*         _service = service; */
/*     } */

/*     [HttpPost] */
/*     public IActionResult Post( */
/*         [FromBody] MedicamentoLoteCreateDto request) */
/*     { */
/*         var result = _service.Handler(request); */
/*         return Created("", result); */
/*     } */
/* } */