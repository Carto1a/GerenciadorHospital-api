using Hospital.Application.Dto.Input.Authentications;
using Hospital.Application.Services;
using Hospital.Domain.Exceptions;
using Hospital.Domain.Repositories.Cadastros.Authentications;

namespace Hospital.Application.UseCases.Cadastros.Pacientes;
public class PacienteLoginUseCase
{
    private readonly ILogger<PacienteLoginUseCase> _logger;
    private readonly IConfiguration _configuration;
    private readonly IAuthPacienteRepository _manager;
    private readonly IJwtTokenService _jwtTokenService;
    public PacienteLoginUseCase(
        ILogger<PacienteLoginUseCase> logger,
        IConfiguration configuration,
        IAuthPacienteRepository manager,
        IJwtTokenService jwtTokenService)
    {
        _logger = logger;
        _configuration = configuration;
        _manager = manager;
        _jwtTokenService = jwtTokenService;
    }

    public async Task<string> Handler(
        LoginRequestPacienteDto request)
    {
        _logger.LogInformation($"Logando Paciente: {request.Email}");
        var user = await _manager
            .FindByEmailAsync(request.Email);

        // NOTE: brecha para side channel attack ao vivo
        if (user == null)
            throw new DomainException(
                $"Cadastro de Paciente não existe: {request.Email}",
                "Email ou senha errada");

        if (!user.Ativo)
            throw new DomainException(
                $"Cadastro de Paciente inativo: {request.Email}",
                "Email ou senha errada");

        if (!await _manager
            .CheckPasswordAsync(user, request.Password))
            throw new DomainException(
                $"Senha de Paciente errada: {request.Email}",
                "Email ou senha errada");

        _logger.LogInformation(
                $"Gerando token para: {request.Email}");

        var userRoles = await _manager.GetRolesAsync(user);

        var token = _jwtTokenService.GenerateUserToken(user, userRoles);

        _logger.LogInformation($"Paciente logado: {request.Email}");
        return token;
    }
}