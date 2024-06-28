/* using Hospital.Application.Exceptions; */
/* using Hospital.Domain.Enums; */
/* using Hospital.Domain.Repositories; */
/* using Hospital.Domain.Repositories.Agendamentos; */

/* namespace Hospital.Application.UseCases.Agendamentos; */
/* public class AgendamentoRetornoEmEsperaUseCase */
/* { */
/*     private readonly IUnitOfWork _unitOfWork; */
/*     private readonly IRetornoAgendamentoRepository _retornoAgendamentoRepository; */

/*     public AgendamentoRetornoEmEsperaUseCase( */
/*         IUnitOfWork unitOfWork, */
/*         IRetornoAgendamentoRepository retornoAgendamentoRepository) */
/*     { */
/*         _unitOfWork = unitOfWork; */
/*         _retornoAgendamentoRepository = retornoAgendamentoRepository; */
/*     } */

/*     public async Task Handler(Guid agendamentoId) */
/*     { */
/*         var agendamento = await _retornoAgendamentoRepository */
/*             .GetByIdAsync(agendamentoId); */
/*         if (agendamento == null) */
/*             throw new ApplicationLayerException( */
/*                 $"Agendamento não encontrado: {agendamentoId}", */
/*                 "Agendamento não encontrado"); */

/*         if (agendamento.Status == AgendamentoStatusEnum.Cancelado */
/*             || agendamento.Status == AgendamentoStatusEnum.Realizado) */
/*             throw new ApplicationLayerException( */
/*                 $"Agendamento já foi {agendamento.Status}", */
/*                 "Agendamento já foi cancelado ou realizado"); */

/*         if (agendamento.Status == AgendamentoStatusEnum.EmEspera) */
/*             throw new ApplicationLayerException( */
/*                 $"Agendamento já está em espera: {agendamento.Status}", */
/*                 "Agendamento já está em espera"); */

/*         if (agendamento.Atrasado(DateTime.Now)) */
/*             agendamento.CalcularMulta(null); */

/*         if (agendamento.Ausente(DateTime.Now)) */
/*         { */
/*             agendamento.Ausencia(); */
/*             _retornoAgendamentoRepository.UpdateAsync(agendamento); */
/*             await _unitOfWork.SaveAsync(); */
/*             throw new ApplicationLayerException( */
/*                 $"Agendamento cancelado por atraso: {agendamento.DataHora}", */
/*                 "Agendamento cancelado por atraso"); */
/*         } */

/*         agendamento.EmEspera(); */
/*         _retornoAgendamentoRepository.UpdateAsync(agendamento); */
/*         await _unitOfWork.SaveAsync(); */
/*     } */
/* } */