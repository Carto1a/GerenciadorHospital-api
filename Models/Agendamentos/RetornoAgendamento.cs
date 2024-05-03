using Hospital.Dtos.Input.Agendamentos;
using Hospital.Models.Atendimento;

namespace Hospital.Models.Agendamentos;
public class RetornoAgendamento
: Agendamento
{
    public Guid ConsultaId { get; set; }

    public virtual Consulta? Consulta { get; set; }
    public virtual Retorno? Retorno { get; set; }

    public RetornoAgendamento() { }
    public RetornoAgendamento(RetornoAgendamentoCreateDto request)
    : base(request)
    {
        ConsultaId = request.ConsultaId;
    }

    public RetornoAgendamento Create(
        RetornoAgendamentoCreateDto request)
    {
        base.Create(request);
        ConsultaId = request.ConsultaId;
        return this;
    }
}