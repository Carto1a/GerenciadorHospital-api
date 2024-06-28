using Hospital.Domain.Entities.Cadastros;
using Hospital.Infrastructure.Database;

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Hospital.Infrastructure.Injections;
public static class IdentityInjection
{
    public static IServiceCollection InjectIdentity(
        this IServiceCollection services)
    {

        /* services.AddIdentityCore<Cadastro>() */
        /*     .AddRoles<IdentityRole<Guid>>() */
        /*     .AddRoleManager<RoleManager<IdentityRole<Guid>>>() */
        /*     .AddEntityFrameworkStores<AppDbContext>() */
        /*     .AddDefaultTokenProviders(); */

        /* services.AddIdentityCore<Admin>() */
        /*     .AddRoles<IdentityRole<Guid>>() */
        /*     .AddRoleManager<RoleManager<IdentityRole<Guid>>>() */
        /*     .AddEntityFrameworkStores<AppDbContext>() */
        /*     .AddDefaultTokenProviders(); */

        /* services.AddIdentityCore<Paciente>() */
        /*     .AddRoles<IdentityRole<Guid>>() */
        /*     .AddRoleManager<RoleManager<IdentityRole<Guid>>>() */
        /*     .AddEntityFrameworkStores<AppDbContext>() */
        /*     .AddDefaultTokenProviders(); */

        /* services.AddIdentityCore<Medico>() */
        /*     .AddRoles<IdentityRole<Guid>>() */
        /*     .AddRoleManager<RoleManager<IdentityRole<Guid>>>() */
        /*     .AddEntityFrameworkStores<AppDbContext>() */
        /*     .AddDefaultTokenProviders(); */

        return services;
    }
}