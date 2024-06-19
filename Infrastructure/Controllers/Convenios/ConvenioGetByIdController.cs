using Hospital.Application.Consts;
using Hospital.Application.UseCases.Convenios;
using Hospital.Infrastructure.Filter;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Infrastructure.Controllers.Convenios;
[ApiController]
[Route("api/Convenio")]
[Tags("Convenio")]
public class ConvenioGetByIdController : ControllerBase
{
    [HttpGet("{id}")]
    [Authorize(Policy = PoliciesConsts.Standard)]
    public async Task<IActionResult> Execute(
        [FromServices] ConvenioGetByIdUseCase _service,
        [FromRoute] Guid id)
    {
        var convenio = await _service.Handler(id);
        var response = new ResponseDataObject(convenio);
        return Ok(response);
    }
}