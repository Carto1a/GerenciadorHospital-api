using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentResults;
using Hospital.Dto;

namespace Hospital.Service.Interfaces;
public interface IAuthenticationService
{
    Task<Result<string>> Register(RegisterRequestDto request);
    Task<Result<string>> RegisterPaciente(RegisterRequestPacienteDto request);
    Task<Result<string>> Login(LoginRequestDto request);
}
