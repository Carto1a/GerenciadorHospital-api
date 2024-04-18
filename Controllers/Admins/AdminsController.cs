using Hospital.Controllers.Generics;
using Hospital.Dto.Auth;
using Hospital.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers.Admins;
[ApiController]
[Route("api/[controller]")]
public class AdminsController
: GenericAuthenticationController<RegisterRequestAdminDto>
{
    private readonly IAuthenticationService _authenticationService;
    public AdminsController(
        IAuthenticationService authenticationService) : base(authenticationService)
    {
        _authenticationService = authenticationService;
    }
}
