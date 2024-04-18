using Hospital.Controllers.Generics;
using Hospital.Dto;
using Hospital.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers;
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
