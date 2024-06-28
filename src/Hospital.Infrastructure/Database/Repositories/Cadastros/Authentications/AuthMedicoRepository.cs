/* using Hospital.Application.Dto.Input.Authentications; */
/* using Hospital.Domain.Entities; */
/* using Hospital.Domain.Entities.Cadastros; */
/* using Hospital.Domain.Repositories.Cadastros.Authentications; */

/* using Microsoft.AspNetCore.Identity; */
/* using Microsoft.EntityFrameworkCore; */

/* namespace Hospital.Infrastructure.Database.Repositories.Cadastros.Authentications; */
/* public class AuthMedicoRepository : AuthRepository<Medico, RegisterRequestMedicoDto>, */
/* IAuthMedicoRepository */
/* { */
/*     private readonly UserManager<Medico> _manager; */
/*     public AuthMedicoRepository( */
/*         UserManager<Medico> userManager) : base(userManager, Roles.Medico) */
/*     { */
/*         _manager = userManager; */
/*     } */

/*     public override async Task<bool> CheckIfCadastroExistsAsync(RegisterRequestMedicoDto request) */
/*     { */
/*         var result = await _manager.Users.FirstOrDefaultAsync( */
/*             user => user.Email == request.Email */
/*                 || user.CPF == request.CPF */
/*                 || user.CRM == request.CRM); */
/*         return result != null; */
/*     } */
/* } */