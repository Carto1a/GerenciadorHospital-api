using Hospital.Domain.Enums;
using Hospital.Domain.Exceptions;

namespace Hospital.Domain.Entities.Agendamentos.Status;
public class AgendamentoAgendado : AgendamentoStatus
{
    public override void CalcularDesconto(Agendamento agendamento)
    {
        agendamento.CustoFinal = agendamento.CalcularDesconto();
    }

    public override void CalcularMultaAtraso(Agendamento agendamento)
    {
        agendamento.CustoAtraso = agendamento.CalcularMultaAtraso();
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