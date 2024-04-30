using Hospital.Dtos.Input.Authentications;
using Hospital.Exceptions;
using Hospital.Helpers;
using Hospital.Repository.Cadastros.Authentications.Interfaces;

namespace Hospital.Services.Cadastros.Pacientes;
public class PacienteLoginService
{
    private readonly ILogger<PacienteLoginService> _logger;
    private readonly IConfiguration _configuration;
    private readonly IAuthMedicoRepository _manager;
    public PacienteLoginService(
        ILogger<PacienteLoginService> logger,
        IConfiguration configuration,
        IAuthMedicoRepository manager)
    {
        _logger = logger;
        _configuration = configuration;
        _manager = manager;
    }

    public async Task<string> Handler(
        LoginRequestPacienteDto request)
    {
        _logger.LogInformation($"Logando Paciente: {request.Email}");
        var user = await _manager
            .FindByEmailAsync(request.Email);

        // NOTE: brecha para side channel attack ao vivo
        if (user == null)
            throw new RequestError(
                $"Cadastro de Paciente não existe: {request.Email}",
                "Email ou senha errada");

        if (!user.Ativo)
            throw new RequestError(
                $"Cadastro de Paciente inativo: {request.Email}",
                "Email ou senha errada");

        if (!await _manager
            .CheckPasswordAsync(user, request.Password))
            throw new RequestError(
                $"Senha de Paciente errada: {request.Email}",
                "Email ou senha errada");

        _logger.LogInformation(
                $"Gerando token para: {request.Email}");

        var userRoles = await _manager.GetRolesAsync(user);

        var token = TokenHelper.GenerateUserToken(
            _configuration, user, userRoles);

        _logger.LogInformation($"Paciente logado: {request.Email}");
        return token;
    }
}