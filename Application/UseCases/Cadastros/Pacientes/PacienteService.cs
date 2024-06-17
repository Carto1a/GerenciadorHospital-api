/* using System.Security.Claims; */

/* using FluentResults; */

/* using Hospital.Database; */
/* using Hospital.Enums; */
/* using Hospital.Extensions; */
/* using Hospital.Models.Cadastro; */
/* using Hospital.Repository.Cadastros.Interfaces; */
/* using Hospital.Service.Interfaces; */

/* using Microsoft.AspNetCore.Identity; */

/* namespace Hospital.Service.Cadastros; */
/* public class PacienteService */
/* : IPacienteService */
/* { */
/*     private readonly ILogger<PacienteService> _logger; */
/*     private readonly UserManager<Cadastro> _userManager; */
/*     private readonly AppDbContext _ctx; */
/*     private readonly IPacienteRepository _pacienteRepository; */
/*     private readonly IConfiguration _configuration; */
/*     public PacienteService( */
/*         AppDbContext ctx, */
/*         IPacienteRepository pacienteService, */
/*         IConfiguration configuration, */
/*         UserManager<Cadastro> userManager, */
/*         ILogger<PacienteService> logger) */
/*     { */
/*         _configuration = configuration; */
/*         _userManager = userManager; */
/*         _pacienteRepository = pacienteService; */
/*         _ctx = ctx; */
/*         _logger = logger; */
/*         _logger.LogDebug(1, "NLog injected into PacienteService"); */
/*     } */

/*     public Result<Paciente?> GetPacienteById(Guid pacienteId) */
/*     { */
/*         _logger.LogInformation($"Buscando paciente por id: {pacienteId}"); */
/*         var response = _pacienteRepository.GetPacienteById(pacienteId); */
/*         var result = response.ToResultDto(); */
/*         if (response.IsFailed) */
/*         { */
/*             _logger.LogError($"Não foi possivel achar o paciente: {pacienteId}"); */
/*             return Result.Fail("Não foi possivel achar o paciente"); */
/*         } */

/*         _logger.LogInformation($"Paciente encontrado: {pacienteId}"); */
/*         return Result.Ok(response.Value); */
/*     } */

/*     public Result<string> GetPacienteDocumento( */
/*         Guid id, */
/*         PacienteDocumentosEnum documentoTipo) */
/*     { */
/*         // TODO: deixar a controller que o id */
/*         _logger.LogInformation($"Buscando documento do paciente: {id}"); */
/*         var response = _pacienteRepository.GetPacienteById(id); */
/*         if (response.IsFailed) */
/*         { */
/*             _logger.LogError("Paciente não encontrado"); */
/*             return Result.Fail("Paciente não encontrado"); */
/*         } */

/*         var paciente = response.Value; */
/*         if (paciente == null) */
/*         { */
/*             _logger.LogError("Paciente não encontrado"); */
/*             return Result.Fail("Paciente não encontrado"); */
/*         } */

/*         var rootPath = _configuration["Paths:PacienteDocumentos"]; */
/*         if (rootPath == null) */
/*         { */
/*             _logger.LogError("Diretório de documentos não encontrado"); */
/*             throw new InvalidOperationException( */
/*                 "Paths:PacienteDocumentos not found in appsettings.json"); */
/*         } */
/*         // NOTE: feio */
/*         var path = String.Empty; */
/*         var DocName = String.Empty; */
/*         switch (documentoTipo) */
/*         { */
/*             case PacienteDocumentosEnum.Identificacao: */
/*                 DocName = paciente.ImgDocumento.ToString(); */
/*                 path = Path.Combine( */
/*                     rootPath, */
/*                     "Documentos", */
/*                     paciente.ImgDocumento.ToString()); */
/*                 break; */
/*             case PacienteDocumentosEnum.Convenio: */
/*                 var DocConvenio = paciente.ImgCarteiraConvenio; */
/*                 if (DocConvenio == null) */
/*                 { */
/*                     _logger.LogError("Paciente não tem documento de convenio"); */
/*                     return Result.Fail("Paciente não tem documento de convenio"); */
/*                 } */
/*                 DocName = DocConvenio.ToString(); */
/*                 path = Path.Combine( */
/*                     rootPath, */
/*                     "Convenios", */
/*                     DocConvenio.ToString()); */
/*                 break; */
/*             default: */
/*                 _logger.LogError("Tipo de documento não encontrado"); */
/*                 return Result.Fail("Tipo de documento não encontrado"); */
/*         } */
/*         if (!File.Exists(path)) */
/*         { */
/*             _logger.LogError($"Arquivo não achado de nome: {DocName}"); */
/*             return Result.Fail("Arquivo não achado"); */
/*         } */

/*         _logger.LogInformation($"Arquivo achado de nome: {DocName}"); */
/*         return Result.Ok(path); */
/*     } */

/*     public Result<string> GetPacienteDocumentoByGuid( */
/*         Guid guid, PacienteDocumentosEnum documentoTipo) */
/*     { */
/*         // TODO: deixar a controller que o id */
/*         _logger.LogInformation($"Buscando documento do paciente de guid: {guid.ToString()}"); */
/*         var rootPath = _configuration["Paths:PacienteDocumentos"]; */
/*         if (rootPath == null) */
/*         { */
/*             _logger.LogError("Diretório de documentos não encontrado"); */
/*             throw new InvalidOperationException( */
/*                 "Paths:PacienteDocumentos not found in appsettings.json"); */
/*         } */
/*         // NOTE: feio */
/*         var path = String.Empty; */
/*         switch (documentoTipo) */
/*         { */
/*             case PacienteDocumentosEnum.Identificacao: */
/*                 path = Path.Combine( */
/*                     rootPath, */
/*                     "Documentos", */
/*                     guid.ToString()); */
/*                 break; */
/*             case PacienteDocumentosEnum.Convenio: */
/*                 path = Path.Combine( */
/*                     rootPath, */
/*                     "Convenios", */
/*                     guid.ToString()); */
/*                 break; */
/*             default: */
/*                 _logger.LogError("Tipo de documento não encontrado"); */
/*                 return Result.Fail("Tipo de documento não encontrado"); */
/*         } */
/*         if (!File.Exists(path)) */
/*         { */
/*             _logger.LogError($"Arquivo não achado de nome: {guid.ToString()}"); */
/*             return Result.Fail("Arquivo não achado"); */
/*         } */

/*         _logger.LogInformation($"Arquivo achado de nome: {guid.ToString()}"); */
/*         return Result.Ok(path); */
/*     } */

/*     public Result<List<Paciente>> GetPacientes(int limit, int page = 0) */
/*     { */
/*         _logger.LogInformation($"Buscando pacientes: {limit} - {page}"); */
/*         var respose = _pacienteRepository.GetPacientes(limit, page); */
/*         if (respose.IsFailed) */
/*         { */
/*             _logger.LogError("Erro ao buscar pacientes"); */
/*             return Result.Fail("Erro ao buscar pacientes"); */
/*         } */

/*         _logger.LogInformation($"Pacientes encontrados: {respose.Value.Count}"); */
/*         return Result.Ok(respose.Value); */
/*     } */
/* } */