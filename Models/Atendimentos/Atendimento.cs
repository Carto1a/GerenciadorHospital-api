using System.ComponentModel.DataAnnotations;

using Hospital.Models.Agendamentos;
using Hospital.Models.Cadastro;

namespace Hospital.Models.Atendimento;
public abstract class Atendimento
{
    [Key]
    public Guid Id { get; set; }
    public Guid MedicoId { get; set; }
    public Guid PacienteId { get; set; }
    public Guid? AgendamentoId { get; set; }
    public Guid? ConvenioId { get; set; }

    public virtual Medico? Medico { get; set; }
    public virtual Paciente? Paciente { get; set; }
    public virtual Agendamento? Agendamento { get; set; }

    public DateTime Inicio { get; set; }
    public DateTime Fim { get; set; }
    public decimal Custo { get; set; }
    public decimal CustoFinal { get; set; }

    public DateTime Criado { get; set; }

    public TimeSpan Duracao => Fim - Inicio;
}