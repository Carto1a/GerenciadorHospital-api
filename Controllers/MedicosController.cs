using Hospital.Controllers.Generics;
using Hospital.Dto;
using Hospital.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers;
[ApiController]
[Route("api/[controller]")]
public class MedicosController
    : GenericAuthenticationController<RegisterRequestMedicoDto>
{
    private readonly IAuthenticationService _authenticationService;
    public MedicosController(
        IAuthenticationService authenticationService) : base(authenticationService)
    {
        _authenticationService = authenticationService;
    }
}
