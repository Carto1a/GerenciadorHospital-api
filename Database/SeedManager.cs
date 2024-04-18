using Hospital.Models.Cadastro;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Database;
public static class SeedManager
{
    public static async Task Seed(IServiceProvider services)
    {
        await SeedRoles(services);
        await SeedAdminUser(services);
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
        var userManager = services.GetRequiredService<UserManager<Admin>>();
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

        var adminUser = await context.Admins.FirstOrDefaultAsync(user =>
            user.UserName == "AuthenticationAdmin"
        );

        if (adminUser == null)
        {
            adminUser = new Admin
            {
                UserName = "AuthenticationAdmin",
                Email = "admin@admin.admin",
                Nome = "ze",
                DataNascimento = DateOnly.FromDateTime(DateTime.Now),
                Genero = false,
                Cep = 123,
                NumeroCasa = "2",
                Telefone = "44040404",
                SecurityStamp = Guid.NewGuid().ToString()
            };
            await userManager.CreateAsync(adminUser, "123Carlos@");
            await userManager.AddToRoleAsync(adminUser, Roles.Admin);
        }
    }
}
