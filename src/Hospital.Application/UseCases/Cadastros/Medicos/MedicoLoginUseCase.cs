/* using Hospital.Application.Dto.Input.Authentications; */
/* using Hospital.Application.Exceptions; */
/* using Hospital.Application.Services; */
/* using Hospital.Domain.Repositories.Cadastros; */

/* using Microsoft.Extensions.Logging; */

/* namespace Hospital.Application.UseCases.Cadastros.Medicos; */
/* public class MedicoLoginUseCase */
/* { */
/*     private readonly ILogger<MedicoLoginUseCase> _logger; */
/*     private readonly IMedicoRepository _manager; */
/*     private readonly IJwtTokenService _jwtTokenService; */
/*     public MedicoLoginUseCase( */
/*         ILogger<MedicoLoginUseCase> logger, */
/*         IMedicoRepository manager, */
/*         IJwtTokenService jwtTokenService) */
/*     { */
/*         _logger = logger; */
/*         _manager = manager; */
/*         _jwtTokenService = jwtTokenService; */
/*     } */

/*     public async Task<string> Handler( */
/*         LoginRequestMedicoDto request) */
/*     { */
/*         _logger.LogInformation($"Logando medico: {request.Email}"); */
/*         var user = await _manager */
/*             .FindByEmailAsync(request.Email); */

/*         // NOTE: brecha para side channel attack ao vivo */
/*         if (user == null) */
/*             throw new ApplicationLayerException( */
/*                 $"Cadastro de medico não existe: {request.Email}", */
/*                 "Email ou senha errada"); */

/*         if (!user.Ativo) */
/*             throw new ApplicationLayerException( */
/*                 $"Cadastro de medico inativo: {request.Email}", */
/*                 "Email ou senha errada"); */

/*         if (!await _manager */
/*             .CheckPasswordAsync(user, request.Password)) */
/*             throw new ApplicationLayerException( */
/*                 $"Senha de medico errada: {request.Email}", */
/*                 "Email ou senha errada"); */

/*         _logger.LogInformation( */
/*                 $"Gerando token para: {request.Email}"); */

/*         var userRoles = await _manager.GetRolesAsync(user); */

/*         var token = _jwtTokenService.GenerateUserToken( */
/*             user, userRoles); */

/*         _logger.LogInformation($"Medico logado: {request.Email}"); */
/*         return token; */
/*     } */
/* } */