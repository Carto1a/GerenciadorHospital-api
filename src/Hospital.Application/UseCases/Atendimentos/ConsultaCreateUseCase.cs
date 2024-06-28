/* using Hospital.Application.Dto.Input.Atendimentos; */
/* using Hospital.Application.Exceptions; */
/* using Hospital.Application.Mappers; */
/* using Hospital.Domain.Entities.Atendimentos; */
/* using Hospital.Domain.Enums; */
/* using Hospital.Domain.Repositories; */
/* using Hospital.Domain.Repositories.Agendamentos; */
/* using Hospital.Domain.Repositories.Atendimentos; */
/* using Hospital.Domain.Repositories.Cadastros; */

/* namespace Hospital.Application.UseCases.Atendimentos; */
/* public class ConsultaCreateUseCase */
/* { */
/*     private readonly IUnitOfWork _unitOfWork; */
/*     private readonly IConsultaRepository _consultaRepository; */
/*     private readonly IMedicoRepository _medicoRepository; */
/*     private readonly IPacienteRepository _pacienteRepository; */
/*     private readonly IConvenioRepository _convenioRepository; */
/*     private readonly IConsultaAgendamentoRepository _consultaAgendamentoRepository; */
/*     public ConsultaCreateUseCase( */
/*         IUnitOfWork unitOfWork, */
/*         IConsultaRepository consultaRepository, */
/*         IMedicoRepository medicoRepository, */
/*         IPacienteRepository pacienteRepository, */
/*         IConvenioRepository convenioRepository, */
/*         IConsultaAgendamentoRepository consultaAgendamentoRepository) */
/*     { */
/*         _unitOfWork = unitOfWork; */
/*         _consultaRepository = consultaRepository; */
/*         _medicoRepository = medicoRepository; */
/*         _pacienteRepository = pacienteRepository; */
/*         _convenioRepository = convenioRepository; */
/*         _consultaAgendamentoRepository = consultaAgendamentoRepository; */
/*     } */

/*     public async Task<Guid> Handler( */
/*         ConsultaCreateDto request) */
/*     { */
/*         var findAgendamento = await _consultaAgendamentoRepository */
/*             .GetByIdAsync(request.AgendamentoId); */
/*         if (findAgendamento == null) */
/*             throw new ApplicationLayerException( */
/*                 $"Agendamento não encontrado: {request.AgendamentoId}", */
/*                 "Agendamento não encontrado"); */

/*         if (findAgendamento.Status == AgendamentoStatus.Cancelado */
/*             || findAgendamento.Status == AgendamentoStatus.Realizado) */
/*             throw new ApplicationLayerException( */
/*                 $"Agendamento já foi {findAgendamento.Status}", */
/*                 "Agendamento já foi cancelado ou realizado"); */

/*         if (findAgendamento.Status != AgendamentoStatus.EmEspera) */
/*             throw new ApplicationLayerException( */
/*                 $"Agendamento não está em espera: {findAgendamento.Status}", */
/*                 "Agendamento não está em espera"); */

/*         var consulta = request.ToDomain(null); */
/*         consulta.LoadInfoFromAgendamento(findAgendamento); */

/*         var id = await _consultaRepository.CreateAsync(consulta); */
/*         findAgendamento.Realizar(); */
/*         _consultaAgendamentoRepository.UpdateAsync(findAgendamento); */
/*         await _unitOfWork.SaveAsync(); */

/*         return id; */
/*     } */
/* } */