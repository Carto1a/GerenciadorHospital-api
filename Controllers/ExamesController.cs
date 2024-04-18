using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hospital.Models;
using Hospital.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExamesController : ControllerBase
{
    private readonly IExamesRepository _examesRepo;
    public ExamesController(IExamesRepository examesRepository)
    {
       _examesRepo = examesRepository; 
    }

    public async Task<IActionResult> PostAgentamento()
    {
        return Ok();
    }

}
