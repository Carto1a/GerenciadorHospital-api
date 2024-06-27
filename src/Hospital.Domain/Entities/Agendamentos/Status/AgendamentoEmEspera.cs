using Hospital.Domain.Entities.Atendimentos;
using Hospital.Domain.Enums;

namespace Hospital.Domain.Entities.Agendamentos.Status;
public class AgendamentoEmEspera : AgendamentoStatus
{
    public override void Realizar(Agendamento agendamento, Atendimento atendimento)
    {
        base.Realizar(agendamento, atendimento);
    }

    public override void EmAndamento(Agendamento agendamento)
    {
        agendamento.State = new AgendamentoEmAndamento();
        agendamento.Status = AgendamentoStatusEnum.EmAndamento;
    }

    public override void Ausente(Agendamento agendamento)
    {
        agendamento.State = new AgendamentoAusente();
        agendamento.Status = AgendamentoStatusEnum.Ausencia;
    }
}