/* using Hospital.Application.Dto.Input.Agendamentos; */
/* using Hospital.Application.Exceptions; */
/* using Hospital.Application.Mappers; */
/* using Hospital.Domain.Entities; */
/* using Hospital.Domain.Entities.Agendamentos; */
/* using Hospital.Domain.Repositories; */
/* using Hospital.Domain.Repositories.Agendamentos; */
/* using Hospital.Domain.Repositories.Cadastros; */

/* using Microsoft.Extensions.Logging; */

/* namespace Hospital.Application.UseCases.Agendamentos; */
/* public class AgendamentoConsultaCreateUseCase */
/* { */
/*     private readonly ILogger<AgendamentoConsultaCreateUseCase> _logger; */
/*     private readonly IUnitOfWork _uow; */
/*     private readonly IMedicoRepository _medicoRepository; */
/*     private readonly IPacienteRepository _pacienteRepository; */
/*     private readonly IConvenioRepository _convenioRepository; */
/*     private readonly IConsultaAgendamentoRepository _consultaAgendamentoRepository; */
/*     public AgendamentoConsultaCreateUseCase( */
/*         ILogger<AgendamentoConsultaCreateUseCase> logger, */
/*         IUnitOfWork uow, */
/*         IMedicoRepository medicoRepository, */
/*         IPacienteRepository pacienteRepository, */
/*         IConvenioRepository convenioRepository, */
/*         IConsultaAgendamentoRepository consultaAgendamentoRepository) */
/*     { */
/*         _logger = logger; */
/*         _uow = uow; */
/*         _medicoRepository = medicoRepository; */
/*         _pacienteRepository = pacienteRepository; */
/*         _convenioRepository = convenioRepository; */
/*         _consultaAgendamentoRepository = consultaAgendamentoRepository; */
/*     } */

/*     public async Task<Guid> Handler( */
/*         AgendamentoConsultaCreateDto request) */
/*     { */
/*         _logger.LogInformation($"Criando agendamento de Consulta: {request.DataHora}"); */

/*         var repo = _consultaAgendamentoRepository; */

/*         var findMedico = await _medicoRepository */
/*             .GetByIdAtivoAsync(request.MedicoId); */
/*         if (findMedico == null) */
/*             throw new ApplicationLayerException( */
/*                 $"Médico não encontrado: {request.MedicoId}", */
/*                 "Médico não encontrado"); */

/*         var findPaciente = await _pacienteRepository */
/*             .GetByIdAtivoAsync(request.PacienteId); */
/*         if (findPaciente == null) */
/*             throw new ApplicationLayerException( */
/*                 $"Paciente não encontrado: {request.PacienteId}", */
/*                 "Paciente não encontrado"); */

/*         var findAgendamentos = await repo */
/*             .GetByDataHoraMedicoAsync(request.DataHora, request.MedicoId); */
/*         if (findAgendamentos.Count > 0) */
/*             throw new ApplicationLayerException( */
/*                 $"Horario ocupado para agendamento: {request.DataHora}", */
/*                 "Horario ocupado para agendamento"); */

/*         Convenio? findConvenio = null; */
/*         if (request.ConvenioId != null) */
/*         { */
/*             findConvenio = await _convenioRepository */
/*                 .GetByIdAtivoAsync((Guid)request.ConvenioId); */
/*             if (findConvenio == null) */
/*                 throw new ApplicationLayerException( */
/*                     $"Convênio não encontrado: {request.ConvenioId}", */
/*                     "Convênio não encontrado"); */
/*         } */

/*         var agendamento = request.ToDomain(findMedico, findPaciente, findConvenio); */

/*         var id = await repo.CreateAsync(agendamento); */
/*         await _uow.SaveAsync(); */

/*         _logger.LogInformation($"Agendamento de Consulta criado: {request.DataHora}"); */
/*         return id; */
/*     } */
/* } */