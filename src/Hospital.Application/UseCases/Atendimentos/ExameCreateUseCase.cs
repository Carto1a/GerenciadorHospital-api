/* using Hospital.Application.Dto.Input.Atendimentos; */
/* using Hospital.Domain.Entities.Atendimentos; */
/* using Hospital.Domain.Enums; */
/* using Hospital.Domain.Exceptions; */
/* using Hospital.Domain.Repositories; */
/* using Hospital.Domain.Repositories.Agendamentos; */
/* using Hospital.Domain.Repositories.Atendimentos; */

/* namespace Hospital.Application.UseCases.Atendimentos; */
/* public class ExameCreateUseCase */
/* { */
/*     private readonly IUnitOfWork _unitOfWork; */
/*     private readonly IExameRepository _exameRepository; */
/*     private readonly IExameAgendamentoRepository _exameAgendamentoRepository; */
/*     private readonly IConsultaAgendamentoRepository _consultaAgendamentoRepository; */
/*     private readonly IConsultaRepository _consultaRepository; */

/*     public ExameCreateUseCase( */
/*         IUnitOfWork unitOfWork, */
/*         IExameRepository exameRepository, */
/*         IExameAgendamentoRepository exameAgendamentoRepository, */
/*         IConsultaAgendamentoRepository consultaAgendamentoRepository, */
/*         IConsultaRepository consultaRepository) */
/*     { */
/*         _unitOfWork = unitOfWork; */
/*         _exameRepository = exameRepository; */
/*         _exameAgendamentoRepository = exameAgendamentoRepository; */
/*         _consultaAgendamentoRepository = consultaAgendamentoRepository; */
/*         _consultaRepository = consultaRepository; */
/*     } */

/*     public async Task<Guid> Handler(ExameCreateDto request) */
/*     { */
/*         var exame = new Exame(request); */
/*         var findAgendamento = await _exameAgendamentoRepository */
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

/*         var findConsulta = await _consultaRepository */
/*             .GetByIdAsync(request.ConsultaId); */
/*         if (findConsulta == null) */
/*             throw new ApplicationLayerException( */
/*                 $"Agendamento não é uma consulta: {findAgendamento.Id}", */
/*                 "Agendamento não é uma consulta"); */

/*         exame.LoadInfoFromAgendamento(findAgendamento); */

/*         var id = await _exameRepository.CreateAsync(exame); */

/*         findAgendamento.Realizar(); */
/*         _exameAgendamentoRepository.UpdateAsync(findAgendamento); */

/*         if (request.Status == ExameStatus.Processando) */
/*         { */
/*             findConsulta.Status = ConsultaStatus.Processando; */
/*             _consultaRepository.UpdateAsync(findConsulta); */
/*         } */

/*         await _unitOfWork.SaveAsync(); */

/*         return id; */
/*     } */
/* } */