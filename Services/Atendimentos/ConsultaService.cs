
/* using Hospital.Database; */
/* using Hospital.Dto.Atendimento.Create; */
/* using Hospital.Dto.Atendimento.Update; */
/* using Hospital.Models.Agendamentos; */
/* using Hospital.Models.Atendimento; */
/* using Hospital.Repository.Atendimentos.Interfaces; */
/* using Hospital.Repository.Cadastros.Interfaces; */
/* using Hospital.Service.Agendamentos.Interfaces; */
/* using Hospital.Service.Atendimentos.Interfaces; */

/* namespace Hospital.Service.Atendimentos; */
/* public class ConsultaService */
/* : AtendimentoService< */
/*     Consulta, */
/*     ConsultaAgendamento, */
/*     ConsultaCreationDto, */
/*     ConsultaUpdateDto>, */
/* IConsultaService */
/* { */
/*     private readonly ILogger<ConsultaService> _logger; */
/*     private readonly IConsultaRepository _repo; */
/*     private readonly IConsultaAgendamentoService _agendametoService; */
/*     private readonly IPacienteRepository _pacienteRepo; */
/*     private readonly IMedicoRepository _medicoRepo; */
/*     private readonly AppDbContext _ctx; */
/*     public ConsultaService( */
/*         IPacienteRepository paciente, */
/*         IMedicoRepository medico, */
/*         IConsultaRepository repository, */
/*         IConsultaAgendamentoService agendamento, */
/*         AppDbContext context, */
/*         ILogger<ConsultaService> logger) */
/*     : base(paciente, medico, repository, agendamento, context, logger) */
/*     { */
/*         _pacienteRepo = paciente; */
/*         _medicoRepo = medico; */
/*         _ctx = context; */
/*         _repo = repository; */
/*         _agendametoService = agendamento; */
/*         _logger = logger; */
/*         _logger.LogDebug(1, $"NLog injected into ConsultaService"); */
/*     } */
/*     /1* public async Task<Result> Create(ConsultaCreationDto request) *1/ */
/*     /1* { *1/ */
/*     /1*     var resMedico = _medicoRepo *1/ */
/*     /1*         .GetMedicoById(request.MedicoId); *1/ */
/*     /1*     if (resMedico.IsFailed) *1/ */
/*     /1*         return Result.Fail("Não foi possivel achar o medico"); *1/ */

/*     /1*     var resPaciente = _pacienteRepo *1/ */
/*     /1*         .GetPacienteById(request.PacienteId); *1/ */
/*     /1*     if (resPaciente.IsFailed) *1/ */
/*     /1*         return Result.Fail("Não foi possivel achar o paciente"); *1/ */

/*     /1*     var resAgendamendo = await _agendametoService *1/ */
/*     /1*         .GetAgendamentoById(request.AgendamentoId); *1/ */
/*     /1*     if (resAgendamendo.IsFailed) *1/ */
/*     /1*         return Result.Fail("Não foi possivel achar o agendamento"); *1/ */

/*     /1*     Consulta atividade = new(); *1/ */
/*     /1*     atividade *1/ */
/*     /1*         .Creation(request, resMedico.Value, resPaciente.Value); *1/ */
/*     /1*     var respose = await _repo *1/ */
/*     /1*         .Create(atividade); *1/ */
/*     /1*     if (respose.IsFailed) *1/ */
/*     /1*         return Result.Fail("Não foi possivel criar o atendimento"); *1/ */

/*     /1*     var resLink = await _agendametoService *1/ */
/*     /1*         .LinkAtendimento(respose.Value, request.AgendamentoId); *1/ */
/*     /1*     if (resLink.IsFailed) *1/ */
/*     /1*         return Result.Fail("Não foi possivel criar o atendimento"); *1/ */

/*     /1*     return Result.Ok(); *1/ */
/*     /1* } *1/ */
/*     /1* public Result<List<Consulta>> GetByDate( *1/ */
/*     /1*     DateTime minDate, DateTime maxDate, *1/ */
/*     /1*     int limit, int page) *1/ */
/*     /1* { *1/ */
/*     /1*     var results = new Result[10]; *1/ */
/*     /1*     Result<List<Consulta>> resultRetorn; *1/ */

