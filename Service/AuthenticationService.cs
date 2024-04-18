using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Flunt.Notifications;
using Hospital.Dto;
using Hospital.Models;
using Hospital.Service.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace Hospital.Service;
public class AuthenticationService : Notifiable<Notification>, IAuthenticationService
{
    private readonly UserManager<Cadastro> _userManager;
    private readonly IConfiguration _configuration;
    public AuthenticationService(UserManager<Cadastro> userManager, IConfiguration configuration)
    {
        _userManager = userManager;
        _configuration = configuration;
    }
    public async Task<string> Register(RegisterRequestDto request)
    {
        var userByEmail = await _userManager.FindByEmailAsync(request.Email);
        if(userByEmail != null)
        {
            AddNotification("Cadastro", "Cadastro já existente");
            return null;
        }

        Cadastro user = new()
        {
            Email = request.Email,
            Nome = request.Nome,
            DataNascimento = DateOnly.FromDateTime(DateTime.Now),
            Genero = false,
            Telefone = "40028922",
            Cep = 123,
            NumeroCasa = "2",
            UserName = request.Username,
            SecurityStamp = Guid.NewGuid().ToString()
        };

        var result = await _userManager.CreateAsync(user, request.Password);
        await _userManager.AddToRoleAsync(user, Roles.Admin);

        if(!result.Succeeded) 
        {
            AddNotification("Cadastro", "Erro na criação");
            return null;
        }
        return await Login(new LoginRequestDto { Email = request.Email, Password = request.Password });
    }

    public async Task<string> Login(LoginRequestDto request)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);

        if(user == null)
        {
            AddNotification("Cadastro", "Cadastro não existe");
            return null;
        } 

        if(!await _userManager.CheckPasswordAsync(user, request.Password))
        {
            AddNotification("Senha", "Senha errada");
            return null;
        }

        var authClaims = new List<Claim>
        {
            new(ClaimTypes.Name, user.UserName),
            new(ClaimTypes.Email, user.Email),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

        var userRoles = await _userManager.GetRolesAsync(user);
        authClaims.AddRange(userRoles.Select(userRoles =>
            new Claim(ClaimTypes.Role, userRoles) 
        ));

        var token = GetToken(authClaims);
        
        return new JwtSecurityTokenHandler().WriteToken(token);
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
