using Hospital.Domain.Entities.Agendamentos;
using Hospital.Domain.Entities.Cadastros;
using Hospital.Domain.Enums;
using Hospital.Domain.Exceptions;

namespace Hospital.Domain.Entities.Atendimentos;
public class Exame : Atendimento
{
    // TODO: colocar o tipo de exame
    public Consulta Consulta { get; set; }

    public string? Resultado { get; set; }
    public ExameStatus Status { get; set; }
    public Exame() { }
    public Exame(Medico medico, DateTime inicio, DateTime fim,
        string? resultado)
    : base(medico, inicio, fim)
    {
        Status = ExameStatus.Processando;
        if (Resultado != null)
        {
            Resultado = resultado;
            Status = ExameStatus.Completado;
        }
    }

    public void Completar(string resultado)
    {
        if (Status == ExameStatus.Completado)
            throw new DomainException(
                "O exame já foi completado.");

        Resultado = resultado;
        Status = ExameStatus.Completado;
    }

    public override void GetInfoAgendamento(Agendamento agendamento)
    {
        if (agendamento is ExameAgendamento exameAgendamento)
        {
            Consulta = exameAgendamento.Consulta;
        }

        throw new DomainInternalException(
            "O agendamento não é um exame.");
    }
}