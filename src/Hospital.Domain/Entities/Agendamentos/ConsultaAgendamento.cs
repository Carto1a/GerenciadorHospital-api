using Hospital.Domain.Entities.Atendimentos;
using Hospital.Domain.Entities.Cadastros;
using Hospital.Domain.Exceptions;

namespace Hospital.Domain.Entities.Agendamentos;
public class ConsultaAgendamento : Agendamento
{
    public ConsultaAgendamento() { }
    public Consulta Atendimento { get; set; }
    public ConsultaAgendamento(DateTime dataHora, Medico medico,
        Paciente paciente, Convenio? convenio, decimal custo)
    : base(dataHora, medico, paciente, convenio, custo) { }

    public override void Realizar(Atendimento atendimento)
    {
        if (atendimento is Consulta consulta)
        {
            base.Realizar(atendimento);
            Atendimento = consulta;
        }

        throw new DomainException(
            "O atendimento não é uma consulta.");
    }
}