/*     /1*     if (limit < 1 || limit > 100) *1/ */
/*     /1*         results.Append(Result.Fail("limite com valor errado")); *1/ */

/*     /1*     if (page < 0) *1/ */
/*     /1*         results.Append(Result.Fail("Page com valor negativo")); *1/ */

/*     /1*     resultRetorn = Result.Merge(results); *1/ */
/*     /1*     if (resultRetorn.IsFailed) *1/ */
/*     /1*         return resultRetorn; *1/ */

/*     /1*     var respose = _repo.GetByDate(minDate, maxDate, limit, page); *1/ */
/*     /1*     return respose; *1/ */
/*     /1* } *1/ */
/*     /1* public async Task<Result<Consulta>> GetById(Guid id) *1/ */
/*     /1* { *1/ */
/*     /1*     var respose = await _repo.GetById(id); *1/ */
/*     /1*     if (respose.IsFailed) *1/ */
/*     /1*         return Result.Fail("não foi possivel pegar a atividade"); *1/ */

/*     /1*     return respose; *1/ */
/*     /1* } *1/ */
/*     /1* public Result<List<Consulta>> GetByMedico( *1/ */
/*     /1*     Guid medicoId, int limit, int page = 0) *1/ */
/*     /1* { *1/ */
/*     /1*     var results = new List<Result<List<Consulta>>>(); *1/ */
/*     /1*     if (page < 0) *1/ */
/*     /1*         results.Add(Result.Fail("page é negativo")); *1/ */

/*     /1*     if (limit < 0) *1/ */
/*     /1*         results.Add(Result.Fail("limit é negativo")); *1/ */

/*     /1*     var respose = _repo.GetByMedico(medicoId, limit, page); *1/ */
/*     /1*     if (respose.IsFailed) *1/ */
/*     /1*         return Result.Fail("não foi possivel pegar a atividade"); *1/ */

/*     /1*     return respose; *1/ */
/*     /1* } *1/ */
/*     /1* public Result<List<Consulta>> GetByPaciente( *1/ */
/*     /1*     Guid pacienteId, int limit, int page = 0) *1/ */
/*     /1* { *1/ */
/*     /1*     var results = new List<Result<List<Consulta>>>(); *1/ */
/*     /1*     if (page < 0) *1/ */
/*     /1*         results.Add(Result.Fail("page é negativo")); *1/ */

/*     /1*     if (limit < 0) *1/ */
/*     /1*         results.Add(Result.Fail("limit é negativo")); *1/ */

/*     /1*     var respose = _repo.GetByPaciente(pacienteId, limit, page); *1/ */
/*     /1*     if (respose.IsFailed) *1/ */
/*     /1*         return Result.Fail("não foi possivel pegar a atividade"); *1/ */

/*     /1*     return respose; *1/ */
/*     /1* } *1/ */
/*     /1* public Result<List<Consulta>> GetByQuery( *1/ */
/*     /1*     AtendimentoGetByQueryDto query) *1/ */
/*     /1* { *1/ */
/*     /1*     var results = new List<Result<List<Consulta>>>(); *1/ */
/*     /1*     if (query.Page < 0) *1/ */
/*     /1*         results.Add(Result.Fail("page é negativo")); *1/ */

/*     /1*     if (query.Limit < 0) *1/ */
/*     /1*         results.Add(Result.Fail("limit é negativo")); *1/ */

/*     /1*     if (query.Limit == null) *1/ */
/*     /1*         query.Limit = 10; *1/ */

/*     /1*     if (query.Page == null) *1/ */
/*     /1*         query.Page = 0; *1/ */

/*     /1*     var respose = _repo.GetByQuery(query); *1/ */
/*     /1*     if (respose.IsFailed) *1/ */
/*     /1*         return Result.Fail("não foi possivel pegar a atividade"); *1/ */

/*     /1*     return respose; *1/ */
/*     /1* } *1/ */

/*     /1* public Task<Result> Update(ConsultaUpdateDto request, Guid id) *1/ */
/*     /1* { *1/ */
/*     /1*     throw new NotImplementedException(); *1/ */
/*     /1* } *1/ */
/* } */