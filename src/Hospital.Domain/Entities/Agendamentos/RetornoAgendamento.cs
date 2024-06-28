using Hospital.Domain.Entities.Atendimentos;
using Hospital.Domain.Entities.Cadastros;
using Hospital.Domain.Exceptions;

namespace Hospital.Domain.Entities.Agendamentos;
public class RetornoAgendamento : Agendamento
{
    public Consulta Consulta { get; set; }
    public Retorno Atendimento { get; set; }

    public RetornoAgendamento() { }
    public RetornoAgendamento(DateTime dataHora, Medico medico,
        Paciente paciente, Convenio? convenio, decimal custo,
        Consulta consulta)
    : base(dataHora, medico, paciente, convenio, custo)
    {
        Consulta = consulta;

        if (consulta.Fim.AddDays(30) < DateTime.Now)
            CustoFinal = Custo;
        else
            CustoFinal = 0;
    }

    public override void Realizar(Atendimento atendimento)
    {
        if (atendimento is Retorno retorno)
        {
            base.Realizar(atendimento);
            Atendimento = retorno;
        }

        throw new DomainException(
            "O atendimento não é um retorno.");
    }

    protected override decimal CalcularDesconto()
    {
        return Custo;
    }
}