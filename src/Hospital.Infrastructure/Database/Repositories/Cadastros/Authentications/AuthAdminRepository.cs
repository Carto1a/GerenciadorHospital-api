/* using System.Linq; */

/* using Hospital.Application.Dto.Input.Authentications; */
/* using Hospital.Domain.Entities; */
/* using Hospital.Domain.Entities.Cadastros; */
/* using Hospital.Domain.Repositories.Cadastros; */
/* using Hospital.Infrastructure.Database.Models; */

/* using Microsoft.AspNetCore.Identity; */
/* using Microsoft.EntityFrameworkCore; */

/* namespace Hospital.Infrastructure.Database.Repositories.Cadastros.Authentications; */

/* public class AuthAdminRepository : AuthRepository<Admin, RegisterRequestAdminDto>, */
/* IAdminRepository */
/* { */
/*     private readonly UserManager<Admin> _manager; */
/*     public AuthAdminRepository( */
/*         UserManager<Admin> userManager) : base(userManager, Roles.Admin) */
/*     { */
/*         _manager = userManager; */
/*     } */

/*     public override async Task<bool> CheckIfCadastroExistsAsync(Admin cadastro) */
/*     { */
/*         var result = await _manager.Users.FirstOrDefaultAsync(c => */
/*             c.CheckUniqueness(cadastro)); */
/*         return result != null; */
/*     } */
/* } */