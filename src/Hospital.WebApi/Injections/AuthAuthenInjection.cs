using System.Text;

using Hospital.Application;
using Hospital.Application.Consts;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Hospital.WebApi.Injections;
public static class AuthAuthenInjection
{
    public static IServiceCollection InjectAuthAuthen(
        this IServiceCollection services,
        IConfiguration configuration)
    {

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.SaveToken = true;
            options.RequireHttpsMetadata = false;
            options.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidAudience = configuration["JWT:ValidAudience"],
                ValidIssuer = configuration["JWT:ValidIssuer"],
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(configuration["JWT:Secret"]!)),
                ClockSkew = TimeSpan.Zero
            };
        });

        services.AddAuthorization(options =>
        {
            options.AddPolicy(PoliciesConsts.Elevated, policy =>
                policy.RequireRole(Roles.Admin)
            );
            options.AddPolicy(PoliciesConsts.Standard, policy =>
                policy.RequireRole(Roles.Admin, Roles.Medico, Roles.Paciente)
            );
            options.AddPolicy(PoliciesConsts.Operational, policy =>
                policy.RequireRole(Roles.Admin, Roles.Medico)
            );
        });

        return services;
    }
}