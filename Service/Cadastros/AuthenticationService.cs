using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FluentResults;
using Hospital.Dto;
using Hospital.Dto.Auth;
using Hospital.Models.Cadastro;
using Hospital.Repository.Cadastros.Interfaces;
using Hospital.Service.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace Hospital.Service.Cadastros;
public class AuthenticationService
: IAuthenticationService
{
    private readonly UserManager<Cadastro> _userManager;
    private readonly IConfiguration _configuration;
    private readonly IAuthenticationRepository _authRepo;
    public AuthenticationService(
        UserManager<Cadastro> userManager,
        IConfiguration configuration,
        IAuthenticationRepository authenticationRepository)
    {
        _userManager = userManager;
        _configuration = configuration;
        _authRepo = authenticationRepository;
    }
    private async Task<Result> RegisterBase(RegisterRequestDto request)
    {
        var userByEmail = await _userManager.FindByEmailAsync(request.Email);
        if (userByEmail != null)
            return Result.Fail("Cadastro ja existe");

        Cadastro user = new()
        {
            Email = request.Email,
            Nome = request.Nome,
            DataNascimento = DateOnly.FromDateTime(DateTime.Now),
            Genero = false,
            Telefone = "40028922",
            Cpf = request.Cpf,
            Cep = 123,
            NumeroCasa = "2",
            UserName = request.Email,
            SecurityStamp = Guid.NewGuid().ToString()
        };

        IdentityResult result;

        try
        {
            result = await _userManager.CreateAsync(user, request.Password);
        }
        catch (Exception error)
        {
            return Result.Fail(error.Message);
        }

        if (!result.Succeeded)
            return Result.Fail("Erro na criação");

        return Result.Ok();
    }

    public async Task<Result<string>> Login(LoginRequestDto request)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);

        if (user == null)
            return Result.Fail("Cadastro não existe");

        if (!await _userManager.CheckPasswordAsync(user, request.Password))
            return Result.Fail("Senha errada");

        var authClaims = new List<Claim>
        {
            new("ID", user.Id),
            new(ClaimTypes.Name, user.UserName),
            new(ClaimTypes.Email, user.Email),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

        var userRoles = await _userManager.GetRolesAsync(user);
        authClaims.AddRange(userRoles.Select(userRoles =>
            new Claim(ClaimTypes.Role, userRoles)
        ));

        var token = GetToken(authClaims);

        return Result.Ok(new JwtSecurityTokenHandler().WriteToken(token));
    }

    public async Task<Result<string>> Register(RegisterRequestPacienteDto request)
    {
        // teveria unit of work, mas eu to fechado com a microsoft e ef
        var result = await RegisterBase(request);
        if (result.IsFailed)
            return result;

        var user = await _userManager.FindByEmailAsync(request.Email);
        if (user == null)
            return Result.Fail("Cadastro não encontrado");

        await _userManager.AddToRoleAsync(user, Roles.Paciente);

        var DocConvenioName = Guid.NewGuid().ToString();
        var DocIntentifiName = Guid.NewGuid().ToString();
        var DocConvenioPath = Path.Combine(_configuration["Paths:PacienteDocumentos"], DocConvenioName);
        var DocIntentifiPath = Path.Combine(_configuration["Paths:PacienteDocumentos"], DocIntentifiName);

        Stream fileStream = new FileStream(DocConvenioPath, FileMode.Create);
        Stream fileStream2 = new FileStream(DocIntentifiPath, FileMode.Create);
        await request.Convenio.CopyToAsync(fileStream);
        await request.Convenio.CopyToAsync(fileStream2);

        fileStream.Close();
        fileStream2.Close();

        Paciente paciente = new()
        {
            Cadastro = user,
            TemConvenio = false,
            ImgCarteiraConvenio = DocConvenioName,
            ImgDocumento = DocIntentifiName
        };

        await _authRepo.CreatePaciente(paciente);

        return await Login(new LoginRequestDto { Email = request.Email, Password = request.Password });
    }
    public async Task<Result<string>> Register(RegisterRequestMedicoDto request)
    {
        var result = await RegisterBase(request);
        if (result.IsFailed)
            return result;

        // TODO: isso parece desnecesario
        var user = await _userManager.FindByEmailAsync(request.Email);
        if (user == null)
            return Result.Fail("Cadastro não encontrado");

        await _userManager.AddToRoleAsync(user, Roles.Medico);

        Medico medico = new()
        {
            Cadastro = user,
            Especialidade = "muito pika"
        };

        await _authRepo.CreateMedico(medico);
        return await Login(new LoginRequestDto { Email = request.Email, Password = request.Password });
    }

    public async Task<Result<string>> Register(RegisterRequestAdminDto request)
    {
        var result = await RegisterBase(request);
        if (result.IsFailed)
            return result;

        // TODO: isso parece desnecesario
        var user = await _userManager.FindByEmailAsync(request.Email);
        if (user == null)
            return Result.Fail("Cadastro não encontrado");

        await _userManager.AddToRoleAsync(user, Roles.Medico);

        Admin admin = new()
        {
            Cadastro = user
        };

        await _authRepo.CreateAdmin(admin);
        return await Login(new LoginRequestDto { Email = request.Email, Password = request.Password });
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
