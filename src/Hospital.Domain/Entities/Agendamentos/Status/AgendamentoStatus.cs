using Hospital.Domain.Entities.Atendimentos;
using Hospital.Domain.Enums;
using Hospital.Domain.Exceptions;

namespace Hospital.Domain.Entities.Agendamentos.Status;
public abstract class AgendamentoStatus
{
    public AgendamentoStatusEnum StatusCode { get; set; }

    public virtual void CalcularMultaAtraso(
        Agendamento agendamento, Func<decimal> calculo)
    {
        throw new DomainException(
            "A multa não pode ser calculada.");
    }

    public virtual void Realizar(Agendamento agendamento, Atendimento atendimento)
    {
        throw new DomainException(
            "O agendamento não pode ser realizado.");
    }

    public virtual void EmEspera(Agendamento agendamento)
    {
        throw new DomainException(
            "O agendamento não pode ser colocado em espera.");
    }

    public virtual void EmAndamento(Agendamento agendamento)
    {
        throw new DomainException(
            "O agendamento não pode ser colocado em andamento.");
    }

    public virtual void Ausente(Agendamento agendamento)
    {
        throw new DomainException(
            "O agendamento não pode ser colocado como ausente.");
    }

    public virtual void Cancelar(Agendamento agendamento)
    {
        throw new DomainException(
            "O agendamento não pode ser cancelado.");
    }
}