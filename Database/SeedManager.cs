using Hospital.Enums;
using Hospital.Models.Cadastro;

using Microsoft.AspNetCore.Identity;

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
        var context = services.GetRequiredService<AppDbContext>();
        var userManager = services.GetRequiredService<UserManager<Admin>>();
        var medicoManager = services.GetRequiredService<UserManager<Medico>>();
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

        var adminUser = await userManager.FindByEmailAsync("admin@admin.admin");

        var medicoUser = await medicoManager.FindByEmailAsync("medico@medico.medico");

        if (adminUser == null)
        {
            adminUser = new Admin
            {
                UserName = "admin@admin.admin",
                Email = "admin@admin.admin",
                Nome = "ANA",
                Sobrenome = "DOS SANTOS",
                DataNascimento = DateOnly.FromDateTime(DateTime.Now),
                Genero = GeneroEnum.Outro,
                CPF = "09787717027",
                CEP = "69200970",
                NumeroCasa = "2",
                Telefone = 1130654894,
                SecurityStamp = Guid.NewGuid().ToString(),
                Ativo = true
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
                Nome = "CARLOS EDUARDO",
                Sobrenome = "DA SILVA",
                DataNascimento = DateOnly.FromDateTime(DateTime.Now),
                Genero = GeneroEnum.Outro,
                CPF = "01905130040",
                CEP = "64034538",
                NumeroCasa = "2",
                Telefone = 11984825657,
                SecurityStamp = Guid.NewGuid().ToString(),
                CRM = 124901,
                CRMUF = "SP",
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