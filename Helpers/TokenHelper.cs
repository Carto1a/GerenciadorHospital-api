using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using Hospital.Models.Cadastro;

using Microsoft.IdentityModel.Tokens;

namespace Hospital.Helpers;
public class TokenHelper
{
    private static JwtSecurityToken GenerateToken(
        IConfiguration _configuration,
        IEnumerable<Claim> authClaims)
    {
        // NOTE: eu confio no github copilot /s
        var secret = _configuration["JWT:Secret"];
        if (secret == null)
            throw new InvalidOperationException(
                "JWT:Secret not found in appsettings.json");

        var authSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(secret));

        var token = new JwtSecurityToken(
            issuer: _configuration["JWT:ValidIssuer"],
            audience: _configuration["JWT:ValidAudience"],
            expires: DateTime.Now.AddHours(3),
            claims: authClaims,
            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
        );

        return token;
    }

    public static string GenerateUserToken(
        IConfiguration _configuration,
        Cadastro user,
        IList<string> userRoles)
    {
        var authClaims = new List<Claim>
        {
            new("ID", user.Id.ToString()),
            new(ClaimTypes.Name, user.UserName!),
            new(ClaimTypes.Email, user.Email!),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

        authClaims.AddRange(userRoles.Select(userRoles =>
            new Claim(ClaimTypes.Role, userRoles)
        ));

        var token = GenerateToken(_configuration, authClaims);
        var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

        return tokenString;
    }
}