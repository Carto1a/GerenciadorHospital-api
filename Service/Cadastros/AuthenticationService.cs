using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FluentResults;
using Hospital.Dto;
using Hospital.Dto.Auth;
using Hospital.Models.Cadastro;
using Hospital.Repository.Cadastros.Interfaces;
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
    private readonly UserManager<Paciente> _pacienteManager;
    private readonly UserManager<Medico> _medicoManager;
    private readonly UserManager<Admin> _adminManager;
    private readonly IConvenioService _convenioService;
    private readonly IConfiguration _configuration;
    private readonly IAuthenticationRepository _authRepo;
    public AuthenticationService(
        UserManager<Cadastro> userManager,
        UserManager<Paciente> pacienteManager,
        UserManager<Medico> medicoManager,
        UserManager<Admin> adminManager,
        IConvenioService convenioService,
        IConfiguration configuration,
        IAuthenticationRepository authenticationRepository,
        ILogger<AuthenticationService> logger)
    {
        _userManager = userManager;
        _pacienteManager = pacienteManager;
        _medicoManager = medicoManager;
        _adminManager = adminManager;
        _convenioService = convenioService;
        _configuration = configuration;
        _authRepo = authenticationRepository;
        _logger = logger;
        _logger.LogDebug(1, "NLog injected into AuthenticationService");
    }

    public async Task<Result<string>> Login(
        LoginRequestMedicoDto request)
    {
        _logger.LogInformation($"Logando medico: {request.Email}");
        var user = await _medicoManager
            .FindByEmailAsync(request.Email);

        if (user == null)
        {
            _logger.LogError($"Cadastro de medico não existe: {request.Email}");
            return Result.Fail("Cadastro não existe");
        }

        if (!await _medicoManager
            .CheckPasswordAsync(user, request.Password))
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

        var userRoles = await _medicoManager.GetRolesAsync(user);
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
            .FindByEmailAsync(request.Email);

        if (user == null)
        {
            _logger.LogError($"Cadastro de paciente não existe: {request.Email}");
            return Result.Fail("Cadastro não existe");
        }

        if (!await _pacienteManager
            .CheckPasswordAsync(user, request.Password))
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

        var userRoles = await _pacienteManager.GetRolesAsync(user);
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
            .FindByEmailAsync(request.Email);

        if (user == null)
        {
            _logger.LogError($"Cadastro de admin não existe: {request.Email}");
            return Result.Fail("Cadastro não existe");
        }

        if (!await _adminManager
            .CheckPasswordAsync(user, request.Password))
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

        var userRoles = await _adminManager.GetRolesAsync(user);
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
            .FindByEmailAsync(request.Email);
        if (paciente != null)
        {
            _logger.LogError($"Cadastro de paciente já existe: {request.Email}");
            return Result.Fail("Cadastro ja existe");
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

        Paciente paciente1 = new();
        paciente1.Create(
            request,
            convenio,
            _configuration["Paths:PacienteDocumentos"]);

        IdentityResult result;

        try
        {
            result = await _pacienteManager
                .CreateAsync(paciente1, request.Password);
            await _pacienteManager
                .AddToRoleAsync(paciente1, Roles.Paciente);
        }
        catch (Exception error)
        {
            _logger.LogError($"Erro na criação de paciente: {error.Message}");
            return Result.Fail(error.Message);
        }

        if (!result.Succeeded)
        {
            _logger.LogError($"Erro na criação de paciente: {request.Email}");
            return Result.Fail("Erro na Criação");
        }

        _logger.LogInformation($"Paciente registrado: {paciente1.Id}");
        return await Login(
            new LoginRequestPacienteDto
            { Email = request.Email, Password = request.Password });
    }
    public async Task<Result<string>> Register(
        RegisterRequestMedicoDto request)
    {
        _logger.LogInformation($"Registrando medico: {request.Email}");
        var medico = await _medicoManager
            .FindByEmailAsync(request.Email);
        if (medico != null)
        {
            _logger.LogError($"Cadastro de medico já existe: {request.Email}");
            return Result.Fail("Cadastro ja existe");
        }

        Medico medico1 = new();
        medico1.Create(request);

        IdentityResult result;

        try
        {
            result = await _medicoManager
                .CreateAsync(medico1, request.Password);
            await _medicoManager
                .AddToRoleAsync(medico1, Roles.Medico);
        }
        catch (Exception error)
        {
            _logger.LogError($"Erro na criação de medico: {error.Message}");
            return Result.Fail(error.Message);
        }

        if (!result.Succeeded)
        {
            _logger.LogError($"Erro na criação de medico: {request.Email}");
            return Result.Fail("Erro na Criação");
        }

        _logger.LogInformation($"Medico registrado: {medico1.Id}");
        return await Login(
            new LoginRequestMedicoDto
            { Email = request.Email, Password = request.Password });
    }

    public async Task<Result<string>> Register(
        RegisterRequestAdminDto request)
    {
        _logger.LogInformation($"Registrando admin: {request.Email}");
        var admin = await _adminManager
            .FindByEmailAsync(request.Email);
        if (admin != null)
        {
            _logger.LogError($"Cadastro de admin já existe: {request.Email}");
            return Result.Fail("Cadastro ja existe");
        }

        Admin admin1 = new();
        admin1.Create(request);

        IdentityResult result;

        try
        {
            result = await _adminManager
                .CreateAsync(admin1, request.Password);
            await _adminManager
                .AddToRoleAsync(admin1, Roles.Admin);
        }
        catch (Exception error)
        {
            _logger.LogError($"Erro na criação de admin: {error.Message}");
            return Result.Fail(error.Message);
        }

        if (!result.Succeeded)
        {
            _logger.LogError($"Erro na criação de admin: {request.Email}");
            return Result.Fail("Erro na Criação");
        }

        _logger.LogInformation($"Admin registrado: {admin1.Id}");
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
