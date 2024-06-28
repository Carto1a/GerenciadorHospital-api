/* using System.ComponentModel.DataAnnotations; */

/* using Hospital.Domain.Entities.Agendamentos; */
/* using Hospital.Domain.Enums; */

/* namespace Hospital.Application.Dto.Output.Agendamentos; */
/* public record AgendamentoOutputDto */
/* { */
/*     public Guid Id { get; init; } */
/*     public Guid MedicoId { get; init; } */
/*     public Guid PacienteId { get; init; } */
/*     public Guid? ConvenioId { get; init; } */

/*     [EnumDataType(typeof(AgendamentoStatus))] */
/*     public AgendamentoStatus Status { get; init; } */
/*     public decimal Custo { get; init; } */
/*     public decimal CustoFinal { get; init; } */

/*     public DateTime DataHora { get; init; } */
/*     public DateTime Criado { get; init; } */
/*     public bool Ativo { get; init; } */

/*     public AgendamentoOutputDto(Agendamento original) */
/*     { */
/*         Id = original.Id; */
/*         MedicoId = original.MedicoId; */
/*         PacienteId = (Guid)original.PacienteId!; */
/*         ConvenioId = original.ConvenioId; */
/*         Status = original.Status; */
/*         Custo = original.Custo; */
/*         CustoFinal = original.CustoFinal; */
/*         DataHora = original.DataHora; */
/*         Criado = original.Criado; */
/*         Ativo = original.Ativo; */
/*     } */
/* } */