/* using Hospital.Application.Dto.Input.Agendamentos; */
/* using Hospital.Application.Dto.Output.Agendamentos; */
/* using Hospital.Domain.Entities.Agendamentos; */
/* using Hospital.Domain.Entities.Atendimentos; */
/* using Hospital.Domain.Enums; */
/* using Hospital.Domain.Repositories; */
/* using Hospital.Domain.Repositories.Agendamentos; */
/* using Hospital.Domain.Validators; */

/* namespace Hospital.Application.UseCases.Agendamentos; */
/* public class AgendamentoConsultaGetByQueryUseCase<T, TAgendamento, TQuery> */
/* where T : Atendimento, new() */
/* where TAgendamento : Agendamento, new() */
/* where TQuery : AgendamentoGetByQueryDto */
/* { */
/*     private readonly IUnitOfWork _uow; */
/*     private readonly IConsultaAgendamentoRepository _consultaAgendamentoRepository; */
/*     public AgendamentoConsultaGetByQueryUseCase( */
/*         IUnitOfWork uow, */
/*         IConsultaAgendamentoRepository consultaAgendamentoRepository) */
/*     { */
/*         _uow = uow; */
/*         _consultaAgendamentoRepository = consultaAgendamentoRepository; */
/*     } */

/*     public async Task<List<AgendamentoOutputDto>> Handler( */
/*         TQuery query) */
/*     { */
/*         var validator = new DomainValidator( */
/*             "Não foi possível buscar agendamentos"); */
/*         validator.Query((int)query.Limit!, (int)query.Page!); */

/*         if (query.Status != null) */
/*             validator.isInEnum( */
/*                 query.Status, */
/*                 typeof(AgendamentoStatus), */
/*                 "Status inválido"); */

/*         // NOTE: break code execution if validation fails */
/*         validator.Check(); */

/*         var agendamentos = await _consultaAgendamentoRepository */
/*             .GetByQueryDtoAsync(query); */

/*         return agendamentos; */
/*     } */
/* } */