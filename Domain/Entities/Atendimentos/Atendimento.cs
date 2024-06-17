using System.ComponentModel.DataAnnotations;

using Hospital.Domain.Entities.Agendamentos;
using Hospital.Domain.Entities.Cadastros;

namespace Hospital.Domain.Entities.Atendimentos;
public abstract class Atendimento : Entity
{
    public Guid? MedicoId { get; set; }
    public Guid? PacienteId { get; set; }
    public Guid? AgendamentoId { get; set; }
    public Guid? ConvenioId { get; set; }

    public virtual Medico? Medico { get; set; }
    public virtual Paciente? Paciente { get; set; }
    public virtual Convenio? Convenio { get; set; }

    public DateTime Inicio { get; set; }
    public DateTime Fim { get; set; }
    public decimal Custo { get; set; }
    public decimal CustoFinal { get; set; }

    public TimeSpan Duracao => Fim - Inicio;

    public void LoadInfoFromAgendamento(Agendamento agendamento)
    {
        MedicoId = agendamento.MedicoId;
        PacienteId = agendamento.PacienteId;
        ConvenioId = agendamento.ConvenioId;
        Custo = agendamento.Custo;
        CustoFinal = agendamento.CustoFinal;
    }
}