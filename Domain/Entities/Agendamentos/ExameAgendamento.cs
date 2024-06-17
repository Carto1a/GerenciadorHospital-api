using Hospital.Application.Dto.Input.Agendamentos;
using Hospital.Domain.Entities.Atendimentos;

namespace Hospital.Domain.Entities.Agendamentos;
public class ExameAgendamento : Agendamento
{
    public Guid ConsultaId { get; set; }

    public virtual Consulta? Consulta { get; set; }
    public virtual Exame? Exame { get; set; }

    public ExameAgendamento() { }
    public ExameAgendamento Create(AgendamentoExameCreateDto request)
    {
        base.Create(request);
        ConsultaId = request.ConsultaId;
        return this;
    }
}