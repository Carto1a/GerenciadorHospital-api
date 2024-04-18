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
        var user = await _medicoManager
            .FindByEmailAsync(request.Email);

        if (user == null)
            return Result.Fail("Cadastro não existe");

        if (!await _medicoManager
            .CheckPasswordAsync(user, request.Password))
            return Result.Fail("Senha errada");

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

        return Result.Ok(
            new JwtSecurityTokenHandler().WriteToken(token));
    }
    public async Task<Result<string>> Login(
        LoginRequestPacienteDto request)
    {
        var user = await _pacienteManager
            .FindByEmailAsync(request.Email);

        if (user == null)
            return Result.Fail("Cadastro não existe");

        if (!await _pacienteManager
            .CheckPasswordAsync(user, request.Password))
            return Result.Fail("Senha errada");

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

        return Result.Ok(
            new JwtSecurityTokenHandler().WriteToken(token));
    }
    public async Task<Result<string>> Login(
        LoginRequestAdminDto request)
    {
        var user = await _adminManager
            .FindByEmailAsync(request.Email);

        if (user == null)
            return Result.Fail("Cadastro não existe");

        if (!await _adminManager
            .CheckPasswordAsync(user, request.Password))
            return Result.Fail("Senha errada");

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

        return Result.Ok(
            new JwtSecurityTokenHandler().WriteToken(token));
    }

    public async Task<Result<string>> Register(
        RegisterRequestPacienteDto request)
    {
        var paciente = await _pacienteManager
            .FindByEmailAsync(request.Email);
        if (paciente != null)
            return Result.Fail("Cadastro ja existe");

        Convenio? convenio = null;
        if (request.ConvenioId != null)
        {
            var convenioResponse = _convenioService
                .GetById((Guid)request.ConvenioId);
            if (convenioResponse.IsFailed)
                return Result.Fail("Convenio não existe");
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
            return Result.Fail(error.Message);
        }

        if (!result.Succeeded)
        {
            return Result.Fail("Erro na Criação");
        }

        return await Login(
            new LoginRequestPacienteDto
            { Email = request.Email, Password = request.Password });
    }
    public async Task<Result<string>> Register(
        RegisterRequestMedicoDto request)
    {
        var medico = await _medicoManager
            .FindByEmailAsync(request.Email);
        if (medico != null)
            return Result.Fail("Cadastro ja existe");

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
            return Result.Fail(error.Message);
        }

        if (!result.Succeeded)
        {
            return Result.Fail("Erro na Criação");
        }

        return await Login(
            new LoginRequestMedicoDto
            { Email = request.Email, Password = request.Password });
    }

    public async Task<Result<string>> Register(
        RegisterRequestAdminDto request)
    {
        var admin = await _adminManager
            .FindByEmailAsync(request.Email);
        if (admin != null)
            return Result.Fail("Cadastro ja existe");

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
            return Result.Fail(error.Message);
        }

        if (!result.Succeeded)
        {
            return Result.Fail("Erro na Criação");
        }

        return await Login(
            new LoginRequestAdminDto
            { Email = request.Email, Password = request.Password });
    }

    public JwtSecurityToken GetToken(IEnumerable<Claim> authClaims)
    {
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
