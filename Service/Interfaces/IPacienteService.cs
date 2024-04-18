using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using FluentResults;


namespace Hospital.Service.Interfaces;
public interface IPacienteService
{
    Task<Result<string>> GetPacienteDocumento(ClaimsPrincipal user, string guid);
}
