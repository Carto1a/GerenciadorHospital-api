/* using Hospital.Services.Medicamentos; */
/* using Microsoft.AspNetCore.Mvc; */

/* namespace Hospital.Controllers.Medicamentos; */
/* [ApiController] */
/* [Route("api/Medicamentos")] */
/* [Tags("Medicamentos")] */
/* public class MedicamentoGetByIdController */
/* : ControllerBase */
/* { */
/*     private readonly MedicamentoGetByIdService _service; */
/*     public MedicamentoGetByIdController( */
/*         MedicamentoGetByIdService service) */
/*     { */
/*         _service = service; */
/*     } */

/*     [HttpGet("{id}")] */
/*     public IActionResult Get( */
/*         [FromRoute] Guid id) */
/*     { */
/*         var result = _service.Handler(id); */
/*         return Ok(result); */
/*     } */
/* } */