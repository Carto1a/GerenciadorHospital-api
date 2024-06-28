/* using Hospital.Application.Dto.Input.Atendimentos; */
/* using Hospital.Application.Exceptions; */
/* using Hospital.Domain.Entities.Atendimentos; */
/* using Hospital.Domain.Enums; */
/* using Hospital.Domain.Repositories; */
/* using Hospital.Domain.Repositories.Agendamentos; */
/* using Hospital.Domain.Repositories.Atendimentos; */
/* using Hospital.Domain.Repositories.Cadastros; */

/* namespace Hospital.Application.UseCases.Atendimentos; */
/* public class RetornoCreateUseCase */
/* { */
/*     private readonly IConsultaRepository _consultaRepository; */
/*     private readonly IRetornoAgendamentoRepository _retornoAgendamentoRepository; */
/*     private readonly IMedicoRepository _medicoRepository; */
/*     private readonly IPacienteRepository _pacienteRepository; */
/*     private readonly IRetornoRepository _retornoRepository; */
/*     private readonly IUnitOfWork _uow; */

/*     public RetornoCreateUseCase( */
/*         IConsultaRepository consultaRepository, */
/*         IRetornoAgendamentoRepository retornoAgendamentoRepository, */
/*         IMedicoRepository medicoRepository, */
/*         IPacienteRepository pacienteRepository, */
/*         IRetornoRepository retornoRepository, */
/*         IUnitOfWork uow) */
/*     { */
/*         _consultaRepository = consultaRepository; */
/*         _retornoAgendamentoRepository = retornoAgendamentoRepository; */
/*         _medicoRepository = medicoRepository; */
/*         _pacienteRepository = pacienteRepository; */
/*         _retornoRepository = retornoRepository; */
/*         _uow = uow; */
/*     } */

/*     public async Task<Guid> Handler(RetornoCreateDto request) */
/*     { */
/*         var findConsulta = await _consultaRepository */
/*             .GetByIdAsync(request.ConsultaId); */
/*         if (findConsulta == null) */
/*             throw new ApplicationLayerException( */
/*                 $"Consulta não encontrada: {request.ConsultaId}", */
/*                 "Consulta não encontrada"); */

/*         var findAgendamento = await _retornoAgendamentoRepository */
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

/*         retorno.LoadInfoFromAgendamento(findAgendamento); */

/*         var id = await _retornoRepository.CreateAsync(retorno); */
/*         findAgendamento.Realizar(); */
/*         _retornoAgendamentoRepository.UpdateAsync(findAgendamento); */
/*         await _uow.SaveAsync(); */

/*         return id; */
/*     } */
/* } */