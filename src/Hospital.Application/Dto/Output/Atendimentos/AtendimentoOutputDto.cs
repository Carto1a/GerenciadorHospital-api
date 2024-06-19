using Hospital.Domain.Entities.Atendimentos;

namespace Hospital.Application.Dto.Output.Atendimentos;
public record AtendimentoOutputDto
{
    public Guid Id { get; init; }
    public Guid MedicoId { get; init; }
    public Guid PacienteId { get; init; }
    public Guid? ConvenioId { get; init; }
    public Guid? AgendamentoId { get; init; }

    public DateTime Inicio { get; init; }
    public DateTime Fim { get; init; }
    public decimal Custo { get; init; }
    public decimal CustoFinal { get; init; }

    public DateTime Criado { get; init; }

    public TimeSpan Duracao => Fim - Inicio;

    public AtendimentoOutputDto(Atendimento original)
    {
        Id = original.Id;
        MedicoId = (Guid)original.MedicoId!;
        PacienteId = (Guid)original.PacienteId!;
        AgendamentoId = original.AgendamentoId;
        Inicio = original.Inicio;
        Fim = original.Fim;
        ConvenioId = original.ConvenioId;
        Custo = original.Custo;
        CustoFinal = original.CustoFinal;
        Criado = original.Criado;
    }
}