using Hospital.Models.Atendimento;

namespace Hospital.Models.Agendamentos;
public class ExameAgendamento
: Agendamento
{
    public virtual Exame? Exame { get; set; }
}