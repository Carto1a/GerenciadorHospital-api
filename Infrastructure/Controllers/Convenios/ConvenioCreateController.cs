using Hospital.Application.Consts;
using Hospital.Application.Dto.Input.Convenios;
using Hospital.Application.UseCases.Convenios;
using Hospital.Infrastructure.Filter;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Infrastructure.Controllers.Convenios;
[ApiController]
[Route("api/Convenio")]
[Tags("Convenio")]
public class ConvenioCreateController : ControllerBase
{
    [HttpPost]
    [Authorize(Policy = PoliciesConsts.Elevated)]
    public async Task<IActionResult> Execute(
        [FromServices] ConvenioCreateUseCase _service,
        [FromBody] ConvenioCreateDto request)
    {
        var uri = await _service.Handler(request);
        return Created("", new ResponseDataObject(uri));
    }
}