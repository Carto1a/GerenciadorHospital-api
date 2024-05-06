using Hospital.Dtos.Input.Atendimentos;
using Hospital.Services.Atendimentos.Consultas;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers.Consultas;
[ApiController]
[Route("api/Consulta")]
[Tags("Consultas")]
public class ConsultaCreateController
: ControllerBase
{
    private readonly ConsultaCreateService _service;
    public ConsultaCreateController(
        ConsultaCreateService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Execute(
        ConsultaCreateDto dto)
    {
        var result = await _service.Handler(dto);
        return Created("api/Consulta", result);
    }
}