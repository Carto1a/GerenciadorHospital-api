using System.ComponentModel.DataAnnotations;

using Hospital.Application.Dto.Input.Atendimentos;
using Hospital.Domain.Entities.Agendamentos;
using Hospital.Domain.Enums;

namespace Hospital.Domain.Entities.Atendimentos;
public class Consulta : Atendimento
{
    public virtual ConsultaAgendamento? Agendamento { get; set; }
    public virtual ICollection<ExameAgendamento>? AgendamentosExames { get; set; }
    public virtual ICollection<Retorno>? Retornos { get; set; }
    public virtual ICollection<Exame>? Exames { get; set; }
    public virtual ICollection<Laudo>? Laudos { get; set; }

    [EnumDataType(typeof(ConsultaStatus))]
    public ConsultaStatus Status { get; set; }
    public Consulta() { }

    public Consulta(ConsultaCreateDto dto)
    {
        AgendamentoId = dto.AgendamentoId;
        Inicio = dto.Inicio;
        Fim = dto.Fim;
        Criado = DateTime.Now;
        Status = dto.Status;
    }

    public void Realizar() => Status = ConsultaStatus.Realizado;
    public void Processar() => Status = ConsultaStatus.Processando;
    public void Terminar() => Status = ConsultaStatus.Terminado;
    public void Ausente() => Status = ConsultaStatus.Ausencia;
}