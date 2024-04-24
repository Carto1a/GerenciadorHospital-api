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
        var roleManager = services
        .GetRequiredService<RoleManager<IdentityRole<Guid>>>();

        await roleManager.CreateAsync(new IdentityRole<Guid>(Roles.Admin));
        await roleManager.CreateAsync(new IdentityRole<Guid>(Roles.Paciente));
        await roleManager.CreateAsync(new IdentityRole<Guid>(Roles.Medico));
    }
    private static async Task SeedAdminUser(IServiceProvider services)
    {
        // não esta conpleto, ele so cadastra o login
        // mas falta cadastrar no admin
        var context = services.GetRequiredService<AppDbContext>();
        var userManager = services.GetRequiredService<UserManager<Admin>>();
        var medicoManager = services.GetRequiredService<UserManager<Medico>>();
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

        var adminUser = await context.Admins.FirstOrDefaultAsync(user =>
            user.UserName == "admim@admin.admin"
        );

        var medicoUser = await medicoManager.FindByEmailAsync("medico@medico.medico");


        if (adminUser == null)
        {
            adminUser = new Admin
            {
                UserName = "admin@admin.admin",
                Email = "admin@admin.admin",
                Nome = "ze",
                DataNascimento = DateOnly.FromDateTime(DateTime.Now),
                Genero = false,
                CPF = 00000001,
                CEP = 123,
                NumeroCasa = "2",
                Telefone = "44040404",
                SecurityStamp = Guid.NewGuid().ToString()
            };
            await userManager.CreateAsync(adminUser, "123Carlos@");
            await userManager.AddToRoleAsync(adminUser, Roles.Admin);
        }

        if (medicoUser == null)
        {
            var medico = new Medico
            {
                UserName = "medico@medico.medico",
                Email = "medico@medico.medico",
                Nome = "ze",
                DataNascimento = DateOnly.FromDateTime(DateTime.Now),
                Genero = false,
                CPF = 00000011,
                CEP = 123,
                NumeroCasa = "2",
                Telefone = "44040404",
                SecurityStamp = Guid.NewGuid().ToString(),
                CRM = "123",
                Especialidade = "cardiologista",
                Ativo = true
            };
            try
            {
                await medicoManager.CreateAsync(medico, "123Carlos@");
                await medicoManager.AddToRoleAsync(medico, Roles.Medico);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}