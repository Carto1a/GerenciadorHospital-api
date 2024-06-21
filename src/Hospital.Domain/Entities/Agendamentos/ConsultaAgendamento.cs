using Hospital.Domain.Entities.Atendimentos;
using Hospital.Domain.Entities.Cadastros;
using Hospital.Domain.Enums;
using Hospital.Domain.Exceptions;

namespace Hospital.Domain.Entities.Agendamentos;
public class ConsultaAgendamento : Agendamento
{
    public Consulta Atendimento { get; set; }
    public ConsultaAgendamento(DateTime dataHora, Medico medico,
        Paciente paciente, Convenio? convenio, decimal custo)
    : base(dataHora, medico, paciente, convenio, custo) { }

    public override void Realizar(Atendimento atendimento)
    {
        if (atendimento is Consulta consulta)
        {
            PodeSerRealizado();
            Status = AgendamentoStatus.Realizado;
            consulta.GetInfoAgendamento(this);
            Atendimento = consulta;
        }

        throw new DomainException(
            "O atendimento não é uma consulta.");
    }
}