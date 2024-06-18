using Hospital.Domain.Entities;
using Hospital.Domain.Entities.Cadastros;
using Hospital.Domain.Enums;
using Hospital.Infrastructure.Database;

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
        var pacienteManager = services.GetRequiredService<UserManager<Paciente>>();
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

        var adminUser = await userManager.FindByEmailAsync("admin@admin.admin");

        var medicoUser = await medicoManager.FindByEmailAsync("medico@medico.medico");

        var pacienteUser = await pacienteManager.FindByEmailAsync("paciente@p.p");

        if (adminUser == null)
        {
            adminUser = new Admin
            {
                UserName = "admin@admin.admin",
                Email = "admin@admin.admin",
                Nome = "ANA",
                Sobrenome = "DOS SANTOS",
                DataNascimento = DateOnly.FromDateTime(DateTime.Now.AddYears(-20)),
                Genero = GeneroEnum.Outro,
                CPF = "09787717027",
                CEP = "69200970",
                NumeroCasa = "2",
                Telefone = "1130654894",
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
                DataNascimento = DateOnly.FromDateTime(DateTime.Now.AddYears(-30)),
                Genero = GeneroEnum.Outro,
                CPF = "01905130040",
                CEP = "64034538",
                NumeroCasa = "2",
                Telefone = "11984825657",
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

        if (pacienteUser == null)
        {
            var paciente = new Paciente
            {
                UserName = "paciente@p.p",
                Email = "paciente@p.p",
                Nome = "JOAO",
                Sobrenome = "DA SILVA",
                DataNascimento = DateOnly.FromDateTime(DateTime.Now.AddYears(-20)),
                Genero = GeneroEnum.Outro,
                CPF = "19787717027",
                CEP = "69200970",
                NumeroCasa = "2",
                Telefone = "1140654894",
                SecurityStamp = Guid.NewGuid().ToString(),
                Ativo = true
            };

            try
            {
                await pacienteManager.CreateAsync(paciente, "123Carlos@");
                await pacienteManager.AddToRoleAsync(paciente, Roles.Paciente);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}