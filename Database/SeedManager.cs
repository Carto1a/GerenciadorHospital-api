using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hospital.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Database;
public static class SeedManager
{
    public static async Task Seed(IServiceProvider services)
    {
    }
    private static async Task SeedRoles(IServiceProvider services)
    {
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

        await roleManager.CreateAsync(new IdentityRole(Roles.Admin));
        await roleManager.CreateAsync(new IdentityRole(Roles.Paciente));
        await roleManager.CreateAsync(new IdentityRole(Roles.Medico));
    }
    private static async Task SeedAdminUser(IServiceProvider services)
    {
        // não esta conpleto, ele so cadastra o login
        // mas falta cadastrar no admin
        var context = services.GetRequiredService<AppDbContext>();
        var userManager = services.GetRequiredService<UserManager<Cadastro>>();
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

        var adminUser = await context.Cadastros.FirstOrDefaultAsync(user => 
            user.UserName == "AuthenticationAdmin"
        );

        if(adminUser == null)
        {
            adminUser = new Cadastro 
            {
                UserName = "AuthenticationAdmin",
                Email = "admin@admin.admin"
            };
            await userManager.CreateAsync(adminUser, "123Carlos@");
            await userManager.AddToRoleAsync(adminUser, Roles.Admin);
        }
    }
}
