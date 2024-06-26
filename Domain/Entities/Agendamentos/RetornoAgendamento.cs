using Hospital.Application.Dto.Input.Agendamentos;
using Hospital.Domain.Entities.Atendimentos;

namespace Hospital.Domain.Entities.Agendamentos;
public class RetornoAgendamento : Agendamento
{
    public Guid ConsultaId { get; set; }

    public virtual Consulta? Consulta { get; set; }
    public virtual Retorno? Retorno { get; set; }

    public RetornoAgendamento() { }
    public RetornoAgendamento Create(
        AgendamentoRetornoCreateDto request)
    {
        base.Create(request);
        ConsultaId = request.ConsultaId;
        return this;
    }

    public void GratuidadeRetorno(DateTime FimConsulta, Convenio? convenio)
    {
        if (FimConsulta.AddDays(30) < DateTime.Now)
            CustoFinal = Custo;
        else
            CustoFinal = 0;
    }
}