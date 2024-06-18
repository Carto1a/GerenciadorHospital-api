using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using Hospital.Application.Services;
using Hospital.Domain.Entities.Cadastros;

using Microsoft.IdentityModel.Tokens;

namespace Hospital.Infrastructure.Services;
public class JwtTokenService : IJwtTokenService
{
    private readonly IConfiguration _configuration;
    private readonly string _jwtSecret;
    private readonly string _jwtValidIssuer;
    private readonly string _jwtValidAudience;
    public JwtTokenService(IConfiguration configuration)
    {
        _configuration = configuration;
        if (_configuration["JWT:Secret"] == null)
            throw new ArgumentNullException(
                "JWT:Secret not found in appsettings.Local.json");

        if (_configuration["JWT:ValidAudience"] == null)
            throw new ArgumentNullException(
                "JWT:ValidAudience not found in appsettings.Local.json");

        if (_configuration["JWT:ValidIssuer"] == null)
            throw new ArgumentNullException(
                "JWT:ValidIssuer not found in appsettings.Local.json");

        _jwtSecret = _configuration["JWT:Secret"]!;
        _jwtValidIssuer = _configuration["JWT:ValidIssuer"]!;
        _jwtValidAudience = _configuration["JWT:ValidAudience"]!;
    }

    public string GenerateUserToken(Cadastro user, IList<string> userRoles)
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

        var token = GenerateToken(authClaims);
        var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

        return tokenString;
    }

    private JwtSecurityToken GenerateToken(
        IEnumerable<Claim> authClaims)
    {
        var secret = _jwtSecret;

        var authSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(secret));

        var token = new JwtSecurityToken(
            issuer: _jwtValidIssuer,
            audience: _jwtValidAudience,
            expires: DateTime.Now.AddHours(3),
            claims: authClaims,
            signingCredentials: 
                new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
        );

        return token;
    }
}