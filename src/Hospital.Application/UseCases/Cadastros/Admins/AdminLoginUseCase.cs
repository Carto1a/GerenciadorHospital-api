using Hospital.Application.Dto.Input.Authentications;
using Hospital.Application.Services;
using Hospital.Domain.Exceptions;
using Hospital.Domain.Repositories.Cadastros.Authentications;

namespace Hospital.Application.UseCases.Cadastros.Admins;
public class AdminLoginUseCase
{
    private readonly ILogger<AdminLoginUseCase> _logger;
    private readonly IConfiguration _configuration;
    private readonly IAuthAdminRepository _adminManager;
    private readonly IJwtTokenService _jwtTokenService;
    public AdminLoginUseCase(
        ILogger<AdminLoginUseCase> logger,
        IConfiguration configuration,
        IAuthAdminRepository adminManager,
        IJwtTokenService jwtTokenService)
    {
        _logger = logger;
        _configuration = configuration;
        _adminManager = adminManager;
        _jwtTokenService = jwtTokenService;
    }

    public async Task<string> Handler(
        LoginRequestAdminDto request)
    {
        _logger.LogInformation($"Logando admin: {request.Email}");
        var user = await _adminManager
            .FindByEmailAsync(request.Email);

        // NOTE: brecha para side channel attack ao vivo
        if (user == null)
            throw new DomainException(
                $"Cadastro de admin não existe: {request.Email}",
                "Email ou senha errada");

        if (!user.Ativo)
            throw new DomainException(
                $"Cadastro de admin inativo: {request.Email}",
                "Email ou senha errada");

        if (!await _adminManager
            .CheckPasswordAsync(user, request.Password))
            throw new DomainException(
                $"Senha de admin errada: {request.Email}",
                "Email ou senha errada");

        _logger.LogInformation($"Gerando token para: {request.Email}");

        var userRoles = await _adminManager.GetRolesAsync(user);

        var token = _jwtTokenService.GenerateUserToken(
            user, userRoles);

        _logger.LogInformation($"Admin logado: {request.Email}");
        return token;
    }
}