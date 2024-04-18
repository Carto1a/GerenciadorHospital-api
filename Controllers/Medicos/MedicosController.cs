using Hospital.Controllers.Generics;
using Hospital.Dto.Auth;
using Hospital.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers.Medicos;
[ApiController]
[Route("api/[controller]")]
public class MedicosController
: GenericAuthenticationController<RegisterRequestMedicoDto>
{
    private readonly IAuthenticationService _authenticationService;
    public MedicosController(
        IAuthenticationService authenticationService)
        : base(authenticationService)
    {
        _authenticationService = authenticationService;
    }
}
