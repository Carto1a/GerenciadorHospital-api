using Hospital.Models.Atendimento;

namespace Hospital.Models.Agendamentos;
public class RetornoAgendamento
: Agendamento
{
    public Guid ConsultaId { get; set; }

    public Consulta? Consulta { get; set; }
}
