using Hospital.Domain.Entities.Atendimentos;
using Hospital.Domain.Entities.Cadastros;
using Hospital.Domain.Exceptions;

namespace Hospital.Domain.Entities.Agendamentos;
public class ExameAgendamento : Agendamento
{
    public Consulta Consulta { get; set; }
    public Exame Atendimento { get; set; }

    public ExameAgendamento() { }
    public ExameAgendamento(DateTime dataHora, Medico medico,
        Paciente paciente, Convenio? convenio, decimal custo,
        Consulta consulta)
    : base(dataHora, medico, paciente, convenio, custo)
    {
        if (consulta.Paciente != paciente)
            throw new DomainException(
                "O paciente da consulta é diferente do paciente do agendamento.");

        Consulta = consulta;
    }

    public override void Realizar(Atendimento atendimento)
    {
        if (atendimento is Exame exame)
        {
            base.Realizar(atendimento);
            Atendimento = exame;
        }

        throw new DomainException(
            "O atendimento não é um exame.");
    }
}