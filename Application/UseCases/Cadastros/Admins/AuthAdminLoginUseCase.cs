
using Hospital.Dtos.Input.Authentications;
using Hospital.Exceptions;
using Hospital.Helpers;
using Hospital.Repository.Cadastros.Authentications.Interfaces;

namespace Hospital.Services.Cadastros.Admins;
public class AuthAdminLoginService
{
    private readonly ILogger<AuthAdminLoginService> _logger;
    private readonly IConfiguration _configuration;
    private readonly IAuthAdminRepository _adminManager;
    public AuthAdminLoginService(
        ILogger<AuthAdminLoginService> logger,
        IConfiguration configuration,
        IAuthAdminRepository adminManager)
    {
        _logger = logger;
        _configuration = configuration;
        _adminManager = adminManager;
    }

    public async Task<string> Handler(
        LoginRequestAdminDto request)
    {
        _logger.LogInformation($"Logando admin: {request.Email}");
        var user = await _adminManager
            .FindByEmailAsync(request.Email);

        // NOTE: brecha para side channel attack ao vivo
        if (user == null)
            throw new RequestError(
                $"Cadastro de admin não existe: {request.Email}",
                "Email ou senha errada");

        if (!user.Ativo)
            throw new RequestError(
                $"Cadastro de admin inativo: {request.Email}",
                "Email ou senha errada");

        if (!await _adminManager
            .CheckPasswordAsync(user, request.Password))
            throw new RequestError(
                $"Senha de admin errada: {request.Email}",
                "Email ou senha errada");

        _logger.LogInformation($"Gerando token para: {request.Email}");

        var userRoles = await _adminManager.GetRolesAsync(user);

        var token = TokenHelper.GenerateUserToken(
            _configuration, user, userRoles);

        _logger.LogInformation($"Admin logado: {request.Email}");
        return token;
    }
}