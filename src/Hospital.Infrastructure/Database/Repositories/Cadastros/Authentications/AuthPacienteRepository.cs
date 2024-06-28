/* using Hospital.Application.Dto.Input.Authentications; */
/* using Hospital.Domain.Entities; */
/* using Hospital.Domain.Entities.Cadastros; */
/* using Hospital.Domain.Repositories.Cadastros.Authentications; */

/* using Microsoft.AspNetCore.Identity; */
/* using Microsoft.EntityFrameworkCore; */

/* namespace Hospital.Infrastructure.Database.Repositories.Cadastros.Authentications; */
/* public class AuthPacienteRepository : AuthRepository<Paciente, RegisterRequestPacienteDto>, */
/* IAuthPacienteRepository */
/* { */
/*     private readonly UserManager<Paciente> _manager; */
/*     public AuthPacienteRepository( */
/*         UserManager<Paciente> userManager) : base(userManager, Roles.Paciente) */
/*     { */
/*         _manager = userManager; */
/*     } */

/*     public override async Task<bool> CheckIfCadastroExistsAsync(RegisterRequestPacienteDto request) */
/*     { */
/*         // TODO: tentar deixar isso mais bonito */
/*         var result = await _manager.Users.FirstOrDefaultAsync( */
/*             user => user.Email == request.Email */
/*                 || user.CPF == request.CPF); */

/*         return result != null; */
/*     } */
/* } */