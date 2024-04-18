using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers;
[ApiController]
[Route("api/[controller]")]
public class PacienteController : ControllerBase
{
    private readonly IConfiguration _configuration;
    public PacienteController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [AllowAnonymous]
    [HttpGet("Documentos/Mostrar/{guid}")]
    public async Task<IActionResult> GetDocumento([FromRoute] string guid)
    {
        // não permitir que os outros acessem essa rota
        var path = Path.Combine(_configuration["Paths:PacienteDocumentos"], guid);
        if(!System.IO.File.Exists(path))
            return NotFound();

        return File(System.IO.File.ReadAllBytes(path), "image/png");
    }
}
