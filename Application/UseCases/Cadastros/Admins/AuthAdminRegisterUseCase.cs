using Hospital.Dtos.Input.Authentications;
using Hospital.Exceptions;
using Hospital.Models.Cadastro;
using Hospital.Repository.Cadastros.Authentications.Interfaces;

namespace Hospital.Services.Cadastros;
public class AuthAdminRegisterService
{
    private readonly ILogger<AuthAdminRegisterService> _logger;
    private readonly IAuthAdminRepository _adminManager;
    public AuthAdminRegisterService(
        IAuthAdminRepository adminManager,
        ILogger<AuthAdminRegisterService> logger)
    {
        _adminManager = adminManager;
        _logger = logger;
        _logger.LogDebug(1, $"NLog injected into AuthAdminRegisterService");
    }
    public async Task<string> Handler(
        RegisterRequestAdminDto request)
    {
        _logger.LogInformation($"Registrando admin: {request.Email}");

        var findAdmin = _adminManager
            .CheckIfCadastroExists(request);
        if (findAdmin)
            throw new RequestError(
                $"Cadastro de admin já existe: {request.Email}",
                "Senha | Email | CPF Inválidos");

        var admin = new Admin(request);

        await _adminManager.CreateAsync(admin, request.Password);

        _logger.LogInformation($"Admin registrado: {admin.Id}");
        return $"/api/Admin/{admin.Id}";
    }
}