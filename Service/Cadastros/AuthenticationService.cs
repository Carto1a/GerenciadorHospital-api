using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using FluentResults;

using Hospital.Dto.Auth;
using Hospital.Models.Cadastro;
using Hospital.Repository.Cadastros.Authentications.Interfaces;
using Hospital.Service.Convenios.Interfaces;
using Hospital.Service.Interfaces;

using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace Hospital.Service.Cadastros;
public class AuthenticationService
: IAuthenticationService
{
    private readonly ILogger<AuthenticationService> _logger;
    private readonly UserManager<Cadastro> _userManager;
    private readonly IAuthAdminRepository _adminManager;
    private readonly IAuthMedicoRepository _medicoManager;
    private readonly IAuthPacienteRepository _pacienteManager;
    private readonly IConvenioService _convenioService;
    private readonly IConfiguration _configuration;
    public AuthenticationService(
        UserManager<Cadastro> userManager,
        IAuthPacienteRepository pacienteManager,
        IAuthMedicoRepository medicoManager,
        IAuthAdminRepository adminManager,
        IConvenioService convenioService,
        IConfiguration configuration,
        ILogger<AuthenticationService> logger)
    {
        _userManager = userManager;
        _pacienteManager = pacienteManager;
        _medicoManager = medicoManager;
        _adminManager = adminManager;
        _convenioService = convenioService;
        _configuration = configuration;
        _logger = logger;
        _logger.LogDebug(1, "NLog injected into AuthenticationService");
    }

    public async Task<Result<string>> Login(
        LoginRequestMedicoDto request)
    {
        _logger.LogInformation($"Logando medico: {request.Email}");
        var user = await _medicoManager
            .FindByEmail(request.Email);
        if (user == null)
        {
            _logger.LogError($"Cadastro de medico não existe: {request.Email}");
            return Result.Fail("Cadastro não existe");
        }

        if (!await _medicoManager
            .CheckPassword(user, request.Password))
        {
            _logger.LogError($"Senha de medico errada: {request.Email}");
            return Result.Fail("Senha errada");
        }

        var authClaims = new List<Claim>
        {
            new("ID", user.Id.ToString()),
            new(ClaimTypes.Name, user.UserName),
            new(ClaimTypes.Email, user.Email),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

        var userRoles = await _medicoManager.GetRoles(user);
        authClaims.AddRange(userRoles.Select(userRoles =>
            new Claim(ClaimTypes.Role, userRoles)
        ));

        var token = GetToken(authClaims);

        _logger.LogInformation($"Medico logado: {request.Email}");
        return Result.Ok(
            new JwtSecurityTokenHandler().WriteToken(token));
    }
    public async Task<Result<string>> Login(
        LoginRequestPacienteDto request)
    {
        _logger.LogInformation($"Logando paciente: {request.Email}");
        var user = await _pacienteManager
            .FindByEmail(request.Email);

        if (user == null)
        {
            _logger.LogError($"Cadastro de paciente não existe: {request.Email}");
            return Result.Fail("Cadastro não existe");
        }

        if (!await _pacienteManager
            .CheckPassword(user, request.Password))
        {
            _logger.LogError($"Senha de paciente errada: {request.Email}");
            return Result.Fail("Senha errada");
        }

        var authClaims = new List<Claim>
        {
            new("ID", user.Id.ToString()),
            new(ClaimTypes.Name, user.UserName),
            new(ClaimTypes.Email, user.Email),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

        var userRoles = await _pacienteManager.GetRoles(user);
        authClaims.AddRange(userRoles.Select(userRoles =>
            new Claim(ClaimTypes.Role, userRoles)
        ));

        var token = GetToken(authClaims);

        _logger.LogInformation($"Paciente logado: {request.Email}");
        return Result.Ok(
            new JwtSecurityTokenHandler().WriteToken(token));
    }
    public async Task<Result<string>> Login(
        LoginRequestAdminDto request)
    {
        _logger.LogInformation($"Logando admin: {request.Email}");
        var user = await _adminManager
            .FindByEmail(request.Email);

        if (user == null)
        {
            _logger.LogError($"Cadastro de admin não existe: {request.Email}");
            return Result.Fail("Cadastro não existe");
        }

        if (!await _adminManager
            .CheckPassword(user, request.Password))
        {
            _logger.LogError($"Senha de admin errada: {request.Email}");
            return Result.Fail("Senha errada");
        }

        var authClaims = new List<Claim>
        {
            new("ID", user.Id.ToString()),
            new(ClaimTypes.Name, user.UserName),
            new(ClaimTypes.Email, user.Email),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

        var userRoles = await _adminManager.GetRoles(user);
        authClaims.AddRange(userRoles.Select(userRoles =>
            new Claim(ClaimTypes.Role, userRoles)
        ));

        var token = GetToken(authClaims);

        _logger.LogInformation($"Admin logado: {request.Email}");
        return Result.Ok(
            new JwtSecurityTokenHandler().WriteToken(token));
    }

    public async Task<Result<string>> Register(
        RegisterRequestPacienteDto request)
    {
        _logger.LogInformation($"Registrando paciente: {request.Email}");
        var paciente = await _pacienteManager
            .FindByEmail(request.Email);
        if (paciente != null)
        {
            _logger.LogError($"Cadastro de paciente já existe: {request.Email}");
            return Result.Fail("Cadastro já existe");
        }

        Convenio? convenio = null;
        if (request.ConvenioId != null)
        {
            _logger.LogInformation($"Registrando convenio do paciente: {request.ConvenioId}");
            var convenioResponse = _convenioService
                .GetById((Guid)request.ConvenioId);
            if (convenioResponse.IsFailed)
            {
                _logger.LogError($"Convenio não existe: {request.ConvenioId}");
                return Result.Fail("Convenio não existe");
            }
            convenio = convenioResponse.Value;
        }

        var paciente1 = Paciente.Create(
            request,
            convenio,
            _configuration["Paths:PacienteDocumentos"]);
        if (paciente1.IsFailed)
        {
            _logger.LogError($"Erro na criação de paciente: {request.Email}");
            return Result.Fail("Erro na Criação");
        }

        var result = await _pacienteManager
            .Create(paciente1.Value, request.Password);
        if (result.IsFailed)
        {
            _logger.LogError($"Erro na criação de paciente: {request.Email}");
            return Result.Fail("Erro na Criação");
        }

        _logger.LogInformation($"Paciente registrado: {paciente1.Value.Id}");
        return await Login(
            new LoginRequestPacienteDto
            { Email = request.Email, Password = request.Password });
    }

    public async Task<Result<string>> Register(
        RegisterRequestMedicoDto request)
    {
        _logger.LogInformation($"Registrando medico: {request.Email}");
        var medico = await _medicoManager
            .FindByEmail(request.Email);
        if (medico != null)
        {
            _logger.LogError($"Cadastro de medico já existe: {request.Email}");
            return Result.Fail("Cadastro já exite");
        }

        var medico1 = Medico.Create(request);
        if (medico1.IsFailed)
        {
            _logger.LogError($"Erro na criação de medico: {request.Email}");
            return Result.Fail("Erro na Criação");
        }

        var result = await _medicoManager
            .Create(medico1.Value, request.Password);
        if (result.IsFailed)
        {
            _logger.LogError($"Erro na criação de medico: {request.Email}");
            return Result.Fail("Erro na Criação");
        }

        _logger.LogInformation($"Medico registrado: {medico1.Value.Id}");
        return await Login(
            new LoginRequestMedicoDto
            { Email = request.Email, Password = request.Password });
    }

    public async Task<Result<string>> Register(
        RegisterRequestAdminDto request)
    {
        _logger.LogInformation($"Registrando admin: {request.Email}");
        var admin = await _adminManager
            .FindByEmail(request.Email);
        if (admin != null)
        {
            _logger.LogError($"Cadastro de admin já existe: {request.Email}");
            return Result.Fail("Cadastro ja existe");
        }

        var admin1 = Admin.Create(request);
        if (admin1.IsFailed)
        {
            _logger.LogError($"Erro na criação de admin: {request.Email}");
            return Result.Fail("Erro na Criação");
        }

        var result = await _adminManager
            .Create(admin1.Value, request.Password);
        if (result.IsFailed)
        {
            _logger.LogError($"Erro na criação de admin: {request.Email}");
            return Result.Fail("Erro na Criação");
        }

        _logger.LogInformation($"Admin registrado: {admin1.Value.Id}");
        return await Login(
            new LoginRequestAdminDto
            { Email = request.Email, Password = request.Password });
    }

    public JwtSecurityToken GetToken(IEnumerable<Claim> authClaims)
    {
        // NOTE: eu confio no github copilot /s
        _logger.LogInformation($"Gerando token para: {authClaims.First(claim => claim.Type == ClaimTypes.Email).Value}");
        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
        var token = new JwtSecurityToken(
            issuer: _configuration["JWT:ValidIssuer"],
            audience: _configuration["JWT:ValidAudience"],
            expires: DateTime.Now.AddHours(3),
            claims: authClaims,
            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
        );

        return token;
    }
    private string GetErrorsText(IEnumerable<IdentityError> errors)
    {
        return string.Join(", ", errors.Select(error => error.Description).ToArray());
    }
}