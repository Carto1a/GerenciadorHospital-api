using FluentResults;

using Hospital.Dto.Auth;

namespace Hospital.Service.Interfaces;
public interface IAuthenticationService
{
    Task<Result<string>> Register(RegisterRequestPacienteDto request);
    Task<Result<string>> Register(RegisterRequestMedicoDto request);
    Task<Result<string>> Register(RegisterRequestAdminDto request);
    Task<Result<string>> Login(LoginRequestPacienteDto request);
    Task<Result<string>> Login(LoginRequestMedicoDto request);
    Task<Result<string>> Login(LoginRequestAdminDto request);
}