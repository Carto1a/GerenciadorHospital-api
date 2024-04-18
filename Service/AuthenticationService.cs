using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using FluentResults;
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
    public async Task<Result<string>> Register(RegisterRequestDto request)
    {
        var userByEmail = await _userManager.FindByEmailAsync(request.Email);
        if(userByEmail != null)
            return Result.Fail("Cadastro não existe");

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
            return Result.Fail("Erro na criação");
        
        return await Login(new LoginRequestDto { Email = request.Email, Password = request.Password });
    }

    public async Task<Result<string>> Login(LoginRequestDto request)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);

        if(user == null)
            return Result.Fail("Cadastro não existe");

        if(!await _userManager.CheckPasswordAsync(user, request.Password))
            return Result.Fail("Senha errada");

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
        
        return Result.Ok(new JwtSecurityTokenHandler().WriteToken(token));
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
