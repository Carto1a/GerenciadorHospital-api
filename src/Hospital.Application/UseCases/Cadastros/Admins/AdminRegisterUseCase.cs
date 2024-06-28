/* using Hospital.Application.Dto.Input.Authentications; */
/* using Hospital.Domain.Entities.Cadastros; */
/* using Hospital.Domain.Repositories.Cadastros; */

/* using Microsoft.Extensions.Logging; */

/* namespace Hospital.Application.UseCases.Cadastros.Admins; */
/* public class AdminRegisterUseCase */
/* { */
/*     private readonly ILogger<AdminRegisterUseCase> _logger; */
/*     private readonly IAdminRepository _adminManager; */
/*     public AdminRegisterUseCase( */
/*         IAdminRepository adminManager, */
/*         ILogger<AdminRegisterUseCase> logger) */
/*     { */
/*         _adminManager = adminManager; */
/*         _logger = logger; */
/*         _logger.LogDebug(1, $"NLog injected into AuthAdminRegisterService"); */
/*     } */
/*     public async Task<Guid> Handler( */
/*         RegisterRequestAdminDto request) */
/*     { */
/*         _logger.LogInformation($"Registrando admin: {request.Email}"); */

/*         var findAdmin = await _adminManager */
/*             .CheckIfCadastroExistsAsync(request); */
/*         if (findAdmin) */
/*             throw new ApplicationException( */
/*                 $"Cadastro de admin já existe: {request.Email}", */
/*                 "Senha | Email | CPF Inválidos"); */

/*         var admin = new Admin(request); */

/*         await _adminManager.CreateAsync(admin, request.Password); */

/*         _logger.LogInformation($"Admin registrado: {admin.Id}"); */
/*         return admin.Id; */
/*     } */
/* } */