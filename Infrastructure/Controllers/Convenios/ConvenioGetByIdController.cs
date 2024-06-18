using Hospital.Application.UseCases.Convenios;
using Hospital.Filter;
using Hospital.Services.Convenios;

using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers.Convenios;
[ApiController]
[Route("api/Convenio")]
[Tags("Convenio")]
public class ConvenioGetByIdController
: ControllerBase
{
    private readonly ConvenioGetByIdService _service;
    public ConvenioGetByIdController(
        ConvenioGetByIdService service)
    {
        _service = service;
    }

    [HttpGet("{id}")]
    public IActionResult Execute(
        [FromRoute] Guid id)
    {
        var convenio = _service.Handler(id);
        var response = new ResponseDataObject(convenio);
        return Ok(response);
    }
}