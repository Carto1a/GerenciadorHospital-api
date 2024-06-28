using Hospital.Domain.Enums;

namespace Hospital.Domain.Entities.Agendamentos.Status;
public class AgendamentoAgendado : AgendamentoStatus
{
    // NOTE: ta feio
    public override void CalcularMultaAtraso(
        Agendamento agendamento, Func<decimal> calculo)
    {
        agendamento.CustoAtraso = calculo();
    }

    public override void EmEspera(Agendamento agendamento)
    {
        agendamento.State = new AgendamentoEmEspera();
        agendamento.Status = AgendamentoStatusEnum.EmEspera;
    }

    // NOTE: não para estar aqui
    public override void EmAndamento(Agendamento agendamento)
    {
        agendamento.State = new AgendamentoEmAndamento();
        agendamento.Status = AgendamentoStatusEnum.EmAndamento;
    }

    public override void Cancelar(Agendamento agendamento)
    {
        agendamento.State = new AgendamentoCancelado();
        agendamento.Status = AgendamentoStatusEnum.Cancelado;
    }

    public override void Ausente(Agendamento agendamento)
    {
        agendamento.State = new AgendamentoAusente();
        agendamento.Status = AgendamentoStatusEnum.Ausencia;
    }
}