/* using Hospital.Application.Exceptions; */
/* using Hospital.Domain.Enums; */
/* using Hospital.Domain.Repositories; */
/* using Hospital.Domain.Repositories.Agendamentos; */

/* namespace Hospital.Application.UseCases.Agendamentos; */
/* public class AgendamentoConsultaCancelUseCase */
/* { */
/*     private readonly IConsultaAgendamentoRepository _repository; */
/*     private readonly IUnitOfWork _unitOfWork; */
/*     public AgendamentoConsultaCancelUseCase( */
/*         IConsultaAgendamentoRepository repository, */
/*         IUnitOfWork unitOfWork) */
/*     { */
/*         _repository = repository; */
/*         _unitOfWork = unitOfWork; */
/*     } */

/*     public async Task Handler(Guid id) */
/*     { */
/*         var agendamento = await _repository.GetByIdAsync(id); */
/*         if (agendamento == null) */
/*             throw new ApplicationLayerException( */
/*                 $"Agendamento não encontrado: {id}", */
/*                 "Agendamento não encontrado"); */

/*         var cantCancel = AgendamentoStatusEnum.Cancelado */
/*             | AgendamentoStatusEnum.Realizado */
/*             | AgendamentoStatusEnum.EmEspera */
/*             | AgendamentoStatusEnum.Ausencia */
/*             | AgendamentoStatusEnum.EmAndamento; */

/*         if (agendamento.Status.HasFlag(cantCancel)) */
/*             throw new ApplicationLayerException( */
/*                 $"Agendamento já foi {agendamento.Status}", */
/*                 "Agendamento já foi cancelado ou realizado"); */

/*         agendamento.Cancelar(); */
/*         await _repository.UpdateAsync(agendamento); */
/*         await _unitOfWork.SaveAsync(); */
/*     } */
/* } */